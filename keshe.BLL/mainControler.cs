using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using keshe.Model;
using keshe.DAL;

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
            try
            {
                switch (action.actionSource)
                {
                    case "ReaderType":
                        switch (action.actionType)
                        {
                            case "Add":
                                return ReaderTypeDAL.Add((ReaderType)action.actionModel);
                            case "Update":
                                return ReaderTypeDAL.Update((ReaderType)action.actionModel);
                            case "Delete":
                                return ReaderTypeDAL.Delete((ReaderType)action.actionModel);
                            default:
                                throw new Exception("Error actionType!");
                        }
                    case "Reader":
                        switch (action.actionType)
                        {
                            case "Add":
                                return ReaderDAL.Add((Reader)action.actionModel);
                            case "Update":
                                return ReaderDAL.Update((Reader)action.actionModel);
                            case "Delete":
                                return ReaderDAL.Delete((Reader)action.actionModel);
                            default:
                                throw new Exception("Error actionType!");
                        }
                    case "Book":
                        switch (action.actionType)
                        {
                            case "Add":
                                return BookDAL.Add((Book)action.actionModel);
                            case "Update":
                                return BookDAL.Update((Book)action.actionModel);
                            case "Delete":
                                return BookDAL.Delete((Book)action.actionModel);
                            default:
                                throw new Exception("Error actionType!");
                        }
                    case "Borrow":
                        switch (action.actionType)
                        {
                            case "Add":
                                return BorrowDAL.Add((Borrow)action.actionModel);
                            case "Update":
                                return BorrowDAL.Update((Borrow)action.actionModel);
                            case "Delete":
                                return BorrowDAL.Delete((Borrow)action.actionModel);
                            default:
                                throw new Exception("Error actionType!");
                        }
                    default:
                        throw (new Exception("Error actionSource!"));
                }

            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
