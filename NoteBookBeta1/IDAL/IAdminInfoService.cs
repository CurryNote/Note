using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace IDAL
{
    public interface IAdminInfoService
    {
        /// <summary>
        /// 验证管理员用户名密码
        /// </summary>
        /// <param name="AdminInfo">管理员信息</param>
        /// <returns>判断返回的admininfo是否为空，不为空则登陆成功</returns>
        AdminInfo SelectAdminInfo(AdminInfo admininfo);

        /// <summary>
        /// 新增管理员
        /// </summary>
        /// <param name="admininfo">管理员信息</param>
        /// <returns>受影响的行数</returns>
        int InsertAdminInfo(AdminInfo admininfo);

        /// <summary>
        /// 查询所有管理员
        /// </summary>
        /// <returns>管理员集合</returns>
        List<AdminInfo> SelectAllAdminInfo();

        /// <summary>
        /// 修改管理员信息
        /// </summary>
        /// <param name="admininfo">管理员信息</param>
        /// <returns>受影响的行数</returns>
        int UpdateAdminInfo(AdminInfo admininfo);

        /// <summary>
        /// 注销管理员
        /// </summary>
        /// <param name="admininfo">管理员信息</param>
        /// <returns>受影响的行数</returns>
        int DeleteAdminInfo(AdminInfo admininfo);
    }
}
