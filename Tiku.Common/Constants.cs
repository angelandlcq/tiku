using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TiKu.Common
{

    /// <summary>
    /// 常量类
    /// </summary>
    public static class Constants
    {

        /// <summary>
        /// 数据库连接Key
        /// </summary>
        public const string DB_CONNECTION_KEY = "DB_CONNECTION_KEY";

        #region Admin
        /// <summary>
        /// Admin
        /// </summary>
        public static class ADMIN
        {
            #region 状态
            public static class STATE
            {

                /// <summary>
                /// 
                /// </summary>
                public const int UNENABLE = 0;

                /// <summary>
                /// 激活
                /// </summary>
                public const int ACTIVE = 1;

                /// <summary>
                /// 锁定
                /// </summary>
                public const int LOCK = 2;
            }
            #endregion

            #region Cookie
            /// <summary>
            /// Cookie
            /// </summary>
            public class COOKIE
            {
                /// <summary>
                ///Admin登陆Cookie
                /// </summary>
                public const string COOKIE_SESSION = "__AdminSessionId";
            }
            #endregion

            /// <summary>
            /// 上传文件目录
            /// </summary>
            public const string UPLOAD_PATH = "/upload/";
        }
        #endregion

        #region 通用标示
        public class Common
        {
            /// <summary>
            /// 删除标示 1
            /// </summary>
            public const int DELETE = 1;

            /// <summary>
            /// 默认值 0，正常
            /// </summary>
            public const int NORMAL = 0;

            /// <summary>
            /// 1.启用
            /// </summary>
            public const int ENABLE = 1;

            /// <summary>
            /// 0.禁用
            /// </summary>
            public const int DISABLE = 0;


            /// <summary>
            /// 0、待审核
            /// </summary>
            public const int AUDITING = 0;

            /// <summary>
            /// 1、审核通过
            /// </summary>
            public const int POST = 1;

            /// <summary>
            /// 2、冻结账户
            /// </summary>
            public const int LOCK = 2;
        }
        #endregion

        #region CACHE
        /// <summary>
        /// 缓存key
        /// </summary>
        public static class CACHE_KEY
        {
            /// <summary>
            /// 网站配置信息缓存key
            /// </summary>
            public const string WEBSITESET_CACHE_KEY = "WEBSITESET_CACHE_KEY";

            /// <summary>
            /// 管理员角色信息缓存key
            /// </summary>
            public const string _CACHE_ADMIN_ROLE = "_CACHE_ADMIN_ROLE";

            /// <summary>
            /// 广告位
            /// </summary>
            public const string _CACHE_ADVERTOR_PALCE_KEY = "_CACHE_ADVERTOR_PALCE_KEY";


            /// <summary>
            /// 课程分类缓存
            /// </summary>
            public const string _CACHE_COURSE_CATEGORY_KEY = "_CACHE_COURSE_CATEGORY_KEY";

            /// <summary>
            /// 数据库表缓存
            /// </summary>
            public const string _CACHE_DATABASE_TABLES_KEY = "_CACHE_DATABASE_TABLES_KEY";
        }
        #endregion

        #region Encrypt
        /// <summary>
        /// 加密常量
        /// </summary>
        public class Encrypt
        {
            /// <summary>
            /// 对称加密
            /// </summary>
            public class DES
            {
                /// <summary>
                /// 对称加密key
                /// </summary>
                public const string ENCRYPT_KEY = "#!&%$zXp79256";
            }

            /// <summary>
            /// 非对称加密
            /// </summary>
            public class AES
            {
                public const string ENCRYPT_KEY = "%@&%$zXp98576";
            }
        }
        #endregion

        #region User Constants
        /// <summary>
        /// 会员常量
        /// </summary>
        public class USER
        {
            #region 状态
            /// <summary>
            /// 状态
            /// </summary>
            public static class STATE
            {
                /// <summary>
                /// 0 未验证
                /// </summary>
                public const int VERIFYING = 0;

                /// <summary>
                /// 1 验证通过
                /// </summary>
                public const int POST = 1;

                /// <summary>
                /// 2 锁定
                /// </summary>
                public const int LOCK = 2;
            }
            #endregion
        }
        #endregion

        #region Agent Constants
        /// <summary>
        /// 代理商
        /// </summary>
        public static class AGENT
        {

            /// <summary>
            /// 代理商回话Cookie
            /// </summary>
            public const string AGENT_SESSION_ID = "__AgentSessionId";

            /// <summary>
            /// 状态
            /// </summary>
            public class STATE
            {
                //0、待审核
                public const int AUDITING = 0;

                /// <summary>
                ///1、审核通过
                /// </summary>
                public const int POST = 1;

                /// <summary>
                /// 2/账号冻结
                /// </summary>
                public const int LOCK = 2;
            }
        }
        #endregion


        #region 试题
        /// <summary>
        /// 试题
        /// </summary>
        public class QUESTION
        {
            /// <summary>
            /// 题型
            /// </summary>
            public class QTYPE
            {
                /// <summary>
                /// 1、单选
                /// </summary>
                public const int SINGLE_SELECTION = 1;

                /// <summary>
                /// 2、多选
                /// </summary>
                public const int MULTI_SELECTION = 2;

                /// <summary>
                /// 3、判断
                /// </summary>
                public const int JUDGE = 3;

                /// <summary>
                /// 4、简答
                /// </summary>
                public const int SHORT_ANSWER = 4;

                /// <summary>
                /// 5、一题多问 材料分析
                /// </summary>
                public const int MATERIAL = 5;

                /// <summary>
                /// 6、一题多问：单选
                /// </summary>
                public const int MATERIAL_SINGLE_SELECTION = 6;

                /// <summary>
                /// 7、一题多问：多选
                /// </summary>
                public const int MATERIAL_MULTI_SELECTION = 7;

                /// <summary>
                /// 8、一题多问:判断
                /// </summary>
                public const int MATERIAL_JUDGE = 8;

                /// <summary>
                /// 9、一题多问:简答
                /// </summary>
                public const int MATERIAL_SHORT_ANSWER = 9;
            }
        }
        #endregion
    }
}