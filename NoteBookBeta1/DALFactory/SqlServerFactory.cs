using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace DALFactory
{
    class SqlServerFactory:AbstractFactory
    {

        /// <summary>
        /// 创建抽象工厂
        /// </summary>
        /// <returns>具体工厂</returns>
        public override IDAL.IAdminInfoService CreateIAdminInfoService()
        {
            return new UserInfoServices();
        }
    }
}
