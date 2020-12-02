using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace keshe.Model
{
    /// <summary>
    /// 实体类 UserAction -> 用户期望进行的动作
    /// </summary>
    [Serializable]
    public class UserAction
    {
        #region 私有字段
        private string _actionSource = "ReaderType"; // 来源 -> ReaderType Reader Book Borrow
        private Object _actionModel = null; // 需要进行操作的Model对象 -> Model(ReaderType、Reader、Book、Borrow)
        private string _actionType = "Add"; // 操作类型 -> Add Update Delete
        private string _actionDescription = ""; // 动作描述信息 -> 提供给用户的提示信息
        #endregion

        #region 对私有字段的封装
        public string actionSource { get => _actionSource; set => _actionSource = value; }
        public object actionModel { get => _actionModel; set => _actionModel = value; }
        public string actionType { get => _actionType; set => _actionType = value; }
        public string actionDescription { get => _actionDescription; set => _actionDescription = value; }
        #endregion

        public UserAction() { }
        public UserAction(UserAction r)
        {
            this.actionSource = r.actionSource;
            this.actionModel = this.DeepCopy<object>(r.actionModel);
            this.actionType = r.actionType;
            this.actionDescription = r.actionDescription;
        }
        /// <summary>
        /// 利用二进制序列化和反序列化实现深复制
        /// </summary>
        private T DeepCopy<T>(T obj)
        {
            object retval;
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                //序列化成流
                bf.Serialize(ms, obj);
                ms.Seek(0, SeekOrigin.Begin);
                //反序列化成对象
                retval = bf.Deserialize(ms);
                ms.Close();
            }
            return (T)retval;
        }
    }
}
