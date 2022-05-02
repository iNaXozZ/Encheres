using Encheres.Modeles;
using Encheres.Services;
using Encheres.Vues;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Encheres.VuesModeles
{
    public class LoginPageVueModele : BaseVueModele
    {
        #region Attributs
        private readonly ApiAuthentification _apiServicesAuthentification = new ApiAuthentification();
        private string _password;
        private string _email;
        private bool auth = false;

        #endregion

        #region Constructeur
        public LoginPageVueModele()
        {
            CommandeButtonAuthentification = new Command(ActionPageAuthentification);
        }
        #endregion

        #region Getters/Setters
        public ICommand CommandeButtonAuthentification { get; }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        #endregion

        #region Méthodes

        /// <summary>
        /// Cette méthode permet de valider la connexion d'un utilisateur via l'appel de l'API du serveur.
        /// </summary>
        public async void ActionPageAuthentification()
        {
            //Pour éviter d'avoir une éventuelle personne connectée, on supprime l'éventuel utilisateur
            User.CollClasse.Clear();

            //Grâce à l'adresse email et le mot de passe entrés en dans le formulaire, on demande à l'API de vérifier
            //l'exactitude des informations, de récupérer les données de l'utilisateur.
            User res = await _apiServicesAuthentification.GetAuthAsync<User>
                   (_email, _password, "api/getUserByMailAndPass");

            //Selon le résultat de l'appel de l'API, on valide la connection ou non de l'utilisateur
            if (res != null)
            {
                auth = true;
                //On stock l'ID et le Pseudo de l'utilisateur dans le cache de l'application
                Storage.StockerConnexion(res.Id.ToString(), res.Pseudo.ToString());
                User.CollClasse.Add(res);

                //On valide la Connexion de l'utilisateur en effectuant le changement de page vers la page de profil
                //de l'utilisateur
                Device.BeginInvokeOnMainThread(() =>
                {
                    Application.Current.MainPage = new NavigationPage(new PageProfilVue());
                });
            }

            // Si l'API n'a pas validé la connexion de l'utilisateur, on affiche un message d'erreur
            else
            {
                auth = false;
                await Application.Current.MainPage.DisplayAlert("Erreur de login ❌", "Echec", "OK");
            }
            
        }
        #endregion
    }
}
