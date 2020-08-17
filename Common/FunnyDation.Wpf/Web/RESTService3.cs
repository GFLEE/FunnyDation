using FunnyDation.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace FunnyDation.Wpf.Web
{
    public partial class RESTService
    {
        /// <summary>
        /// 远程调用
        /// </summary>
        /// <param name="url"></param>
        /// <param name="fileName"></param>
        /// <param name="method"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public string Post(string url, string fileName, string method, object[] parms)
        { 
            string _Result = string.Empty;
            HttpClient client = new HttpClient();
            Parms contract = new Parms(fileName, method, parms);
            var param_json_str = JsonConvert.SerializeObject(contract);

            HttpContent content = new StringContent(param_json_str);
            content.Headers.ContentType = new MediaTypeHeaderValue(FDConst.HTTPContent_Json)
            {
                CharSet = FDConst.Encoding_UTF8
            };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(FDConst.HTTPContent_Json));
            var res = client.PostAsync(url, content).Result;
            res.EnsureSuccessStatusCode();
            if (res.IsSuccessStatusCode)
            {
                _Result = res.Content.ReadAsStringAsync().Result;
            }
            return _Result;
        }

        class Parms
        {
            public Parms(string fileName, string method, object[] parms)
            {
                this.FileName = fileName;
                this.Method = method;
                this.Pms = parms;
            }
            public string FileName;
            public string Method;
            public object[] Pms;
        }

    }
}
