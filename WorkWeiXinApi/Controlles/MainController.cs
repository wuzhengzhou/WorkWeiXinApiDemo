using Microsoft.AspNetCore.Mvc;
using WorkWeiXinApi.Data;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using System;
using Microsoft.Extensions.Options;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace WorkWeiXinApi.Controlles
{

    [ApiController]
    public class MainController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly BuickContext _buickContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly WorkWeiXinApiInfo _workWeiXinApiInfo;
        private readonly DbHandler _dbHandler;
        private readonly MainFunction _mainFunction;

        public MainController(IConfiguration configuration, BuickContext buickContext,IWebHostEnvironment webHostEnvironment,IOptions<WorkWeiXinApiInfo> workWeiXinApiInfoOption)
        {
            _configuration = configuration;
            _buickContext = buickContext;
            _webHostEnvironment = webHostEnvironment;
            _workWeiXinApiInfo = workWeiXinApiInfoOption.Value;
            _dbHandler = new DbHandler(_configuration, _buickContext, _webHostEnvironment);
            _mainFunction = new MainFunction(_workWeiXinApiInfo, _configuration, _buickContext, _webHostEnvironment);
        }

        [Route("api/get_accesstoken")]
        [HttpOptions]
        public IActionResult GetAccessToken()
        {
            return Ok();
        }


        [Route("api/get_accesstoken")]
        [HttpPost]
        public async Task<IActionResult> GetAccessToken(string name)
        {
            try
            {
                var res =await _mainFunction.GetAccessToken(name);
                
                return Ok(new Dictionary<string, object>() {
                    { "message","success"},
                    { "result",res}
                });
            }
            catch (Exception ex)
            {
                return Ok(new Dictionary<string, object>() {
                    {"message","fail" },
                    {"result",ex }
                });
            }
        }



        [Route("api/send_message")]
        [HttpPost]
        public async Task<IActionResult> SendMessage(string token_name)
        {
            
            var access_token = await _mainFunction.GetAccessToken(token_name);

            var result = await _mainFunction.SendMessage(access_token);

            return Ok(new Dictionary<string, object>() {
                { "message","success" },
                { "result", result }
            });
        }
    }
}
