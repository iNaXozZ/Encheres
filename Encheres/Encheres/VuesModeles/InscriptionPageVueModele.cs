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
        public  void ActionPageRegistration()
        {
            User unUser = new User(Email, Photo, Password , Pseudo);
            Task.Run(async () =>
            {
                if (await _apiServicesRegistration.PostRegistrationAsync(unUser, "api/postUser"))
                {
                    auth = true;
                    User.CollClasse.Add(unUser);
                    if (unUser.Email != null && unUser.Password != null && unUser.Pseudo != null )
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            Application.Current.MainPage = new NavigationPage(new ListeEnchereEnCoursVue());
                        });
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Erreur", "Veuillez Revoir les vos champs", "OK");
                    }

                }
                else
                {
                    auth = false;
                }
            });

            #endregion
        }
    }
}
