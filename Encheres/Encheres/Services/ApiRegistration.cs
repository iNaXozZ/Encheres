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
        #region Attributs

        private string _message;
        #endregion

        #region Getters/Setters
        public string Message { get => _message; set => _message = value; }
        #endregion

        #region Methodes
        /// <summary>
        /// Cette méthode inscrit via un formulaire de champs, un utilisateur dans la BDD
        /// </summary>
        /// <param name="unUser">Correspond aux éléments récupérés d'un object de la classe User</param>
        /// <param name="paramUrl">Correspond à l'adresse de l'API</param>
        /// <returns></returns>
        public async Task<bool> PostRegistrationAsync(User unUser, string paramUrl)
        {

            var jsonstring = JsonConvert.SerializeObject(unUser);
            try
            {
                var client = new HttpClient();
                var jsonContent = new StringContent(jsonstring, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(Constantes.BaseApiAddress + paramUrl, jsonContent);
                var content = await response.Content.ReadAsStringAsync();
                _message = content;
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
