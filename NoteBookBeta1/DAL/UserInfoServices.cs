using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAL;
using Model;

namespace DAL
{
    public class UserInfoServices:IAdminInfoService
    {
        /// <summary>
        /// 实例化DBHelper
        /// </summary>
        DBHelper db = DBHelper.getInstance();

        public AdminInfo SelectAdminInfo(AdminInfo admininfo)
        {
             AdminInfo admin = new AdminInfo();
             return admin;
        }

        public int InsertAdminInfo(AdminInfo admininfo)
        {
            return 0;
        }

        public List<AdminInfo> SelectAllAdminInfo()
        {
            List<AdminInfo> adminlist = new List<AdminInfo>();
            return adminlist;
        }

        public int UpdateAdminInfo(AdminInfo admininfo)
        {
            return 0;
        }

        public int DeleteAdminInfo(AdminInfo admininfo)
        {
            return 0;
        }
    }
}
