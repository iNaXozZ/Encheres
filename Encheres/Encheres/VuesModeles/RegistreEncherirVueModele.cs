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
        #endregion

        #region Constructeur
        public RegistreEncherirVueModele(Enchere param)
        {
            _monEnchere = param;
            AfficherDernieresEncheres();

        }
        #endregion

        #region Getters/Setters
        public Enchere MonEnchere
        {
            get
            { return _monEnchere; }
            set
            {
                SetProperty(ref _monEnchere, value);

            }
        }
        public ObservableCollection<Encherir> MaListeDernieresEncheres
        {
            get { return _maListeDernieresEncheres; }
            set { SetProperty(ref _maListeDernieresEncheres, value); }
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
        #endregion

    }
}
