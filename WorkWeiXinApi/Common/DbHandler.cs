namespace WorkWeiXinApi
{
    using Microsoft.Extensions.Configuration;
    using WorkWeiXinApi.Data;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using WorkWeiXinApi.Model;
    using System;
    public class DbHandler
    {
        private readonly IConfiguration _configuration;

        private readonly BuickContext _buickContext;

        private readonly IWebHostEnvironment _environment;

        public DbHandler(IConfiguration configuration, BuickContext buickContext, IWebHostEnvironment environment)
        {
            _configuration = configuration;
            _buickContext = buickContext;
            _environment = environment;
        }

        /// <summary>
        /// 获取access_token
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public WorkWeiXinApiAccessToken GetAccessToken(string name)
        {
            return _buickContext.WorkWeiXinApiAccessTokens.AsNoTracking().ToList().Where(n => n.Name == name).FirstOrDefault();
        }

        /// <summary>
        /// 更新access_token
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public WorkWeiXinApiAccessToken UpdateAccessToken(WorkWeiXinApiAccessToken entity)
        {
            _buickContext.Update(entity);
            _buickContext.SaveChanges();
            return entity;
        }

        /// <summary>
        /// 添加access_token
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public WorkWeiXinApiAccessToken AddAccessToken(WorkWeiXinApiAccessToken entity)
        {
            _buickContext.Add(entity);
            _buickContext.SaveChanges();
            return entity;
        }
    }
}
