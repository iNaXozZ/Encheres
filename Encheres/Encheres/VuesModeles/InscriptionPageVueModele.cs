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
    class InscriptionPageVueModele : BaseVueModele
    {
       
        #region Attributs
        private readonly ApiRegistration _apiServicesRegistration = new ApiRegistration();
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
                        // Si toutes les conditions sont réunies, on valide l'inscription et la connexion de l'utilisateur
                        //en le renvoyant sur sa page de profil. A Modif !!!!!
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            Application.Current.MainPage = new NavigationPage(new ListeEnchereEnCoursVue());
                        });
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

            #endregion
        }
    }
}
