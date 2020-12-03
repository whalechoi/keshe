using keshe.DAL;
using keshe.Model;
using System;

namespace keshe.BLL
{
    public sealed class mainControler
    {
        /// <summary>
        /// 此类为主界面的控制类，仅提供静态方法，禁止继承或实例化。
        /// </summary>
        private mainControler() { }
        public static Int32 SubmitAction(UserAction action)
        {
            switch (action.actionSource)
            {
                case "ReaderType":
                    switch (action.actionType)
                    {
                        case "Add":
                            try
                            {
                                return ReaderTypeDAL.Add((ReaderType)action.actionModel);
                            }
                            catch (Exception)
                            {
                                return 0;
                            }
                        case "Update":
                            try
                            {
                                return ReaderTypeDAL.Update((ReaderType)action.actionModel);
                            }
                            catch (Exception)
                            {
                                return 0;
                            }
                        case "Delete":
                            try
                            {
                                return ReaderTypeDAL.Delete((ReaderType)action.actionModel);
                            }
                            catch (Exception)
                            {
                                return 0;
                            }
                        default:
                            throw new Exception("Error actionType!");
                    }
                case "Reader":
                    switch (action.actionType)
                    {
                        case "Add":
                            try
                            {
                                return ReaderDAL.Add((Reader)action.actionModel);
                            }
                            catch (Exception)
                            {
                                return 0;
                            }
                        case "Update":
                            try
                            {
                                return ReaderDAL.Update((Reader)action.actionModel);
                            }
                            catch (Exception)
                            {
                                return 0;
                            }
                        case "Delete":
                            try
                            {
                                return ReaderDAL.Delete((Reader)action.actionModel);
                            }
                            catch (Exception)
                            {
                                return 0;
                            }
                        default:
                            throw new Exception("Error actionType!");
                    }
                case "Book":
                    switch (action.actionType)
                    {
                        case "Add":
                            try
                            {
                                return BookDAL.Add((Book)action.actionModel);
                            }
                            catch (Exception)
                            {
                                return 0;
                            }
                        case "Update":
                            try
                            {
                                return BookDAL.Update((Book)action.actionModel);
                            }
                            catch (Exception)
                            {
                                return 0;
                            }
                        case "Delete":
                            try
                            {
                                return BookDAL.Delete((Book)action.actionModel);
                            }
                            catch (Exception)
                            {
                                return 0;
                            }
                        default:
                            throw new Exception("Error actionType!");
                    }
                case "Borrow":
                    switch (action.actionType)
                    {
                        case "Borrow":
                            try
                            {
                                return BorrowDAL.Borrow((Borrow)action.actionModel);
                            }
                            catch (Exception)
                            {
                                return 0;
                            }
                        case "Update":
                            try
                            {
                                return BorrowDAL.Update((Borrow)action.actionModel);
                            }
                            catch (Exception)
                            {
                                return 0;
                            }
                        case "Delete":
                            try
                            {
                                return BorrowDAL.Delete((Borrow)action.actionModel);
                            }
                            catch (Exception)
                            {
                                return 0;
                            }
                        case "Return":
                            try
                            {
                                return BorrowDAL.Return((Borrow)action.actionModel);
                            }
                            catch (Exception)
                            {
                                return 0;
                            }
                        case "Continue":
                            try
                            {
                                return BorrowDAL.Continue((Borrow)action.actionModel);
                            }
                            catch (Exception)
                            {
                                return 0;
                            }
                        default:
                            throw new Exception("Error actionType!");
                    }
                default:
                    throw (new Exception("Error actionSource!"));
            }
        }
    }
}
