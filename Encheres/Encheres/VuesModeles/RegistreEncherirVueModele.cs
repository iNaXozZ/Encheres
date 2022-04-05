using Encheres.Modeles;
using Encheres.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Encheres.VuesModeles
{
    class RegistreEncherirVueModele : BaseVueModele
    {
        #region Attributs
        private Enchere _monEnchere;
        private readonly Api _apiServices = new Api();
        private ObservableCollection<Encherir>_maListeDernieresEncheres;
        private User _unUser;
        private bool _gagnantIsVisible = false;
        public DecompteTimer tmps;
        #endregion

        #region Constructeur
        public RegistreEncherirVueModele(Enchere param)
        {
            _monEnchere = param;
            AfficherDernieresEncheres();
            AfficherLeGagnant();
            GetGagnantVisible(param);

        }
        #endregion

        #region Getters/Setters
        public Enchere MonEnchere
        {
            get
            { 
                return _monEnchere; 
            }
            set
            {
                SetProperty(ref _monEnchere, value);
            }
        }
        public User UnUser
        {
            get
            {
                return _unUser;
            }
            set
            {
                SetProperty(ref _unUser, value);
            }
        }
        public ObservableCollection<Encherir> MaListeDernieresEncheres
        {
            get { return _maListeDernieresEncheres; }
            set { SetProperty(ref _maListeDernieresEncheres, value); }
        }
        public bool GagnantIsVisible
        {
            get { return _gagnantIsVisible; }
            set { SetProperty(ref _gagnantIsVisible, value); }
        }

        #endregion

        #region Méthodes
        public void AfficherDernieresEncheres()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    Encherir.CollClasse.Clear();
                    MaListeDernieresEncheres = await _apiServices.GetAllAsyncByID<Encherir>("api/getLastSixOffer", Encherir.CollClasse, "Id", MonEnchere.Id);

                    Thread.Sleep(18000);
                    
                }
            });
        }

        public void GetGagnantVisible(Enchere param)
        {
            tmps = new DecompteTimer();
            DateTime datefin = param.Datefin;
            TimeSpan interval = datefin - DateTime.Now;
            tmps.Start(interval);

            if (tmps.TempsRestant <= TimeSpan.Zero)
            {
                GagnantIsVisible = true;
            }
            else
            {
                GagnantIsVisible = false;
            }
        }

        public async void AfficherLeGagnant()
        {
            UnUser = await _apiServices.GetOneAsyncByID<User>("api/getGagnant", User.CollClasse, MonEnchere.Id);
            User.CollClasse.Clear();
        }
        #endregion

    }
}
