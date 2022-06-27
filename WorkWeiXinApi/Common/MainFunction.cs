namespace WorkWeiXinApi
{
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.Threading.Tasks;
    using WorkWeiXinApi.Data;
    using Microsoft.AspNetCore.Hosting;
    using System;
    using WorkWeiXinApi.Model;
    public class MainFunction
    {
        private readonly WorkWeiXinApiInfo _workWeiXinApiInfo;
        private readonly IConfiguration _configuration;
        private readonly BuickContext _buickContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly DbHandler _dbHandler;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="workWeiXinApiInfo">api相关信息</param>
        /// <param name="configuration">注册信息</param>
        /// <param name="buickContext">数据库连接</param>
        /// <param name="webHostEnvironment"></param>
        public MainFunction(WorkWeiXinApiInfo workWeiXinApiInfo,IConfiguration configuration, BuickContext buickContext, IWebHostEnvironment webHostEnvironment)
        {
            _workWeiXinApiInfo = workWeiXinApiInfo;
            _configuration = configuration;
            _buickContext = buickContext;
            _webHostEnvironment = webHostEnvironment;
            _dbHandler = new DbHandler(_configuration, _buickContext, _webHostEnvironment);
        }
        /// <summary>
        /// 获取access_token
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<string> GetAccessToken(string name)
        {
            var entity = _dbHandler.GetAccessToken(name);

            if (entity != null && entity.Exprise_In > DateTime.Now)
            {
                return entity.Access_Token;
            }  

            if (_workWeiXinApiInfo != null)
            {
                string url = _workWeiXinApiInfo.ApiDomain + _workWeiXinApiInfo.ApiAddressList.get_access_token + "?corpid=" + _workWeiXinApiInfo.CorpId + "&corpsecret=" + _workWeiXinApiInfo.CorpSecret;

                GetAccessTokenResponse res = JsonConvert.DeserializeObject<GetAccessTokenResponse>(await HttpTools.DoGet(url));

                if (res != null && res.errcode == "0" && res.errmsg == "ok")
                {
                    if (entity == null)
                    {
                        WorkWeiXinApiAccessToken token = new WorkWeiXinApiAccessToken();
                        token.Id = Guid.NewGuid();
                        token.Access_Token = res.access_token;
                        token.Create_Time = DateTime.Now;
                        token.Exprise_In = DateTime.Now.AddMinutes(20);
                        token.Name = name;
                        _dbHandler.AddAccessToken(token);
                    }
                    else
                    {
                        entity.Access_Token = res.access_token;
                        entity.Create_Time = DateTime.Now;
                        entity.Exprise_In = DateTime.Now.AddMinutes(20);
                        _dbHandler.UpdateAccessToken(entity);
                    }

                    return res.access_token;
                }

            }

            return null;
        }

        /// <summary>
        /// 发送提醒消息
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns></returns>
        public async Task<string> SendMessage(string access_token)
        {
            if (_workWeiXinApiInfo != null)
            {
                string url = _workWeiXinApiInfo.ApiDomain + _workWeiXinApiInfo.ApiAddressList.send_message + "?access_token=" + access_token;

                SendMessageRequest request = new SendMessageRequest();

                request.touser = "wuzhengzhou";
                request.toparty = "1";
                request.msgtype = "text";
                request.agentid = _workWeiXinApiInfo.AgentId;

                SendMessageRequestText text = new SendMessageRequestText();

                text.content = "汽车之家、懂车帝等leads服务停止运行，请联系技术同事检查。";

                request.text = text;

                var res = await HttpTools.DoPost<JObject>(url, request);

                return res.ToString();
            }
            return "";
        }
    }
}
