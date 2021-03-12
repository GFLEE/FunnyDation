using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunnyDation.Common.Service.AppSetting
{
    public class AppSettingService : IAppSettingService
    {
        IConfiguration Configuration;

        public AppSettingService()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json").Build();

        }
        public AppSettingService(IConfiguration configuration)
        {
            this.Configuration = configuration;
            _items = new Dictionary<string, string>();
            var _Apps = configuration.GetSection("AppSettings").GetChildren();
            foreach (var s in _Apps)
            {
                _items.Add(s.Key, s.Value);
            }
        }

        Dictionary<string, string> _items;

        public string GetAppSetting(string key)
        {
            throw new NotImplementedException();
        }

        public string GetConnectionString(string key)
        {
            return Configuration.GetConnectionString(key);
        }

    }
}
