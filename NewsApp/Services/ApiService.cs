using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsApp.Models;
using Newtonsoft.Json;

namespace NewsApp.Services
{
    public class ApiService
    {

        public async Task<Root> GetNews(string categoryName)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("https://gnews.io/api/v4/top-headlines?token=46d9b5018523fa1dbedbc9004434d41c&topic="+categoryName);

            //deserializtion
           return JsonConvert.DeserializeObject<Root>(response);
        }
    }
}
