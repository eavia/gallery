using System;
namespace Model
{
    /// <summary>
    /// Images:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Image
    {
        public Image()
        { }
        #region Model
        private int _id;
        private string _title;
        private string _descrption;
        private DateTime _updateddate;
        private int? _userid;
        private int? _gallery;
        private byte[] _data;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Descrption
        {
            set { _descrption = value; }
            get { return _descrption; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime UpdatedDate
        {
            set { _updateddate = value; }
            get { return _updateddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Gallery
        {
            set { _gallery = value; }
            get { return _gallery; }
        }
        /// <summary>
        /// 
        /// </summary>
        public byte[] Data
        {
            set { _data = value; }
            get { return _data; }
        }
        #endregion Model

    }
}

