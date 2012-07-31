using System;
using System.Data;
using System.Collections.Generic;
using Model.Admin;
namespace BLL.Admin
{
	/// <summary>
	/// Account
	/// </summary>
	public partial class Account
	{
		private readonly DAL.Admin.Account dal=new DAL.Admin.Account();
		public Account()
		{}
        #region  Method

        public Model.Admin.Account GetSingleModel(string username, string md5)
        {
            return dal.GetSingleModel(username,md5);
        }

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			return dal.Exists(Id);
		}

        public bool GetLogin(string username, string md5)
        {
            return dal.GetLogin(username, md5);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Model.Admin.Account model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.Admin.Account model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Id)
		{
			
			return dal.Delete(Id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string Idlist )
		{
			return dal.DeleteList(Idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.Admin.Account GetModel(int Id)
		{
			
			return dal.GetModel(Id);
		}


		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.Admin.Account> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.Admin.Account> DataTableToList(DataTable dt)
		{
			List<Model.Admin.Account> modelList = new List<Model.Admin.Account>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Model.Admin.Account model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Model.Admin.Account();
					if(dt.Rows[n]["Id"]!=null && dt.Rows[n]["Id"].ToString()!="")
					{
						model.Id=int.Parse(dt.Rows[n]["Id"].ToString());
					}
					if(dt.Rows[n]["Account"]!=null && dt.Rows[n]["Account"].ToString()!="")
					{
					model.AccountName=dt.Rows[n]["Account"].ToString();
					}
					if(dt.Rows[n]["Email"]!=null && dt.Rows[n]["Email"].ToString()!="")
					{
					model.Email=dt.Rows[n]["Email"].ToString();
					}
					if(dt.Rows[n]["MD5Identify"]!=null && dt.Rows[n]["MD5Identify"].ToString()!="")
					{
					model.MD5Identify=dt.Rows[n]["MD5Identify"].ToString();
					}
					if(dt.Rows[n]["CreatedDate"]!=null && dt.Rows[n]["CreatedDate"].ToString()!="")
					{
						model.CreatedDate=DateTime.Parse(dt.Rows[n]["CreatedDate"].ToString());
					}
					if(dt.Rows[n]["ModifedDate"]!=null && dt.Rows[n]["ModifedDate"].ToString()!="")
					{
						model.ModifedDate=DateTime.Parse(dt.Rows[n]["ModifedDate"].ToString());
					}
					if(dt.Rows[n]["Enable"]!=null && dt.Rows[n]["Enable"].ToString()!="")
					{
						model.Enable=int.Parse(dt.Rows[n]["Enable"].ToString());
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method
	}
}

