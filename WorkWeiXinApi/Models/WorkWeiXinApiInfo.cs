using System.Collections.Generic;

namespace WorkWeiXinApi
{
    public class WorkWeiXinApiInfo
    {
        /// <summary>
        /// 应用编号
        /// </summary>
        public string AgentId { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        public string CorpId { get; set; }
        /// <summary>
        /// 公司秘钥
        /// </summary>
        public string CorpSecret { get; set; }
        /// <summary>
        /// 接口域名
        /// </summary>
        public string ApiDomain { get; set; }
        /// <summary>
        /// 接口地址
        /// </summary>
        public WorkWeiXinApiAddressInfo ApiAddressList { get; set; }
    }

    public class WorkWeiXinApiAddressInfo
    {
        /// <summary>
        /// 获取access_token
        /// </summary>
        public string get_access_token { get; set; }
        /// <summary>
        /// 发送消息
        /// </summary>
        public string send_message { get; set; }
    }
}
