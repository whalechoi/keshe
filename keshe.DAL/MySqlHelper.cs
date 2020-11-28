// 修改自 https://github.com/leomuller/MySqlHelper
using System;
using System.Data;
using System.Xml;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Reflection;
using System.Collections.Generic;

namespace keshe.DAL
{
	/// <summary>
	/// The MySqlHelper class is intended to encapsulate high performance, scalable best practices for 
	/// common uses of MySqlClient.
	/// </summary>
	public sealed class MySqlHelper
	{
        #region private utility methods & constructors

        //Since this class provides only static methods, make the default constructor private to prevent 
        //instances from being created with "new MySqlHelper()".
        private MySqlHelper() { }



		/// <summary>
		/// This method is used to attach array of MySqlParameters to a MySqlCommand.
		/// 
		/// This method will assign a value of DbNull to any parameter with a direction of
		/// InputOutput and a value of null.  
		/// 
		/// This behavior will prevent default values from being used, but
		/// this will be the less common case than an intended pure output parameter (derived as InputOutput)
		/// where the user provided no input value.
		/// </summary>
		/// <param name="command">The command to which the parameters will be added</param>
		/// <param name="commandParameters">an array of MySqlParameters tho be added to command</param>
		private static void AttachParameters(MySqlCommand command, MySqlParameter[] commandParameters)
		{
			foreach (MySqlParameter p in commandParameters)
			{
				//check for derived output value with no value assigned
				if ((p.Direction == ParameterDirection.InputOutput) && (p.Value == null))
				{
					p.Value = DBNull.Value;
				}

				command.Parameters.Add(p);
			}
		}

		/// <summary>
		/// This method assigns an array of values to an array of MySqlParameters.
		/// </summary>
		/// <param name="commandParameters">array of MySqlParameters to be assigned values</param>
		/// <param name="parameterValues">array of objects holding the values to be assigned</param>
		private static void AssignParameterValues(MySqlParameter[] commandParameters, object[] parameterValues)
		{
			if ((commandParameters == null) || (parameterValues == null))
			{
				//do nothing if we get no data
				return;
			}

			// we must have the same number of values as we pave parameters to put them in
			if (commandParameters.Length != parameterValues.Length)
			{
				throw new ArgumentException("Parameter count does not match Parameter Value count.");
			}

			//iterate through the MySqlParameters, assigning the values from the corresponding position in the 
			//value array
			for (int i = 0, j = commandParameters.Length; i < j; i++)
			{
				commandParameters[i].Value = parameterValues[i];
			}
		}

		/// <summary>
		/// This method opens (if necessary) and assigns a connection, transaction, command type and parameters 
		/// to the provided command.
		/// </summary>
		/// <param name="command">the MySqlCommand to be prepared</param>
		/// <param name="connection">a valid MySqlConnection, on which to execute this command</param>
		/// <param name="transaction">a valid MySqlTransaction, or 'null'</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-MySql command</param>
		/// <param name="commandParameters">an array of MySqlParameters to be associated with the command or 'null' if no parameters are required</param>
		private static void PrepareCommand(MySqlCommand command, MySqlConnection connection, MySqlTransaction transaction, CommandType commandType, string commandText, MySqlParameter[] commandParameters)
		{
			//if the provided connection is not open, we will open it
			if (connection.State != ConnectionState.Open)
			{
				connection.Open();
			}

			//associate the connection with the command
			command.Connection = connection;

			//set the command text (stored procedure name or MySql statement)
			command.CommandText = commandText;

			//if we were provided a transaction, assign it.
			if (transaction != null)
			{
				command.Transaction = transaction;
			}

			//set the command type
			command.CommandType = commandType;

			//attach the command parameters if they are provided
			if (commandParameters != null)
			{
				AttachParameters(command, commandParameters);
			}

			return;
		}


		#endregion private utility methods & constructors

		#region ExecuteNonQuery

		/// <summary>
		/// Execute a MySqlCommand (that returns no resultset and takes no parameters) against the database specified in 
		/// the connection string. 
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders");
		/// </remarks>
		/// <param name="connectionString">a valid connection string for a MySqlConnection</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-MySql command</param>
		/// <returns>an int representing the number of rows affected by the command</returns>
		public static int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText)
		{
			//pass through the call providing null for the set of MySqlParameters
			return ExecuteNonQuery(connectionString, commandType, commandText, (MySqlParameter[])null);
		}

		/// <summary>
		/// Execute a MySqlCommand (that returns no resultset) against the database specified in the connection string 
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  int result = ExecuteNonQuery(connString, CommandType.StoredProcedure, "PublishOrders", new MySqlParameter("@prodid", 24));
		/// </remarks>
		/// <param name="connectionString">a valid connection string for a MySqlConnection</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-MySql command</param>
		/// <param name="commandParameters">an array of MySqlParamters used to execute the command</param>
		/// <returns>an int representing the number of rows affected by the command</returns>
		public static int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText, params MySqlParameter[] commandParameters)
		{
			//create & open a MySqlConnection, and dispose of it after we are done.
			using (MySqlConnection cn = new MySqlConnection(connectionString))
			{
				cn.Open();

				//call the overload that takes a connection in place of the connection string
				return ExecuteNonQuery(cn, commandType, commandText, commandParameters);
			}
		}

		/// <summary>
		/// Execute a stored procedure via a MySqlCommand (that returns no resultset) against the database specified in 
		/// the connection string using the provided parameter values.  This method will query the database to discover the parameters for the 
		/// stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
		/// </summary>
		/// <remarks>
		/// This method provides no access to output parameters or the stored procedure's return value parameter.
		/// 
		/// e.g.:  
		///  int result = ExecuteNonQuery(connString, "PublishOrders", 24, 36);
		/// </remarks>
		/// <param name="connectionString">a valid connection string for a MySqlConnection</param>
		/// <param name="spName">the name of the stored prcedure</param>
		/// <param name="parameterValues">an array of objects to be assigned as the input values of the stored procedure</param>
		/// <returns>an int representing the number of rows affected by the command</returns>
		public static int ExecuteNonQuery(string connectionString, string spName, params object[] parameterValues)
		{
			//if we receive parameter values, we need to figure out where they go
			if ((parameterValues != null) && (parameterValues.Length > 0))
			{
				//pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
				MySqlParameter[] commandParameters = MySqlHelperParameterCache.GetSpParameterSet(connectionString, spName);

				//assign the provided values to these parameters based on parameter order
				AssignParameterValues(commandParameters, parameterValues);

				//call the overload that takes an array of MySqlParameters
				return ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName, commandParameters);
			}
			//otherwise we can just call the SP without params
			else
			{
				return ExecuteNonQuery(connectionString, CommandType.StoredProcedure, spName);
			}
		}

		/// <summary>
		/// Execute a MySqlCommand (that returns no resultset and takes no parameters) against the provided MySqlConnection. 
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  int result = ExecuteNonQuery(conn, CommandType.StoredProcedure, "PublishOrders");
		/// </remarks>
		/// <param name="connection">a valid MySqlConnection</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-MySql command</param>
		/// <returns>an int representing the number of rows affected by the command</returns>
		public static int ExecuteNonQuery(MySqlConnection connection, CommandType commandType, string commandText)
		{
			//pass through the call providing null for the set of MySqlParameters
			return ExecuteNonQuery(connection, commandType, commandText, (MySqlParameter[])null);
		}

		/// <summary>
		/// Execute a MySqlCommand (that returns no resultset) against the specified MySqlConnection 
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  int result = ExecuteNonQuery(conn, CommandType.StoredProcedure, "PublishOrders", new MySqlParameter("@prodid", 24));
		/// </remarks>
		/// <param name="connection">a valid MySqlConnection</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-MySql command</param>
		/// <param name="commandParameters">an array of MySqlParamters used to execute the command</param>
		/// <returns>an int representing the number of rows affected by the command</returns>
		public static int ExecuteNonQuery(MySqlConnection connection, CommandType commandType, string commandText, params MySqlParameter[] commandParameters)
		{
			try
			{
				//create a command and prepare it for execution
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandTimeout = connection.ConnectionTimeout;  //leo - so setting the connecting timeout is all that we need.
				PrepareCommand(cmd, connection, (MySqlTransaction)null, commandType, commandText, commandParameters);

				//finally, execute the command.
				int retval = cmd.ExecuteNonQuery();

				// detach the MySqlParameters from the command object, so they can be used again.
				cmd.Parameters.Clear();
				return retval;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message + Environment.NewLine + "Query: " + commandText);
			}
		}

		/// <summary>
		/// Execute a stored procedure via a MySqlCommand (that returns no resultset) against the specified MySqlConnection 
		/// using the provided parameter values.  This method will query the database to discover the parameters for the 
		/// stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
		/// </summary>
		/// <remarks>
		/// This method provides no access to output parameters or the stored procedure's return value parameter.
		/// 
		/// e.g.:  
		///  int result = ExecuteNonQuery(conn, "PublishOrders", 24, 36);
		/// </remarks>
		/// <param name="connection">a valid MySqlConnection</param>
		/// <param name="spName">the name of the stored procedure</param>
		/// <param name="parameterValues">an array of objects to be assigned as the input values of the stored procedure</param>
		/// <returns>an int representing the number of rows affected by the command</returns>
		public static int ExecuteNonQuery(MySqlConnection connection, string spName, params object[] parameterValues)
		{
			//if we receive parameter values, we need to figure out where they go
			if ((parameterValues != null) && (parameterValues.Length > 0))
			{
				//pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
				MySqlParameter[] commandParameters = MySqlHelperParameterCache.GetSpParameterSet(connection.ConnectionString, spName);

				//assign the provided values to these parameters based on parameter order
				AssignParameterValues(commandParameters, parameterValues);

				//call the overload that takes an array of MySqlParameters
				return ExecuteNonQuery(connection, CommandType.StoredProcedure, spName, commandParameters);
			}
			//otherwise we can just call the SP without params
			else
			{
				return ExecuteNonQuery(connection, CommandType.StoredProcedure, spName);
			}
		}

		/// <summary>
		/// Execute a MySqlCommand (that returns no resultset and takes no parameters) against the provided MySqlTransaction. 
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  int result = ExecuteNonQuery(trans, CommandType.StoredProcedure, "PublishOrders");
		/// </remarks>
		/// <param name="transaction">a valid MySqlTransaction</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-MySql command</param>
		/// <returns>an int representing the number of rows affected by the command</returns>
		public static int ExecuteNonQuery(MySqlTransaction transaction, CommandType commandType, string commandText)
		{
			//pass through the call providing null for the set of MySqlParameters
			return ExecuteNonQuery(transaction, commandType, commandText, (MySqlParameter[])null);
		}

		/// <summary>
		/// Execute a MySqlCommand (that returns no resultset) against the specified MySqlTransaction
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  int result = ExecuteNonQuery(trans, CommandType.StoredProcedure, "GetOrders", new MySqlParameter("@prodid", 24));
		/// </remarks>
		/// <param name="transaction">a valid MySqlTransaction</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-MySql command</param>
		/// <param name="commandParameters">an array of MySqlParamters used to execute the command</param>
		/// <returns>an int representing the number of rows affected by the command</returns>
		public static int ExecuteNonQuery(MySqlTransaction transaction, CommandType commandType, string commandText, params MySqlParameter[] commandParameters)
		{
			try
			{
				//create a command and prepare it for execution
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandTimeout = transaction.Connection.ConnectionTimeout;  //leo - so setting the connecting timeout is all that we need.
				PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters);

				//finally, execute the command.
				int retval = cmd.ExecuteNonQuery();

				// detach the MySqlParameters from the command object, so they can be used again.
				cmd.Parameters.Clear();
				return retval;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message + Environment.NewLine + "Query: " + commandText);
			}
		}

		/// <summary>
		/// Execute a stored procedure via a MySqlCommand (that returns no resultset) against the specified 
		/// MySqlTransaction using the provided parameter values.  This method will query the database to discover the parameters for the 
		/// stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
		/// </summary>
		/// <remarks>
		/// This method provides no access to output parameters or the stored procedure's return value parameter.
		/// 
		/// e.g.:  
		///  int result = ExecuteNonQuery(conn, trans, "PublishOrders", 24, 36);
		/// </remarks>
		/// <param name="transaction">a valid MySqlTransaction</param>
		/// <param name="spName">the name of the stored procedure</param>
		/// <param name="parameterValues">an array of objects to be assigned as the input values of the stored procedure</param>
		/// <returns>an int representing the number of rows affected by the command</returns>
		public static int ExecuteNonQuery(MySqlTransaction transaction, string spName, params object[] parameterValues)
		{
			//if we receive parameter values, we need to figure out where they go
			if ((parameterValues != null) && (parameterValues.Length > 0))
			{
				//pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
				MySqlParameter[] commandParameters = MySqlHelperParameterCache.GetSpParameterSet(transaction.Connection.ConnectionString, spName);

				//assign the provided values to these parameters based on parameter order
				AssignParameterValues(commandParameters, parameterValues);

				//call the overload that takes an array of MySqlParameters
				return ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName, commandParameters);
			}
			//otherwise we can just call the SP without params
			else
			{
				return ExecuteNonQuery(transaction, CommandType.StoredProcedure, spName);
			}
		}


		#endregion ExecuteNonQuery

		#region ExecuteDataTable
		public static DataTable GetData(string connectionString, string StoredProcedure)
		{
			DataSet ds = ExecuteDataset(connectionString, CommandType.StoredProcedure, StoredProcedure);

			return ds.Tables[0];
		}

		public static DataTable GetData(string connectionString, string StoredProcedure, params MySqlParameter[] commandParameters)
		{
			DataSet ds = ExecuteDataset(connectionString, CommandType.StoredProcedure, StoredProcedure, commandParameters);

			return ds.Tables[0];
		}

		public static DataTable GetData(string connectionString, CommandType commandType, string commandText)
		{
			DataSet ds = ExecuteDataset(connectionString, commandType, commandText, (MySqlParameter[])null);

			return ds.Tables[0];
		}

		public static DataTable GetData(string connectionString, CommandType commandType, string commandText, params MySqlParameter[] commandParameters)
		{
			DataSet ds = ExecuteDataset(connectionString, commandType, commandText, commandParameters);

			return ds.Tables[0];
		}
		#endregion ExecuteDataTable

		#region ExecuteDataSet

		/// <summary>
		/// Execute a MySqlCommand (that returns a resultset and takes no parameters) against the database specified in 
		/// the connection string. 
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  DataSet ds = ExecuteDataset(connString, CommandType.StoredProcedure, "GetOrders");
		/// </remarks>
		/// <param name="connectionString">a valid connection string for a MySqlConnection</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-MySql command</param>
		/// <returns>a dataset containing the resultset generated by the command</returns>
		public static DataSet ExecuteDataset(string connectionString, CommandType commandType, string commandText)
		{
			//pass through the call providing null for the set of MySqlParameters
			return ExecuteDataset(connectionString, commandType, commandText, (MySqlParameter[])null);
		}

		/// <summary>
		/// Execute a MySqlCommand (that returns a resultset) against the database specified in the connection string 
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  DataSet ds = ExecuteDataset(connString, CommandType.StoredProcedure, "GetOrders", new MySqlParameter("@prodid", 24));
		/// </remarks>
		/// <param name="connectionString">a valid connection string for a MySqlConnection</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-MySql command</param>
		/// <param name="commandParameters">an array of MySqlParamters used to execute the command</param>
		/// <returns>a dataset containing the resultset generated by the command</returns>
		public static DataSet ExecuteDataset(string connectionString, CommandType commandType, string commandText, params MySqlParameter[] commandParameters)
		{
			//create & open a MySqlConnection, and dispose of it after we are done.
			using (MySqlConnection cn = new MySqlConnection(connectionString))
			{
				cn.Open();

				//call the overload that takes a connection in place of the connection string
				return ExecuteDataset(cn, commandType, commandText, commandParameters);
			}
		}

		/// <summary>
		/// Execute a stored procedure via a MySqlCommand (that returns a resultset) against the database specified in 
		/// the connection string using the provided parameter values.  This method will query the database to discover the parameters for the 
		/// stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
		/// </summary>
		/// <remarks>
		/// This method provides no access to output parameters or the stored procedure's return value parameter.
		/// 
		/// e.g.:  
		///  DataSet ds = ExecuteDataset(connString, "GetOrders", 24, 36);
		/// </remarks>
		/// <param name="connectionString">a valid connection string for a MySqlConnection</param>
		/// <param name="spName">the name of the stored procedure</param>
		/// <param name="parameterValues">an array of objects to be assigned as the input values of the stored procedure</param>
		/// <returns>a dataset containing the resultset generated by the command</returns>
		public static DataSet ExecuteDataset(string connectionString, string spName, params object[] parameterValues)
		{
			//if we receive parameter values, we need to figure out where they go
			if ((parameterValues != null) && (parameterValues.Length > 0))
			{
				//pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
				MySqlParameter[] commandParameters = MySqlHelperParameterCache.GetSpParameterSet(connectionString, spName);

				//assign the provided values to these parameters based on parameter order
				AssignParameterValues(commandParameters, parameterValues);

				//call the overload that takes an array of MySqlParameters
				return ExecuteDataset(connectionString, CommandType.StoredProcedure, spName, commandParameters);
			}
			//otherwise we can just call the SP without params
			else
			{
				return ExecuteDataset(connectionString, CommandType.StoredProcedure, spName);
			}
		}

		/// <summary>
		/// Execute a MySqlCommand (that returns a resultset and takes no parameters) against the provided MySqlConnection. 
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  DataSet ds = ExecuteDataset(conn, CommandType.StoredProcedure, "GetOrders");
		/// </remarks>
		/// <param name="connection">a valid MySqlConnection</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-MySql command</param>
		/// <returns>a dataset containing the resultset generated by the command</returns>
		public static DataSet ExecuteDataset(MySqlConnection connection, CommandType commandType, string commandText)
		{
			//pass through the call providing null for the set of MySqlParameters
			return ExecuteDataset(connection, commandType, commandText, (MySqlParameter[])null);
		}

		/// <summary>
		/// Execute a MySqlCommand (that returns a resultset) against the specified MySqlConnection 
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  DataSet ds = ExecuteDataset(conn, CommandType.StoredProcedure, "GetOrders", new MySqlParameter("@prodid", 24));
		/// </remarks>
		/// <param name="connection">a valid MySqlConnection</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-MySql command</param>
		/// <param name="commandParameters">an array of MySqlParamters used to execute the command</param>
		/// <returns>a dataset containing the resultset generated by the command</returns>
		public static DataSet ExecuteDataset(MySqlConnection connection, CommandType commandType, string commandText, params MySqlParameter[] commandParameters)
		{
			try
			{
				//create a command and prepare it for execution
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandTimeout = connection.ConnectionTimeout;  //leo - so setting the connecting timeout is all that we need.
				PrepareCommand(cmd, connection, (MySqlTransaction)null, commandType, commandText, commandParameters);

				//create the DataAdapter & DataSet
				MySqlDataAdapter da = new MySqlDataAdapter(cmd);
				DataSet ds = new DataSet();

				//fill the DataSet using default values for DataTable names, etc.
				da.Fill(ds);

				// detach the MySqlParameters from the command object, so they can be used again.			
				cmd.Parameters.Clear();

				//return the dataset
				return ds;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message + Environment.NewLine + "Query: " + commandText);
			}
		}

		/// <summary>
		/// Execute a stored procedure via a MySqlCommand (that returns a resultset) against the specified MySqlConnection 
		/// using the provided parameter values.  This method will query the database to discover the parameters for the 
		/// stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
		/// </summary>
		/// <remarks>
		/// This method provides no access to output parameters or the stored procedure's return value parameter.
		/// 
		/// e.g.:  
		///  DataSet ds = ExecuteDataset(conn, "GetOrders", 24, 36);
		/// </remarks>
		/// <param name="connection">a valid MySqlConnection</param>
		/// <param name="spName">the name of the stored procedure</param>
		/// <param name="parameterValues">an array of objects to be assigned as the input values of the stored procedure</param>
		/// <returns>a dataset containing the resultset generated by the command</returns>
		public static DataSet ExecuteDataset(MySqlConnection connection, string spName, params object[] parameterValues)
		{
			//if we receive parameter values, we need to figure out where they go
			if ((parameterValues != null) && (parameterValues.Length > 0))
			{
				//pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
				MySqlParameter[] commandParameters = MySqlHelperParameterCache.GetSpParameterSet(connection.ConnectionString, spName);

				//assign the provided values to these parameters based on parameter order
				AssignParameterValues(commandParameters, parameterValues);

				//call the overload that takes an array of MySqlParameters
				return ExecuteDataset(connection, CommandType.StoredProcedure, spName, commandParameters);
			}
			//otherwise we can just call the SP without params
			else
			{
				return ExecuteDataset(connection, CommandType.StoredProcedure, spName);
			}
		}

		/// <summary>
		/// Execute a MySqlCommand (that returns a resultset and takes no parameters) against the provided MySqlTransaction. 
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  DataSet ds = ExecuteDataset(trans, CommandType.StoredProcedure, "GetOrders");
		/// </remarks>
		/// <param name="transaction">a valid MySqlTransaction</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-MySql command</param>
		/// <returns>a dataset containing the resultset generated by the command</returns>
		public static DataSet ExecuteDataset(MySqlTransaction transaction, CommandType commandType, string commandText)
		{
			//pass through the call providing null for the set of MySqlParameters
			return ExecuteDataset(transaction, commandType, commandText, (MySqlParameter[])null);
		}

		/// <summary>
		/// Execute a MySqlCommand (that returns a resultset) against the specified MySqlTransaction
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  DataSet ds = ExecuteDataset(trans, CommandType.StoredProcedure, "GetOrders", new MySqlParameter("@prodid", 24));
		/// </remarks>
		/// <param name="transaction">a valid MySqlTransaction</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-MySql command</param>
		/// <param name="commandParameters">an array of MySqlParamters used to execute the command</param>
		/// <returns>a dataset containing the resultset generated by the command</returns>
		public static DataSet ExecuteDataset(MySqlTransaction transaction, CommandType commandType, string commandText, params MySqlParameter[] commandParameters)
		{
			try
			{
				//create a command and prepare it for execution
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandTimeout = transaction.Connection.ConnectionTimeout;  //leo - so setting the connecting timeout is all that we need.
				PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters);

				//create the DataAdapter & DataSet
				MySqlDataAdapter da = new MySqlDataAdapter(cmd);
				DataSet ds = new DataSet();

				//fill the DataSet using default values for DataTable names, etc.
				da.Fill(ds);

				// detach the MySqlParameters from the command object, so they can be used again.
				cmd.Parameters.Clear();

				//return the dataset
				return ds;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message + Environment.NewLine + "Query: " + commandText);
			}
		}

		/// <summary>
		/// Execute a stored procedure via a MySqlCommand (that returns a resultset) against the specified 
		/// MySqlTransaction using the provided parameter values.  This method will query the database to discover the parameters for the 
		/// stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
		/// </summary>
		/// <remarks>
		/// This method provides no access to output parameters or the stored procedure's return value parameter.
		/// 
		/// e.g.:  
		///  DataSet ds = ExecuteDataset(trans, "GetOrders", 24, 36);
		/// </remarks>
		/// <param name="transaction">a valid MySqlTransaction</param>
		/// <param name="spName">the name of the stored procedure</param>
		/// <param name="parameterValues">an array of objects to be assigned as the input values of the stored procedure</param>
		/// <returns>a dataset containing the resultset generated by the command</returns>
		public static DataSet ExecuteDataset(MySqlTransaction transaction, string spName, params object[] parameterValues)
		{
			//if we receive parameter values, we need to figure out where they go
			if ((parameterValues != null) && (parameterValues.Length > 0))
			{
				//pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
				MySqlParameter[] commandParameters = MySqlHelperParameterCache.GetSpParameterSet(transaction.Connection.ConnectionString, spName);

				//assign the provided values to these parameters based on parameter order
				AssignParameterValues(commandParameters, parameterValues);

				//call the overload that takes an array of MySqlParameters
				return ExecuteDataset(transaction, CommandType.StoredProcedure, spName, commandParameters);
			}
			//otherwise we can just call the SP without params
			else
			{
				return ExecuteDataset(transaction, CommandType.StoredProcedure, spName);
			}
		}

		#endregion ExecuteDataSet

		#region ExecuteReader

		/// <summary>
		/// this enum is used to indicate whether the connection was provided by the caller, or created by MySqlHelper, so that
		/// we can set the appropriate CommandBehavior when calling ExecuteReader()
		/// </summary>
		private enum MySqlConnectionOwnership
		{
			/// <summary>Connection is owned and managed by MySqlHelper</summary>
			Internal,
			/// <summary>Connection is owned and managed by the caller</summary>
			External
		}

		/// <summary>
		/// Create and prepare a MySqlCommand, and call ExecuteReader with the appropriate CommandBehavior.
		/// </summary>
		/// <remarks>
		/// If we created and opened the connection, we want the connection to be closed when the DataReader is closed.
		/// 
		/// If the caller provided the connection, we want to leave it to them to manage.
		/// </remarks>
		/// <param name="connection">a valid MySqlConnection, on which to execute this command</param>
		/// <param name="transaction">a valid MySqlTransaction, or 'null'</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-MySql command</param>
		/// <param name="commandParameters">an array of MySqlParameters to be associated with the command or 'null' if no parameters are required</param>
		/// <param name="connectionOwnership">indicates whether the connection parameter was provided by the caller, or created by MySqlHelper</param>
		/// <returns>MySqlDataReader containing the results of the command</returns>
		private static MySqlDataReader ExecuteReader(MySqlConnection connection, MySqlTransaction transaction, CommandType commandType, string commandText, MySqlParameter[] commandParameters, MySqlConnectionOwnership connectionOwnership)
		{
			//create a command and prepare it for execution
			MySqlCommand cmd = new MySqlCommand();
			cmd.CommandTimeout = connection.ConnectionTimeout;  //leo - so setting the connecting timeout is all that we need.
			PrepareCommand(cmd, connection, transaction, commandType, commandText, commandParameters);

			//create a reader
			MySqlDataReader dr;

			// call ExecuteReader with the appropriate CommandBehavior
			if (connectionOwnership == MySqlConnectionOwnership.External)
			{
				dr = cmd.ExecuteReader();
			}
			else
			{
				dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
			}

			// detach the MySqlParameters from the command object, so they can be used again.
			cmd.Parameters.Clear();

			return dr;
		}

		/// <summary>
		/// Execute a MySqlCommand (that returns a resultset and takes no parameters) against the database specified in 
		/// the connection string. 
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  MySqlDataReader dr = ExecuteReader(connString, CommandType.StoredProcedure, "GetOrders");
		/// </remarks>
		/// <param name="connectionString">a valid connection string for a MySqlConnection</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-MySql command</param>
		/// <returns>a MySqlDataReader containing the resultset generated by the command</returns>
		public static MySqlDataReader ExecuteReader(string connectionString, CommandType commandType, string commandText)
		{
			//pass through the call providing null for the set of MySqlParameters
			return ExecuteReader(connectionString, commandType, commandText, (MySqlParameter[])null);
		}

		/// <summary>
		/// Execute a MySqlCommand (that returns a resultset) against the database specified in the connection string 
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  MySqlDataReader dr = ExecuteReader(connString, CommandType.StoredProcedure, "GetOrders", new MySqlParameter("@prodid", 24));
		/// </remarks>
		/// <param name="connectionString">a valid connection string for a MySqlConnection</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-MySql command</param>
		/// <param name="commandParameters">an array of MySqlParamters used to execute the command</param>
		/// <returns>a MySqlDataReader containing the resultset generated by the command</returns>
		public static MySqlDataReader ExecuteReader(string connectionString, CommandType commandType, string commandText, params MySqlParameter[] commandParameters)
		{
			//create & open a MySqlConnection
			MySqlConnection cn = new MySqlConnection(connectionString);
			cn.Open();

			try
			{
				//call the private overload that takes an internally owned connection in place of the connection string
				return ExecuteReader(cn, null, commandType, commandText, commandParameters, MySqlConnectionOwnership.Internal);
			}
			catch
			{
				//if we fail to return the MySqlDatReader, we need to close the connection ourselves
				cn.Close();
				throw;
			}
		}

		/// <summary>
		/// Execute a stored procedure via a MySqlCommand (that returns a resultset) against the database specified in 
		/// the connection string using the provided parameter values.  This method will query the database to discover the parameters for the 
		/// stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
		/// </summary>
		/// <remarks>
		/// This method provides no access to output parameters or the stored procedure's return value parameter.
		/// 
		/// e.g.:  
		///  MySqlDataReader dr = ExecuteReader(connString, "GetOrders", 24, 36);
		/// </remarks>
		/// <param name="connectionString">a valid connection string for a MySqlConnection</param>
		/// <param name="spName">the name of the stored procedure</param>
		/// <param name="parameterValues">an array of objects to be assigned as the input values of the stored procedure</param>
		/// <returns>a MySqlDataReader containing the resultset generated by the command</returns>
		public static MySqlDataReader ExecuteReader(string connectionString, string spName, params object[] parameterValues)
		{
			//if we receive parameter values, we need to figure out where they go
			if ((parameterValues != null) && (parameterValues.Length > 0))
			{
				//pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
				MySqlParameter[] commandParameters = MySqlHelperParameterCache.GetSpParameterSet(connectionString, spName);

				//assign the provided values to these parameters based on parameter order
				AssignParameterValues(commandParameters, parameterValues);

				//call the overload that takes an array of MySqlParameters
				return ExecuteReader(connectionString, CommandType.StoredProcedure, spName, commandParameters);
			}
			//otherwise we can just call the SP without params
			else
			{
				return ExecuteReader(connectionString, CommandType.StoredProcedure, spName);
			}
		}

		/// <summary>
		/// Execute a MySqlCommand (that returns a resultset and takes no parameters) against the provided MySqlConnection. 
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  MySqlDataReader dr = ExecuteReader(conn, CommandType.StoredProcedure, "GetOrders");
		/// </remarks>
		/// <param name="connection">a valid MySqlConnection</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-MySql command</param>
		/// <returns>a MySqlDataReader containing the resultset generated by the command</returns>
		public static MySqlDataReader ExecuteReader(MySqlConnection connection, CommandType commandType, string commandText)
		{
			//pass through the call providing null for the set of MySqlParameters
			return ExecuteReader(connection, commandType, commandText, (MySqlParameter[])null);
		}

		/// <summary>
		/// Execute a MySqlCommand (that returns a resultset) against the specified MySqlConnection 
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  MySqlDataReader dr = ExecuteReader(conn, CommandType.StoredProcedure, "GetOrders", new MySqlParameter("@prodid", 24));
		/// </remarks>
		/// <param name="connection">a valid MySqlConnection</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-MySql command</param>
		/// <param name="commandParameters">an array of MySqlParamters used to execute the command</param>
		/// <returns>a MySqlDataReader containing the resultset generated by the command</returns>
		public static MySqlDataReader ExecuteReader(MySqlConnection connection, CommandType commandType, string commandText, params MySqlParameter[] commandParameters)
		{
			//pass through the call to the private overload using a null transaction value and an externally owned connection
			return ExecuteReader(connection, (MySqlTransaction)null, commandType, commandText, commandParameters, MySqlConnectionOwnership.External);
		}

		/// <summary>
		/// Execute a stored procedure via a MySqlCommand (that returns a resultset) against the specified MySqlConnection 
		/// using the provided parameter values.  This method will query the database to discover the parameters for the 
		/// stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
		/// </summary>
		/// <remarks>
		/// This method provides no access to output parameters or the stored procedure's return value parameter.
		/// 
		/// e.g.:  
		///  MySqlDataReader dr = ExecuteReader(conn, "GetOrders", 24, 36);
		/// </remarks>
		/// <param name="connection">a valid MySqlConnection</param>
		/// <param name="spName">the name of the stored procedure</param>
		/// <param name="parameterValues">an array of objects to be assigned as the input values of the stored procedure</param>
		/// <returns>a MySqlDataReader containing the resultset generated by the command</returns>
		public static MySqlDataReader ExecuteReader(MySqlConnection connection, string spName, params object[] parameterValues)
		{
			//if we receive parameter values, we need to figure out where they go
			if ((parameterValues != null) && (parameterValues.Length > 0))
			{
				MySqlParameter[] commandParameters = MySqlHelperParameterCache.GetSpParameterSet(connection.ConnectionString, spName);

				AssignParameterValues(commandParameters, parameterValues);

				return ExecuteReader(connection, CommandType.StoredProcedure, spName, commandParameters);
			}
			//otherwise we can just call the SP without params
			else
			{
				return ExecuteReader(connection, CommandType.StoredProcedure, spName);
			}
		}

		/// <summary>
		/// Execute a MySqlCommand (that returns a resultset and takes no parameters) against the provided MySqlTransaction. 
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  MySqlDataReader dr = ExecuteReader(trans, CommandType.StoredProcedure, "GetOrders");
		/// </remarks>
		/// <param name="transaction">a valid MySqlTransaction</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-MySql command</param>
		/// <returns>a MySqlDataReader containing the resultset generated by the command</returns>
		public static MySqlDataReader ExecuteReader(MySqlTransaction transaction, CommandType commandType, string commandText)
		{
			//pass through the call providing null for the set of MySqlParameters
			return ExecuteReader(transaction, commandType, commandText, (MySqlParameter[])null);
		}

		/// <summary>
		/// Execute a MySqlCommand (that returns a resultset) against the specified MySqlTransaction
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///   MySqlDataReader dr = ExecuteReader(trans, CommandType.StoredProcedure, "GetOrders", new MySqlParameter("@prodid", 24));
		/// </remarks>
		/// <param name="transaction">a valid MySqlTransaction</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-MySql command</param>
		/// <param name="commandParameters">an array of MySqlParamters used to execute the command</param>
		/// <returns>a MySqlDataReader containing the resultset generated by the command</returns>
		public static MySqlDataReader ExecuteReader(MySqlTransaction transaction, CommandType commandType, string commandText, params MySqlParameter[] commandParameters)
		{
			//pass through to private overload, indicating that the connection is owned by the caller
			return ExecuteReader(transaction.Connection, transaction, commandType, commandText, commandParameters, MySqlConnectionOwnership.External);
		}

		/// <summary>
		/// Execute a stored procedure via a MySqlCommand (that returns a resultset) against the specified
		/// MySqlTransaction using the provided parameter values.  This method will query the database to discover the parameters for the 
		/// stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
		/// </summary>
		/// <remarks>
		/// This method provides no access to output parameters or the stored procedure's return value parameter.
		/// 
		/// e.g.:  
		///  MySqlDataReader dr = ExecuteReader(trans, "GetOrders", 24, 36);
		/// </remarks>
		/// <param name="transaction">a valid MySqlTransaction</param>
		/// <param name="spName">the name of the stored procedure</param>
		/// <param name="parameterValues">an array of objects to be assigned as the input values of the stored procedure</param>
		/// <returns>a MySqlDataReader containing the resultset generated by the command</returns>
		public static MySqlDataReader ExecuteReader(MySqlTransaction transaction, string spName, params object[] parameterValues)
		{
			//if we receive parameter values, we need to figure out where they go
			if ((parameterValues != null) && (parameterValues.Length > 0))
			{
				MySqlParameter[] commandParameters = MySqlHelperParameterCache.GetSpParameterSet(transaction.Connection.ConnectionString, spName);

				AssignParameterValues(commandParameters, parameterValues);

				return ExecuteReader(transaction, CommandType.StoredProcedure, spName, commandParameters);
			}
			//otherwise we can just call the SP without params
			else
			{
				return ExecuteReader(transaction, CommandType.StoredProcedure, spName);
			}
		}

		#endregion ExecuteReader

		#region ExecuteScalar

		/// <summary>
		/// Execute a MySqlCommand (that returns a 1x1 resultset and takes no parameters) against the database specified in 
		/// the connection string. 
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  int orderCount = (int)ExecuteScalar(connString, CommandType.StoredProcedure, "GetOrderCount");
		/// </remarks>
		/// <param name="connectionString">a valid connection string for a MySqlConnection</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-MySql command</param>
		/// <returns>an object containing the value in the 1x1 resultset generated by the command</returns>
		public static object ExecuteScalar(string connectionString, CommandType commandType, string commandText)
		{
			//pass through the call providing null for the set of MySqlParameters			
			return ExecuteScalar(connectionString, commandType, commandText, (MySqlParameter[])null);
		}

		/// <summary>
		/// Execute a MySqlCommand (that returns a 1x1 resultset) against the database specified in the connection string 
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  int orderCount = (int)ExecuteScalar(connString, CommandType.StoredProcedure, "GetOrderCount", new MySqlParameter("@prodid", 24));
		/// </remarks>
		/// <param name="connectionString">a valid connection string for a MySqlConnection</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-MySql command</param>
		/// <param name="commandParameters">an array of MySqlParamters used to execute the command</param>
		/// <returns>an object containing the value in the 1x1 resultset generated by the command</returns>
		public static object ExecuteScalar(string connectionString, CommandType commandType, string commandText, params MySqlParameter[] commandParameters)
		{
			//create & open a MySqlConnection, and dispose of it after we are done.
			using (MySqlConnection cn = new MySqlConnection(connectionString))
			{
				cn.Open();

				//call the overload that takes a connection in place of the connection string
				return ExecuteScalar(cn, commandType, commandText, commandParameters);
			}
		}

		/// <summary>
		/// Execute a stored procedure via a MySqlCommand (that returns a 1x1 resultset) against the database specified in 
		/// the connection string using the provided parameter values.  This method will query the database to discover the parameters for the 
		/// stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
		/// </summary>
		/// <remarks>
		/// This method provides no access to output parameters or the stored procedure's return value parameter.
		/// 
		/// e.g.:  
		///  int orderCount = (int)ExecuteScalar(connString, "GetOrderCount", 24, 36);
		/// </remarks>
		/// <param name="connectionString">a valid connection string for a MySqlConnection</param>
		/// <param name="spName">the name of the stored procedure</param>
		/// <param name="parameterValues">an array of objects to be assigned as the input values of the stored procedure</param>
		/// <returns>an object containing the value in the 1x1 resultset generated by the command</returns>
		public static object ExecuteScalar(string connectionString, string spName, params object[] parameterValues)
		{
			//if we receive parameter values, we need to figure out where they go
			if ((parameterValues != null) && (parameterValues.Length > 0))
			{
				//pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
				MySqlParameter[] commandParameters = MySqlHelperParameterCache.GetSpParameterSet(connectionString, spName);

				//assign the provided values to these parameters based on parameter order
				AssignParameterValues(commandParameters, parameterValues);

				//call the overload that takes an array of MySqlParameters
				return ExecuteScalar(connectionString, CommandType.StoredProcedure, spName, commandParameters);
			}
			//otherwise we can just call the SP without params
			else
			{
				return ExecuteScalar(connectionString, CommandType.StoredProcedure, spName);
			}
		}

		/// <summary>
		/// Execute a MySqlCommand (that returns a 1x1 resultset and takes no parameters) against the provided MySqlConnection. 
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  int orderCount = (int)ExecuteScalar(conn, CommandType.StoredProcedure, "GetOrderCount");
		/// </remarks>
		/// <param name="connection">a valid MySqlConnection</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-MySql command</param>
		/// <returns>an object containing the value in the 1x1 resultset generated by the command</returns>
		public static object ExecuteScalar(MySqlConnection connection, CommandType commandType, string commandText)
		{
			//pass through the call providing null for the set of MySqlParameters
			return ExecuteScalar(connection, commandType, commandText, (MySqlParameter[])null);
		}

		/// <summary>
		/// Execute a MySqlCommand (that returns a 1x1 resultset) against the specified MySqlConnection 
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  int orderCount = (int)ExecuteScalar(conn, CommandType.StoredProcedure, "GetOrderCount", new MySqlParameter("@prodid", 24));
		/// </remarks>
		/// <param name="connection">a valid MySqlConnection</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-MySql command</param>
		/// <param name="commandParameters">an array of MySqlParamters used to execute the command</param>
		/// <returns>an object containing the value in the 1x1 resultset generated by the command</returns>
		public static object ExecuteScalar(MySqlConnection connection, CommandType commandType, string commandText, params MySqlParameter[] commandParameters)
		{
			try
			{
				//create a command and prepare it for execution
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandTimeout = connection.ConnectionTimeout;  //leo - so setting the connecting timeout is all that we need.
				PrepareCommand(cmd, connection, (MySqlTransaction)null, commandType, commandText, commandParameters);

				//execute the command & return the results
				object retval = cmd.ExecuteScalar();

				// detach the MySqlParameters from the command object, so they can be used again.
				cmd.Parameters.Clear();
				return retval;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message + Environment.NewLine + "Query: " + commandText);
			}



		}

		/// <summary>
		/// Execute a stored procedure via a MySqlCommand (that returns a 1x1 resultset) against the specified MySqlConnection 
		/// using the provided parameter values.  This method will query the database to discover the parameters for the 
		/// stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
		/// </summary>
		/// <remarks>
		/// This method provides no access to output parameters or the stored procedure's return value parameter.
		/// 
		/// e.g.:  
		///  int orderCount = (int)ExecuteScalar(conn, "GetOrderCount", 24, 36);
		/// </remarks>
		/// <param name="connection">a valid MySqlConnection</param>
		/// <param name="spName">the name of the stored procedure</param>
		/// <param name="parameterValues">an array of objects to be assigned as the input values of the stored procedure</param>
		/// <returns>an object containing the value in the 1x1 resultset generated by the command</returns>
		public static object ExecuteScalar(MySqlConnection connection, string spName, params object[] parameterValues)
		{
			//if we receive parameter values, we need to figure out where they go
			if ((parameterValues != null) && (parameterValues.Length > 0))
			{
				//pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
				MySqlParameter[] commandParameters = MySqlHelperParameterCache.GetSpParameterSet(connection.ConnectionString, spName);

				//assign the provided values to these parameters based on parameter order
				AssignParameterValues(commandParameters, parameterValues);

				//call the overload that takes an array of MySqlParameters
				return ExecuteScalar(connection, CommandType.StoredProcedure, spName, commandParameters);
			}
			//otherwise we can just call the SP without params
			else
			{
				return ExecuteScalar(connection, CommandType.StoredProcedure, spName);
			}
		}

		/// <summary>
		/// Execute a MySqlCommand (that returns a 1x1 resultset and takes no parameters) against the provided MySqlTransaction. 
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  int orderCount = (int)ExecuteScalar(trans, CommandType.StoredProcedure, "GetOrderCount");
		/// </remarks>
		/// <param name="transaction">a valid MySqlTransaction</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-MySql command</param>
		/// <returns>an object containing the value in the 1x1 resultset generated by the command</returns>
		public static object ExecuteScalar(MySqlTransaction transaction, CommandType commandType, string commandText)
		{
			//pass through the call providing null for the set of MySqlParameters
			return ExecuteScalar(transaction, commandType, commandText, (MySqlParameter[])null);
		}

		/// <summary>
		/// Execute a MySqlCommand (that returns a 1x1 resultset) against the specified MySqlTransaction
		/// using the provided parameters.
		/// </summary>
		/// <remarks>
		/// e.g.:  
		///  int orderCount = (int)ExecuteScalar(trans, CommandType.StoredProcedure, "GetOrderCount", new MySqlParameter("@prodid", 24));
		/// </remarks>
		/// <param name="transaction">a valid MySqlTransaction</param>
		/// <param name="commandType">the CommandType (stored procedure, text, etc.)</param>
		/// <param name="commandText">the stored procedure name or T-MySql command</param>
		/// <param name="commandParameters">an array of MySqlParamters used to execute the command</param>
		/// <returns>an object containing the value in the 1x1 resultset generated by the command</returns>
		public static object ExecuteScalar(MySqlTransaction transaction, CommandType commandType, string commandText, params MySqlParameter[] commandParameters)
		{
			try
			{
				//create a command and prepare it for execution
				MySqlCommand cmd = new MySqlCommand();
				cmd.CommandTimeout = transaction.Connection.ConnectionTimeout;  //leo - so setting the connecting timeout is all that we need.
				PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters);

				//execute the command & return the results
				object retval = cmd.ExecuteScalar();

				// detach the MySqlParameters from the command object, so they can be used again.
				cmd.Parameters.Clear();
				return retval;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message + Environment.NewLine + "Query: " + commandText);
			}
		}

		/// <summary>
		/// Execute a stored procedure via a MySqlCommand (that returns a 1x1 resultset) against the specified
		/// MySqlTransaction using the provided parameter values.  This method will query the database to discover the parameters for the 
		/// stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
		/// </summary>
		/// <remarks>
		/// This method provides no access to output parameters or the stored procedure's return value parameter.
		/// 
		/// e.g.:  
		///  int orderCount = (int)ExecuteScalar(trans, "GetOrderCount", 24, 36);
		/// </remarks>
		/// <param name="transaction">a valid MySqlTransaction</param>
		/// <param name="spName">the name of the stored procedure</param>
		/// <param name="parameterValues">an array of objects to be assigned as the input values of the stored procedure</param>
		/// <returns>an object containing the value in the 1x1 resultset generated by the command</returns>
		public static object ExecuteScalar(MySqlTransaction transaction, string spName, params object[] parameterValues)
		{
			//if we receive parameter values, we need to figure out where they go
			if ((parameterValues != null) && (parameterValues.Length > 0))
			{
				//pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
				MySqlParameter[] commandParameters = MySqlHelperParameterCache.GetSpParameterSet(transaction.Connection.ConnectionString, spName);

				//assign the provided values to these parameters based on parameter order
				AssignParameterValues(commandParameters, parameterValues);

				//call the overload that takes an array of MySqlParameters
				return ExecuteScalar(transaction, CommandType.StoredProcedure, spName, commandParameters);
			}
			//otherwise we can just call the SP without params
			else
			{
				return ExecuteScalar(transaction, CommandType.StoredProcedure, spName);
			}
		}

		#endregion ExecuteScalar

		#region DataTable and DataRow convert to T
		/// <summary>
		/// DataTable convert to List<T>
		/// </summary>
		public static List<T> DataTableToT<T>(DataTable source) where T : class, new()
        {
			List<T> itemlist = null;
            if (source == null || source.Rows.Count == 0)
            {
				return itemlist;
            }
			itemlist = new List<T>();
			T item = null;
			Type targettype = typeof(T);
			Type ptype = null;
			Object value = null;
			foreach(DataRow dr in source.Rows)
            {
				item = new T();
				foreach(PropertyInfo pi in targettype.GetProperties())
                {
                    if (pi.CanWrite && source.Columns.Contains(pi.Name))
                    {
						if (!(pi.PropertyType.FullName == "System.Byte[]" && dr[pi.Name] == DBNull.Value))
						{
							ptype = Type.GetType(pi.PropertyType.FullName);
							value = Convert.ChangeType(dr[pi.Name], ptype);
							pi.SetValue(item, value, null);
						}
					}
                }
				itemlist.Add(item);
            }
			return itemlist;
        }
		/// <summary>
		/// DataRow convert to <T>
		/// </summary>
		public static T DataRowToT<T>(DataRow source) where T : class, new()
        {
			T item = null;
            if (source == null)
            {
				return item;
            }
			item = new T();
			Type targettype = typeof(T);
			Type ptype = null;
			Object value = null;

			foreach(PropertyInfo pi in targettype.GetProperties())
            {
                if (pi.CanWrite && source.Table.Columns.Contains(pi.Name)){
                    if (!(pi.PropertyType.FullName == "System.Byte[]" && source[pi.Name] == DBNull.Value))
                    {
						ptype = Type.GetType(pi.PropertyType.FullName);
						value = Convert.ChangeType(source[pi.Name], ptype);
						pi.SetValue(item, value, null);
                    }
                }
            }
			return item;
		}
		#endregion
		#region NullToMySqlNull
		public static object NullToMySqlNull(object obj)
        {
            if (obj == null)
            {
				return DBNull.Value;
			}
			return obj;
		}
        #endregion
    }

    /// <summary>
    /// MySqlHelperParameterCache provides functions to leverage a static cache of procedure parameters, and the
    /// ability to discover parameters for stored procedures at run-time.
    /// </summary>
    public sealed class MySqlHelperParameterCache
	{
		#region private methods, variables, and constructors

		//Since this class provides only static methods, make the default constructor private to prevent 
		//instances from being created with "new MySqlHelperParameterCache()".
		private MySqlHelperParameterCache() { }

		private static Hashtable paramCache = Hashtable.Synchronized(new Hashtable());

		/// <summary>
		/// resolve at run time the appropriate set of MySqlParameters for a stored procedure
		/// </summary>
		/// <param name="connectionString">a valid connection string for a MySqlConnection</param>
		/// <param name="spName">the name of the stored procedure</param>
		/// <param name="includeReturnValueParameter">whether or not to include their return value parameter</param>
		/// <returns></returns>
		private static MySqlParameter[] DiscoverSpParameterSet(string connectionString, string spName, bool includeReturnValueParameter)
		{
			using (MySqlConnection cn = new MySqlConnection(connectionString))
			using (MySqlCommand cmd = new MySqlCommand(spName, cn))
			{
				cn.Open();
				cmd.CommandTimeout = cn.ConnectionTimeout;  //leo - so setting the connecting timeout is all that we need.
				cmd.CommandType = CommandType.StoredProcedure;

				MySqlCommandBuilder.DeriveParameters(cmd);

				if (!includeReturnValueParameter)
				{
					cmd.Parameters.RemoveAt(0);
				}

				MySqlParameter[] discoveredParameters = new MySqlParameter[cmd.Parameters.Count]; ;

				cmd.Parameters.CopyTo(discoveredParameters, 0);

				return discoveredParameters;
			}
		}

		//deep copy of cached MySqlParameter array
		private static MySqlParameter[] CloneParameters(MySqlParameter[] originalParameters)
		{
			MySqlParameter[] clonedParameters = new MySqlParameter[originalParameters.Length];

			for (int i = 0, j = originalParameters.Length; i < j; i++)
			{
				clonedParameters[i] = (MySqlParameter)((ICloneable)originalParameters[i]).Clone();
			}

			return clonedParameters;
		}

		#endregion private methods, variables, and constructors

		#region caching functions

		/// <summary>
		/// add parameter array to the cache
		/// </summary>
		/// <param name="connectionString">a valid connection string for a MySqlConnection</param>
		/// <param name="commandText">the stored procedure name or T-MySql command</param>
		/// <param name="commandParameters">an array of MySqlParamters to be cached</param>
		public static void CacheParameterSet(string connectionString, string commandText, params MySqlParameter[] commandParameters)
		{
			string hashKey = connectionString + ":" + commandText;

			paramCache[hashKey] = commandParameters;
		}

		/// <summary>
		/// retrieve a parameter array from the cache
		/// </summary>
		/// <param name="connectionString">a valid connection string for a MySqlConnection</param>
		/// <param name="commandText">the stored procedure name or T-MySql command</param>
		/// <returns>an array of MySqlParamters</returns>
		public static MySqlParameter[] GetCachedParameterSet(string connectionString, string commandText)
		{
			string hashKey = connectionString + ":" + commandText;

			MySqlParameter[] cachedParameters = (MySqlParameter[])paramCache[hashKey];

			if (cachedParameters == null)
			{
				return null;
			}
			else
			{
				return CloneParameters(cachedParameters);
			}
		}

		#endregion caching functions

		#region Parameter Discovery Functions

		/// <summary>
		/// Retrieves the set of MySqlParameters appropriate for the stored procedure
		/// </summary>
		/// <remarks>
		/// This method will query the database for this information, and then store it in a cache for future requests.
		/// </remarks>
		/// <param name="connectionString">a valid connection string for a MySqlConnection</param>
		/// <param name="spName">the name of the stored procedure</param>
		/// <returns>an array of MySqlParameters</returns>
		public static MySqlParameter[] GetSpParameterSet(string connectionString, string spName)
		{
			return GetSpParameterSet(connectionString, spName, false);
		}

		/// <summary>
		/// Retrieves the set of MySqlParameters appropriate for the stored procedure
		/// </summary>
		/// <remarks>
		/// This method will query the database for this information, and then store it in a cache for future requests.
		/// </remarks>
		/// <param name="connectionString">a valid connection string for a MySqlConnection</param>
		/// <param name="spName">the name of the stored procedure</param>
		/// <param name="includeReturnValueParameter">a bool value indicating whether the return value parameter should be included in the results</param>
		/// <returns>an array of MySqlParameters</returns>
		public static MySqlParameter[] GetSpParameterSet(string connectionString, string spName, bool includeReturnValueParameter)
		{
			string hashKey = connectionString + ":" + spName + (includeReturnValueParameter ? ":include ReturnValue Parameter" : "");

			MySqlParameter[] cachedParameters;

			cachedParameters = (MySqlParameter[])paramCache[hashKey];

			if (cachedParameters == null)
			{
				cachedParameters = (MySqlParameter[])(paramCache[hashKey] = DiscoverSpParameterSet(connectionString, spName, includeReturnValueParameter));
			}

			return CloneParameters(cachedParameters);
		}

		#endregion Parameter Discovery Functions

	}
}
