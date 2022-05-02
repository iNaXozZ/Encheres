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
    public class InscriptionPageVueModele : BaseVueModele
    {
       
        #region Attributs
        private readonly ApiRegistration _apiServicesRegistration = new ApiRegistration();
        private readonly ApiAuthentification _apiServicesAuthentification = new ApiAuthentification();
        private string _pseudo;
        private string _password;
        private string _email;
        private string _photo;
        private bool auth = false;

        #endregion

        #region Constructeur
        public InscriptionPageVueModele()
        {
            CommandeButtonRegistration = new Command(ActionPageRegistration);
        }

        #endregion

        #region Getters/Setters
        public ICommand CommandeButtonRegistration { get; }
        public string Pseudo
        {
            get
            {
                return _pseudo;
            }
            set
            {
                if (_pseudo != value)
                {
                    _pseudo = value;
                    OnPropertyChanged(nameof(Pseudo));
                }
            }
        }
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
        public string Photo
        {
            get
            {
                return _photo;
            }
            set
            {
                if (_photo != value)
                {
                    _photo = value;
                    OnPropertyChanged(nameof(Photo));
                }
            }
        }
        #endregion

        #region Méthodes

        /// <summary>
        /// Cette méthode permet via la récupération des informations émis du formulaire d'inscription, d'inscrire
        /// un utilisateur dans la base de données en interrogeant l'API. 
        /// </summary>
        public  void ActionPageRegistration()
        {
            //On instancie un utilisateur avec les informations issues du formulaire d'inscription
            User unUser = new User(Email, Photo, Password , Pseudo);

            Task.Run(async () =>
            {
                // On demande à l'API de valider l'inscription de l'utilisateur ou non
                if (await _apiServicesRegistration.PostRegistrationAsync(unUser, "api/postUser"))
                {
                    auth = true;
                    User.CollClasse.Add(unUser);

                    //On vérifie que l'utilisateur a bien un email, un mot de passe et un pseudo
                    if (unUser.Email != null && unUser.Password != null && unUser.Pseudo != null )
                    {
                        this.SeConnecter(unUser.Email, unUser.Password);
                    }

                    // Si tous les champs ne sont pas remplis, on affiche un message d'erreur lui indiquant qu'il faut revoir ses champs
                    //d'inscription
                    else
                    {
                        auth = false;
                        await App.Current.MainPage.DisplayAlert("Erreur", "Veuillez Revoir vos champs", "OK");
                    }

                }

                // Si problème lors de l'envoi de la demande vers l'API, afficher un message d'erreur demandant si il y a un 
                //problème avec l'API ?
                else
                {
                    await App.Current.MainPage.DisplayAlert("Echec", "Problème de synchronisation avec le serveur ? ", "OK");
                }
            });
        
        }

        /// <summary>
        /// /Cette méthode permet la connection de l'utilisateur après que celui-ci s'est inscrit sur l'application 
        /// </summary>
        /// <param name="Email">Récupération de l'adresse Email mis en paramètre lors de l'inscription de l'utilsateur</param>
        /// <param name="Password">Récupération du mot de passe mis en paramètre lors de l'inscription de l'utilsateur</param>
        public async void SeConnecter(string Email, string Password)
        {
            //Grâce à l'adresse email et le mot de passe entrés en dans le formulaire, on demande à l'API de vérifier
            //l'exactitude des informations, de récupérer les données de l'utilisateur.
            User res = await _apiServicesAuthentification.GetAuthAsync<User>
                   (Email, Password, "api/getUserByMailAndPass");

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
        }
        #endregion
    }
}
