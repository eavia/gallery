using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;
using Model;//Please add references
namespace DAL
{
    /// <summary>
    /// 数据访问类:APP_IMAGES
    /// </summary>
    public class Images
    {
        public Images()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from APP_IMAGES");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
};

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Image model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into APP_IMAGES(");
            strSql.Append("Title,Descrption,UpdatedDate,UserID,Gallery,Data)");
            strSql.Append(" values (");
            strSql.Append("@Title,@Descrption,@UpdatedDate,@UserID,@Gallery,@Data)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@Descrption", SqlDbType.NVarChar,500),
					new SqlParameter("@UpdatedDate", SqlDbType.DateTime),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@Gallery", SqlDbType.Int,4),
					new SqlParameter("@Data", SqlDbType.VarBinary)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.Descrption;
            parameters[2].Value = model.UpdatedDate;
            parameters[3].Value = model.UserID;
            parameters[4].Value = model.Gallery;
            parameters[5].Value = model.Data;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Image model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update APP_IMAGES set ");
            strSql.Append("Title=@Title,");
            strSql.Append("Descrption=@Descrption,");
            strSql.Append("UpdatedDate=@UpdatedDate,");
            strSql.Append("UserID=@UserID,");
            strSql.Append("Gallery=@Gallery,");
            strSql.Append("Data=@Data");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.NVarChar,50),
					new SqlParameter("@Descrption", SqlDbType.NVarChar,500),
					new SqlParameter("@UpdatedDate", SqlDbType.DateTime),
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@Gallery", SqlDbType.Int,4),
					new SqlParameter("@Data", SqlDbType.VarBinary)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.Descrption;
            parameters[3].Value = model.UpdatedDate;
            parameters[4].Value = model.UserID;
            parameters[5].Value = model.Gallery;
            parameters[6].Value = model.Data;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from APP_IMAGES ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
            parameters[0].Value = ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from APP_IMAGES ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public Image GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Title,Descrption,UpdatedDate,UserID,Gallery,Data from APP_IMAGES ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
            parameters[0].Value = ID;

            Image model = new Image();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                model.Descrption = ds.Tables[0].Rows[0]["Descrption"].ToString();
                if (ds.Tables[0].Rows[0]["UpdatedDate"].ToString() != "")
                {
                    model.UpdatedDate = DateTime.Parse(ds.Tables[0].Rows[0]["UpdatedDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Gallery"].ToString() != "")
                {
                    model.Gallery = int.Parse(ds.Tables[0].Rows[0]["Gallery"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Data"].ToString() != "")
                {
                    model.Data = (byte[])ds.Tables[0].Rows[0]["Data"];
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,Title,Descrption,UpdatedDate,UserID,Gallery,Data ");
            strSql.Append(" FROM APP_IMAGES ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataTable GetPage(string where, string orderfield, int PageSize, int Page)
        {
            int jump = PageSize * (Page - 1);

            StringBuilder outerSQL = new StringBuilder(@"select TOP #PageSize# t2.* FROM (select ID,Title,Descrption,UpdatedDate,UserID,Gallery,Data 
                                                                    FROM APP_IMAGES where ID not in(select TOP #Jump# ID FROM APP_IMAGES where 1=1 #where# order by #orderby#) #where# ) T2 order by t2.#orderby#");
            outerSQL.Replace("#Jump#", jump.ToString());
            outerSQL.Replace("#where#", where);
            outerSQL.Replace("#orderby#", orderfield);
            outerSQL.Replace("#PageSize#", PageSize.ToString());
            return DbHelperSQL.Query(outerSQL.ToString()).Tables[0];
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ID,Title,Descrption,UpdatedDate,UserID,Gallery,Data ");
            strSql.Append(" FROM APP_IMAGES ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  Method

        public int GetRowCount(int gid)
        {
            StringBuilder sql = new StringBuilder("SELECT count(*) FROM APP_IMAGES Where gallery=@gid@;");
            sql.Replace("@gid@",gid.ToString());
            return (int)DbHelperSQL.GetSingle(sql.ToString());
        }

        public SqlDataReader GetPageData(int gid,int begin, int end)
        {
            return DbHelperSQL.RunProcedure("SP_PhotoList", new SqlParameter[] { new SqlParameter("@galleryId", gid), new SqlParameter("@startIndex", begin), new SqlParameter("@endIndex", end) });
        }
    }
}