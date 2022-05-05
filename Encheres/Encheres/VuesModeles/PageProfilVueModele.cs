using Encheres.Modeles;
using Encheres.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace Encheres.VuesModeles
{
    public class PageProfilVueModele : BaseVueModele
    {
        private string _idUser;
        private readonly Api _apiServices = new Api();
        private User _leUser;

        public PageProfilVueModele()
        {
            GetUser();
        }
        public string IdUser { get => _idUser; set => _idUser = value; }
        public User LeUser
        {
            get { return _leUser; }
            set { SetProperty(ref _leUser, value); }
        }
        
        /// <summary>
        /// Cette méthode permet grâce à l'ID de l'utilisateur de récupérer les informations issues de l'utilisateur en appelant l'API
        /// </summary>
        public async void GetUser()
        {
            IdUser = await SecureStorage.GetAsync("ID");
            LeUser = await _apiServices.GetOneAsyncByID<User>("api/getUser", User.CollClasse, IdUser.ToString());
        }

    }
}
