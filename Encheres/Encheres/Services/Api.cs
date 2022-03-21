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
    class Api
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

        ///  <summary>
        ///  Cette methode est générique
        ///  Cette méthode permet de recuperer la liste de toutes les occurences de la table.
        ///
        ///  </summary>
        ///  <typeparam name="T">la classe concernée</typeparam>
        ///  <param name="paramUrl">l'adresse de l'API</param>
        ///  <param name="collectionReturn">la collection de classe concernee</param>
        /// <param name="parameters">Dictionnary with Key = param name  and Value = param value</param>
        ///  public async void GetListe()
        /// {
        /// MaListeClients = await _apiServices.GetAllAsync<Client>("clients", Client.CollClasse);
        /// }
        ///  <returns>la liste des occurences</returns>
        public async Task<ObservableCollection<T>> GetAllAsync2<T>(string paramUrl, List<T> param, object param2)
        {


            try
            {
                string jsonString = @"{'IdTypeEnchere':'" + param2 + "'}";
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
        public async Task<bool> PostAsync<T>(T param, string paramUrl)
        {

            var jsonstring = JsonConvert.SerializeObject(param);

            try
            {
                var client = new HttpClient();
                var jsonContent = new StringContent(jsonstring, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(Constantes.BaseApiAddress + paramUrl, jsonContent);
                var content = await response.Content.ReadAsStringAsync();
                var result = content == "OK" ? true : false;
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion
    }
}
