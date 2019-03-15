using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LdCms.Web.Models
{
    /// <summary>
    /// 功能列表枚举类
    /// </summary>
    public static class PermissionEnum
    {
        /// <summary>
        /// 格式化功能代码
        /// </summary>
        /// <param name="obj">功能编辑</param>
        /// <returns></returns>
        public static string CodeFormat(object obj)
        {
            return obj.ToString().PadLeft(6, '0');
        }
        public enum Admins
        {
            所有者 = 000000
        }
        public static class 系统管理
        {
            public enum 系统设置
            {
                查看= 010101,
                编辑= 010102
            }
            public enum 数据字典
            {
                列表 = 010201,
                查看 = 010202,
                编辑 = 010203,
                编辑明细 = 010204,
                设置主建 = 010205,
            }
            public enum 操作记录
            {
                列表 = 010301,
                查看 = 010302,
                删除 = 010303,
            }
            public enum 屏蔽词
            {
                查看 = 010401,
                编辑 = 010402
            }
            public enum 系统日志
            {
                列表 = 010501,
                删除 = 010502
            }
        }
        public static class 管理员管理
        {
            public enum 操作员管理
            {
                列表 = 020101,
                查看 = 020102,
                新增 = 020103,
                编辑 = 020104,
                审核 = 020105,
                删除 = 020106,
                改密 = 020107,
                变更角色 = 020108
            }
            public enum 角色管理
            {
                列表 = 020201,
                查看 = 020202,
                新增 = 020203,
                编辑 = 020204,
                审核 = 020205,
                删除 = 020206
            }
        }
        public static class 接口管理
        {
            public enum 接口设置
            {
                查看 = 030101,
                新增 = 030102,
                删除 = 030103
            }
            public enum 帐号管理
            {
                列表 = 030201,
                查看 = 030202,
                新增 = 030203,
                编辑 = 030204,
                审核 = 030205,
                删除 = 030206,
                修改密码 = 030207,
                刷新AppSecret = 030208,
                刷新AppKey = 030209,
                新增白名单 = 030210,
                删除白名单 = 030211
            }
        }
        public static class 公司管理
        {
            public enum 资料管理
            {
                列表 = 040101,
                查看 = 040102,
                编辑 = 040103
            }
            public enum 部门管理
            {
                列表 = 040201,
                查看 = 040202,
                新增 = 040203,
                编辑 = 040204,
                审核 = 040205,
                删除 = 040206
            }
            public enum 职位管理
            {
                列表 = 040301,
                查看 = 040302,
                新增 = 040303,
                编辑 = 040304,
                审核 = 040305,
                删除 = 040306
            }
            public enum 网点管理
            {
                列表 = 040401,
                查看 = 040402,
                新增 = 040403,
                编辑 = 040404,
                审核 = 040405,
                删除 = 040406
            }
            public enum 员工管理
            {
                列表 = 040501,
                查看 = 040502,
                新增 = 040503,
                编辑 = 040504,
                审核 = 040505,
                删除 = 040506,
                改密 = 040507
            }
        }
        public static class 会员管理
        {
            public enum 等级管理
            {
                列表 = 050101,
                查看 = 050102,
                新增 = 050103,
                编辑 = 050104,
                审核 = 050105,
                删除 = 050106
            }
            public enum 会员资料
            {
                列表 = 050201,
                查看 = 050202,
                新增 = 050203,
                编辑 = 050204,
                审核 = 050205,
                删除 = 050206,
                改密 = 050207
            }
            public enum 删除的会员
            {
                列表 = 050301,
                查看 = 050302,
                还原 = 050303,
                删除 = 050304
            }
        }
        

    }
}
