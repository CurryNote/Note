using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IDAL;
using DALFactory;
using Model;


namespace BLL
{
    public class AdminInfoManage
    {
        /// <summary>
        /// 创建抽象工厂
        /// </summary>
        static AbstractFactory Factory = AbstractFactory.CreateFactory();
        static IAdminInfoService Iais = Factory.CreateIAdminInfoService();

        public static AdminInfo SelectAdminInfo(AdminInfo admin) {
            return Iais.SelectAdminInfo(admin);
        }
    
    }
}
