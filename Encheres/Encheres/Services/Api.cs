using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Encheres.Services
{
    public class Api
    {
        #region Methodes
        /// <summary>
        /// Cette methode est générique
        /// Cette méthode permet de recuperer la liste de toutes les occurences de la table.
        /// 
        /// </summary>
        /// <typeparam name="T">la classe concernée</typeparam>
        /// <param name="paramUrl">l'adresse de l'API</param>
        /// <param name="param">la collection de classe concernee</param>
        /// public async void GetListe()
        ///{
        ///MaListeClients = await _apiServices.GetAllAsync<Client>("api/clients", Client.CollClasse);
        ///}
        /// <returns>la liste des occurences</returns>
        public async Task<ObservableCollection<T>> GetAllAsync<T>(string paramUrl, List<T> param)
        {
            try
            {
                var clientHttp = new HttpClient();
                var json = await clientHttp.GetStringAsync(Constantes.BaseApiAddress + paramUrl);
                JsonConvert.DeserializeObject<List<T>>(json);
                return GestionCollection.GetListes<T>(param);
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        /// <summary>
        /// Cette méthode est générique
        /// Elle permet de récupérer la liste de toutes les occurences de la table selon l'id de l'object qui sera passsé en paramètre
        /// </summary>
        /// <typeparam name="T">La classe concernée</typeparam>
        /// <param name="paramUrl">L'adresse de l'API</param>
        /// <param name="param">la collection de classe concernee</param>
        /// <param name="element">Le nom de l'attribut "id" de l'object que l'on veut sélectionner</param>
        /// <param name="paramId">Correspond à l'id de l'object </param>
        /// <returns>La liste des occurrences selon l'id de l'objetc passé en paramètre</returns>
        public async Task<ObservableCollection<T>> GetAllAsyncByID<T>(string paramUrl, List<T> param, string element, object paramId)
        {


            try
            {
                string jsonString = @"{'"+element+"':'" + paramId + "'}";
                JObject getResult = JObject.Parse(jsonString);
                var clientHttp = new HttpClient();
                var jsonContent = new StringContent(getResult.ToString(), Encoding.UTF8, "application/json");
                var response = await clientHttp.PostAsync(Constantes.BaseApiAddress + paramUrl, jsonContent);
                var json = await response.Content.ReadAsStringAsync();
                JsonConvert.DeserializeObject<List<T>>(json);
                return GestionCollection.GetListes<T>(param);
            }
            catch (Exception)
            {
                return null;
            }
        } 

        ///  <summary>
        ///  Cette methode est générique
        ///  Cette méthode permet de recuperer la liste de toutes les occurences de la table.
        ///
        ///  </summary>
        ///  <typeparam name="T">la classe concernée</typeparam>
        ///  <param name="paramUrl">l'adresse de l'API</param>
        ///  <param name="paramId">Correspond à l'Id de l'object</param>
        /// <param name="param2">correspond à l'id de l'objet
        ///  <returns>la liste des occurences selon l'id  du type de l'enchère</returns>
        public async Task<T> GetOneAsyncByID<T>(string paramUrl, List<T> param, object paramId)
        {


            try
            {
                string jsonString = @"{'Id':'" + paramId + "'}";
                JObject getResult = JObject.Parse(jsonString);
                var clientHttp = new HttpClient();
                var jsonContent = new StringContent(getResult.ToString(), Encoding.UTF8, "application/json");
                var response = await clientHttp.PostAsync(Constantes.BaseApiAddress + paramUrl, jsonContent);
                var json = await response.Content.ReadAsStringAsync();
                T res = JsonConvert.DeserializeObject<T>(json);
                return res;
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        /// <summary>
        /// Cette méthode permet d'inscrire des éléments dans la BDD
        /// </summary>
        /// <typeparam name="T">Correspond à la classe concernée</typeparam>
        /// <param name="param"></param>
        /// <param name="paramUrl">Correspond à l'adresse de l'API</param>
        /// <returns>L'inscription de l'object dans la BDD</returns>
        public async Task<int> PostAsync<T>(T param, string paramUrl)
        {

            var jsonstring = JsonConvert.SerializeObject(param);
            int id;
            try
            {
                var client = new HttpClient();
                var jsonContent = new StringContent(jsonstring, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(Constantes.BaseApiAddress + paramUrl, jsonContent);
                var content = await response.Content.ReadAsStringAsync();
                var result = int.TryParse(content, out id) ? id : 0;
                return result;
            }
            catch (Exception ex)
            {
                return 0 ;
            }
        }

        #endregion
    }
}
