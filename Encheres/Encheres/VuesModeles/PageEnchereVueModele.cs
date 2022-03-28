using Encheres.Modeles;
using Encheres.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Encheres.VuesModeles
{
    class PageEnchereVueModele : BaseVueModele
    {
        #region Attributs
        private Enchere _monEnchere;
        private int _tempsRestantJour;
        private int _tempsRestantHeures;
        private int _tempsRestantMinutes;
        private int _tempsRestantSecondes;
        private Encherir _prixActuel;
        private readonly Api _apiServices = new Api();
        #endregion

        #region Constructeur
        public PageEnchereVueModele(Enchere param)
        {

            _monEnchere = param;
            this.GetTimerRemaining(param.Datefin);
            this.GetPrixActuelEnchere();
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
        public int TempsRestantHeures
        {
            get { return _tempsRestantHeures; }
            set { SetProperty(ref _tempsRestantHeures, value); }
        }
        public int TempsRestantJour
        {
            get { return _tempsRestantJour; }
            set { SetProperty(ref _tempsRestantJour, value); }
        }
        public int TempsRestantMinutes
        {
            get { return _tempsRestantMinutes; }
            set { SetProperty(ref _tempsRestantMinutes, value); }
        }
        public int TempsRestantSecondes
        {
            get { return _tempsRestantSecondes; }
            set { SetProperty(ref _tempsRestantSecondes, value); }
        }
        public Encherir PrixActuel
        {
            get { return _prixActuel; }
            set { SetProperty(ref _prixActuel, value); }
        }
        #endregion

        #region Méthodes
        public void GetTimerRemaining(DateTime param)
        {
            DateTime datefin = param;
            TimeSpan interval = datefin - DateTime.Now;
            DecompteTimer tmps = new DecompteTimer();

            Task.Run(() =>
            {
                tmps.Start(interval);
                while (tmps.TempsRestant > TimeSpan.Zero)
                {
                    TempsRestantJour = tmps.TempsRestant.Days;
                    TempsRestantHeures = tmps.TempsRestant.Hours;
                    TempsRestantMinutes = tmps.TempsRestant.Minutes;

                    TempsRestantSecondes = tmps.TempsRestant.Seconds;
                }
            });
        }

        public void GetPrixActuelEnchere()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    PrixActuel = await _apiServices.GetOneAsyncByID<Encherir>("api/getActualPrice", Encherir.CollClasse, MonEnchere.Id.ToString());
                    Thread.Sleep(2000);
                }
            });
        }
        #endregion
    }
}
