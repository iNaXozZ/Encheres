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
        public async void ActionPageAuthentification()
        {
            User.CollClasse.Clear();
            User res = await _apiServicesAuthentification.GetAuthAsync<User>
                   (_email, _password, "api/getUserByMailAndPass");
            User.CollClasse.Add(res);
            if (res != null)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    Application.Current.MainPage = new NavigationPage(new ListeEnchereEnCoursVue());
                });
            }
        }
        #endregion
    }
}
