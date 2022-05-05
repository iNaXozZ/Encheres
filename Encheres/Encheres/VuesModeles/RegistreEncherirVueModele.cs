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
    public class RegistreEncherirVueModele : BaseVueModele
    {
        #region Attributs
        private Enchere _monEnchere;
        private readonly Api _apiServices = new Api();
        private ObservableCollection<Encherir>_maListeDernieresEncheres;
        private User _unUser;
        private bool _gagnantIsVisible = false;
        public DecompteTimer tmps;
        public bool OnCancel = false;
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

        /// <summary>
        /// Cette méthode permet grâce à l'appel de l'API d'afficher le pseudo et le prix de l'enchère des 6 dernières enchérisseurs
        /// </summary>
        public void AfficherDernieresEncheres()
        {
            Task.Run(async () =>
            {
                while (OnCancel == false)
                {
                    Encherir.CollClasse.Clear();
                    MaListeDernieresEncheres = await _apiServices.GetAllAsyncByID<Encherir>("api/getLastSixOffer", Encherir.CollClasse, "Id", MonEnchere.Id);
                    Thread.Sleep(18000);
                    
                }
            });
        }

        /// <summary>
        /// Cette méthode permet à la vue d'afficher la frame montrant le gagnant de l'enchère si le timer de l'enchère est à 0.
        /// Dans le cas où le timer n'est pas terminé, la fonction permet le non affichage de la frame du gagnant.
        /// </summary>
        /// <param name="param">Permet de récupérer la DateFin de l'enchère en cours</param>
        public void GetGagnantVisible(Enchere param)
        {
            tmps = new DecompteTimer();
            DateTime datefin = param.Datefin;
            TimeSpan interval = datefin - DateTime.Now;
            tmps.Start(interval);

            if (tmps.TempsRestant <= TimeSpan.Zero )
            {
                GagnantIsVisible = true;
            }
            else
            {
                GagnantIsVisible = false;
            }
        }

        /// <summary>
        /// Cette méthode permet de retourner le Gagnant de l'enchère en cours qui vient de se terminer
        /// </summary>
        public async void AfficherLeGagnant()
        {
            UnUser = await _apiServices.GetOneAsyncByID<User>("api/getGagnant", User.CollClasse, MonEnchere.Id);
            User.CollClasse.Clear();
        }
        #endregion

    }
}
