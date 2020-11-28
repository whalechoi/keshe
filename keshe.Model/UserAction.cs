using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
        private Object _actionModel = null; // 需要进行操作的Model对象，Model(ReaderType、Reader、Book、Borrow)
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
        /// 使用反射对对象进行深复制
        /// </summary>
        private T DeepCopy<T>(T obj)
        {
            // string 类型不需要深复制
            if (obj == null || obj is string || obj.GetType().IsValueType) return obj;

            object retval = Activator.CreateInstance(obj.GetType());
            System.Reflection.FieldInfo[] fields = obj.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (System.Reflection.FieldInfo field in fields)
            {
                try { field.SetValue(retval, DeepCopy(field.GetValue(obj))); }
                catch { }
            }
            return (T)retval;
        }
    }
}
