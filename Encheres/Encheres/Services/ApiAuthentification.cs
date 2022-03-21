using Encheres.Modeles;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Encheres.Services
{
    class ApiAuthentification
    {
        #region Methodes
        public async Task<T> GetAuthAsync<T>(string _email, string _password, string paramUrl)
        {
            
                string jsonString = @"{'Email':'" + _email + "', 'Password':'" + _password + "'}";
                var getResult = JObject.Parse(jsonString);

                var clientHttp = new HttpClient();
                var jsonContent = new StringContent(getResult.ToString(), Encoding.UTF8, "application/json");

                var response = await clientHttp.PostAsync(Constantes.BaseApiAddress + paramUrl, jsonContent);
                var json = await response.Content.ReadAsStringAsync();
                T res = JsonConvert.DeserializeObject<T>(json);
                return res;
            
        }
        #endregion
    }
}
