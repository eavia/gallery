using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class Images
    {
        private DAL.Images dal = new DAL.Images();

        public bool AddImage(Model.Image model)
        {

            return dal.Add(model)==1;
        }

        public Model.Image GetImageById(int id)
        {
            return dal.GetModel(id);
        }



        public DataTable GetList(string where)
        {
            
            return dal.GetList(where).Tables[0];
        }

        public DataTable GetPage(string where,string order, int PageSize, int Page)
        {
            if (Page > 0)
            {
                return dal.GetPage(where, order, PageSize, Page);
            }
            else
            {
                return dal.GetPage(where, order, PageSize, 1);
            }
        }

        public int GetRowCount(int gid)
        {
            return dal.GetRowCount(gid);
        }

        public bool RemoveImage(int id)
        {
            return (dal.Delete(id));
        }

        public SqlDataReader GetPageData(int gid,int begin, int end)
        {
            return dal.GetPageData(gid, begin, end);
        }
    }
}
