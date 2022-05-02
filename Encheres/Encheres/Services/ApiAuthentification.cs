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
    public class ApiAuthentification
    {
        #region Methodes
        /// <summary>
        /// Cette méthode permet l'authentification d'un utilisateur
        /// </summary>
        /// <typeparam name="T">Classe à la classe user concernée</typeparam>
        /// <param name="_email">Paramètre correspondant à l'email</param>
        /// <param name="_password">Paramètre correspondant au mot de passe</param>
        /// <param name="paramUrl">Correspond à l'adresse de l'API</param>
        /// Cette méthode va vérifier que dans la BDD que les informations sur le MDP et l'eamil donnés correspondent à un utilisateur inscrit dans la BDD
        /// <returns></returns>
        public async Task<T> GetAuthAsync<T>(string _email, string _password, string paramUrl)
        {
            
            try
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
            catch(Exception ex)
            {
                return default (T);
            }
        }
        #endregion
    }
}
