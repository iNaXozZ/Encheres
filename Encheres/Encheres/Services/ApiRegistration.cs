using Encheres.Modeles;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Encheres.Services
{
    class ApiRegistration
    {
        #region Methodes
        public async Task<bool> PostRegistrationAsync(User unUser, string paramUrl)
        {

            var jsonstring = JsonConvert.SerializeObject(unUser);
            try
            {
                var client = new HttpClient();
                var jsonContent = new StringContent(jsonstring, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(Constantes.BaseApiAddress + paramUrl, jsonContent);
                var content = await response.Content.ReadAsStringAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion
    }
}
