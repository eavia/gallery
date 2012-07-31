using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Admin
{
	/// <summary>
	/// Account:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Account
	{
		public Account()
		{}
		#region Model
		private int _id;
		private string _account;
		private string _email;
		private string _md5identify;
        private DateTime _createddate = DateTime.Now;
		private DateTime? _modifeddate;
		private int _enable=1;

		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AccountName
		{
			set{ _account=value;}
			get{return _account;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MD5Identify
		{
			set{ _md5identify=value;}
			get{return _md5identify;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime CreatedDate
		{
			set{ _createddate=value;}
			get{return _createddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ModifedDate
		{
			set{ _modifeddate=value;}
			get{return _modifeddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Enable
		{
			set{ _enable=value;}
			get{return _enable;}
		}
		#endregion Model
	}
}

