namespace WorkWeiXinApi
{
    public class WorkWeiXinApiModels
    {
    }

    /// <summary>
    /// 获取access_token返回值类
    /// </summary>
    public class GetAccessTokenResponse
    {
        public string errcode { get; set; }
        public string errmsg { get; set; }
        public string access_token { get; set; }
    }

    /// <summary>
    /// 发送消息请求类
    /// </summary>
    public class SendMessageRequest
    {
        /// <summary>
        /// 指定接收消息的成员，成员ID列表（多个接收者用‘|’分隔，最多支持1000个）。
        ///特殊情况：指定为"@all"，则向该企业应用的全部成员发送
        /// </summary>
        public string touser { get; set; }
        /// <summary>
        ///指定接收消息的部门，部门ID列表，多个接收者用‘|’分隔，最多支持100个。
        ///当touser为"@all"时忽略本参数
        /// </summary>
        public string toparty { get; set; }
        /// <summary>
        /// 指定接收消息的标签，标签ID列表，多个接收者用‘|’分隔，最多支持100个。
        ///当touser为"@all"时忽略本参数
        /// </summary>
        public string totag { get; set; }
        /// <summary>
        /// 消息类型，此时固定为：text
        /// </summary>
        public string msgtype { get; set; }
        /// <summary>
        /// 企业应用的id，整型。企业内部开发，可在应用的设置页面查看；第三方服务商，可通过接口 获取企业授权信息 获取该参数值
        /// </summary>
        public string agentid { get; set; }
        /// <summary>
        /// 消息内容，最长不超过2048个字节，超过将截断（支持id转译）
        /// </summary>
        public SendMessageRequestText text { get; set; }
        /// <summary>
        /// 表示是否是保密消息，0表示可对外分享，1表示不能分享且内容显示水印，默认为0
        /// </summary>
        public string safe { get; set; }
        /// <summary>
        /// 	表示是否开启id转译，0表示否，1表示是，默认0。仅第三方应用需要用到，企业自建应用可以忽略。
        /// </summary>
        public string enable_id_trans { get; set; }
        /// <summary>
        /// 表示是否开启重复消息检查，0表示否，1表示是，默认0
        /// </summary>
        public string enable_duplicate_check { get; set; }
        /// <summary>
        /// 表示是否重复消息检查的时间间隔，默认1800s，最大不超过4小时
        /// </summary>
        public string duplicate_check_interval { get; set; }
    }

    public class SendMessageRequestText
    {
        public string content { get; set; }
    }

    /// <summary>
    /// 发送消息返回类
    /// </summary>
    public class SendMessageResponse
    {
        public string errcode { get; set; }
        public string errmsg { get; set; }
        public string invaliduser { get; set; }
        public string invalidparty { get; set; }
        public string invalidtag { get; set; }
        public string unlicenseduser { get; set; }
        public string msgid { get; set; }
        public string response_code { get; set; }
    }

}
