using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;

namespace DAL.Admin
{
	/// <summary>
	/// 数据访问类:Account
	/// </summary>
	public partial class Account
	{
		public Account()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SYS_ACCOUNT");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

        public Model.Admin.Account GetSingleModel(string username, string md5)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,Account,Email,MD5Identify,CreatedDate,ModifedDate,Enable from SYS_ACCOUNT ");
            strSql.Append(" where Account=@Username and MD5Identify=@Md5");
            SqlParameter[] parameters = {
					new SqlParameter("@Username", SqlDbType.NVarChar,20),
                    new SqlParameter("@Md5", SqlDbType.NVarChar,32)
            };
            parameters[0].Value = username;
            parameters[1].Value = md5;

            Model.Admin.Account model = new Model.Admin.Account();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"] != null && ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Account"] != null && ds.Tables[0].Rows[0]["Account"].ToString() != "")
                {
                    model.AccountName = ds.Tables[0].Rows[0]["Account"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Email"] != null && ds.Tables[0].Rows[0]["Email"].ToString() != "")
                {
                    model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                }
                if (ds.Tables[0].Rows[0]["MD5Identify"] != null && ds.Tables[0].Rows[0]["MD5Identify"].ToString() != "")
                {
                    model.MD5Identify = ds.Tables[0].Rows[0]["MD5Identify"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CreatedDate"] != null && ds.Tables[0].Rows[0]["CreatedDate"].ToString() != "")
                {
                    model.CreatedDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreatedDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ModifedDate"] != null && ds.Tables[0].Rows[0]["ModifedDate"].ToString() != "")
                {
                    model.ModifedDate = DateTime.Parse(ds.Tables[0].Rows[0]["ModifedDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Enable"] != null && ds.Tables[0].Rows[0]["Enable"].ToString() != "")
                {
                    model.Enable = int.Parse(ds.Tables[0].Rows[0]["Enable"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Model.Admin.Account model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SYS_ACCOUNT(");
			strSql.Append("Account,Email,MD5Identify,CreatedDate,ModifedDate,Enable)");
			strSql.Append(" values (");
			strSql.Append("@Account,@Email,@MD5Identify,@CreatedDate,@ModifedDate,@Enable)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Account", SqlDbType.NVarChar,20),
					new SqlParameter("@Email", SqlDbType.NVarChar,255),
					new SqlParameter("@MD5Identify", SqlDbType.NChar,32),
					new SqlParameter("@CreatedDate", SqlDbType.DateTime),
					new SqlParameter("@ModifedDate", SqlDbType.DateTime),
					new SqlParameter("@Enable", SqlDbType.Int,4)};
			parameters[0].Value = model.AccountName;
			parameters[1].Value = model.Email;
            parameters[2].Value = model.MD5Identify;
			parameters[3].Value = model.CreatedDate;
			parameters[4].Value = model.ModifedDate;
			parameters[5].Value = model.Enable;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}

        public bool GetLogin(string username, string md5)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SYS_ACCOUNT");
            strSql.Append(" where Account=@Username and MD5Identify=@Md5");
            SqlParameter[] parameters = {
					new SqlParameter("@Username", SqlDbType.NVarChar,20),
                    new SqlParameter("@Md5", SqlDbType.NVarChar,32)
            };
            parameters[0].Value = username;
            parameters[1].Value = md5;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.Admin.Account model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SYS_ACCOUNT set ");
			strSql.Append("Account=@Account,");
			strSql.Append("Email=@Email,");
			strSql.Append("MD5Identify=@MD5Identify,");
			strSql.Append("CreatedDate=@CreatedDate,");
			strSql.Append("ModifedDate=@ModifedDate,");
			strSql.Append("Enable=@Enable");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Account", SqlDbType.NVarChar,20),
					new SqlParameter("@Email", SqlDbType.NVarChar,255),
					new SqlParameter("@MD5Identify", SqlDbType.NChar,32),
					new SqlParameter("@CreatedDate", SqlDbType.DateTime),
					new SqlParameter("@ModifedDate", SqlDbType.DateTime),
					new SqlParameter("@Enable", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.AccountName;
			parameters[1].Value = model.Email;
			parameters[2].Value = model.MD5Identify;
			parameters[3].Value = model.CreatedDate;
			parameters[4].Value = model.ModifedDate;
			parameters[5].Value = model.Enable;
			parameters[6].Value = model.Id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SYS_ACCOUNT ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
};
			parameters[0].Value = Id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SYS_ACCOUNT ");
			strSql.Append(" where Id in ("+Idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.Admin.Account GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,Account,Email,MD5Identify,CreatedDate,ModifedDate,Enable from SYS_ACCOUNT ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
};
			parameters[0].Value = Id;

			Model.Admin.Account model=new Model.Admin.Account();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Id"]!=null && ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Account"]!=null && ds.Tables[0].Rows[0]["Account"].ToString()!="")
				{
					model.AccountName=ds.Tables[0].Rows[0]["Account"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Email"]!=null && ds.Tables[0].Rows[0]["Email"].ToString()!="")
				{
					model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				}
				if(ds.Tables[0].Rows[0]["MD5Identify"]!=null && ds.Tables[0].Rows[0]["MD5Identify"].ToString()!="")
				{
					model.MD5Identify=ds.Tables[0].Rows[0]["MD5Identify"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CreatedDate"]!=null && ds.Tables[0].Rows[0]["CreatedDate"].ToString()!="")
				{
					model.CreatedDate=DateTime.Parse(ds.Tables[0].Rows[0]["CreatedDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ModifedDate"]!=null && ds.Tables[0].Rows[0]["ModifedDate"].ToString()!="")
				{
					model.ModifedDate=DateTime.Parse(ds.Tables[0].Rows[0]["ModifedDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Enable"]!=null && ds.Tables[0].Rows[0]["Enable"].ToString()!="")
				{
					model.Enable=int.Parse(ds.Tables[0].Rows[0]["Enable"].ToString());
				}
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id,Account,Email,MD5Identify,CreatedDate,ModifedDate,Enable ");
			strSql.Append(" FROM SYS_ACCOUNT ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" Id,Account,Email,MD5Identify,CreatedDate,ModifedDate,Enable ");
			strSql.Append(" FROM SYS_ACCOUNT ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM SYS_ACCOUNT ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.Id desc");
			}
			strSql.Append(")AS Row, T.*  from SYS_ACCOUNT T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "SYS_ACCOUNT";
			parameters[1].Value = "Id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
	}
}

