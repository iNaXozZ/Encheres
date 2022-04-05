using Encheres.Modeles;
using Encheres.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

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
        public DecompteTimer tmps;
        private string _idUser;
        private string _pseudoUser;
        private readonly Api _apiServices = new Api();
        private bool _boutonEncherirVisible = false;
        #endregion

        #region Constructeur
        public PageEnchereVueModele(Enchere param)
        {

            _monEnchere = param;
            this.GetTimerRemaining(param.Datefin);
            this.GetPrixActuelEnchere();
            this.GetBoutonEncherirVisible();
            CommandButtonEnchere= new Command(SetEncherir);
            tmps = new DecompteTimer();
            DateTime datefin = param.Datefin;
            TimeSpan interval = datefin - DateTime.Now;
            tmps.Start(interval);
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
        public bool BoutonEncherirVisible
        {
            get { return _boutonEncherirVisible; }
            set { SetProperty(ref _boutonEncherirVisible, value); }
        }

        public string IdUser { get => _idUser; set => _idUser = value; }
        public string PseudoUser { get => _pseudoUser; set => _pseudoUser = value; }
        public ICommand CommandButtonEnchere { get; }
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

        public async void GetBoutonEncherirVisible()
        {
            IdUser = await SecureStorage.GetAsync("ID");
            PseudoUser = await SecureStorage.GetAsync("PSEUDO");
            
            if (IdUser != null)
            {
                BoutonEncherirVisible = true;
            }

        }
        public void GetPrixActuelEnchere()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    PrixActuel = await _apiServices.GetOneAsyncByID<Encherir>("api/getActualPrice", Encherir.CollClasse, MonEnchere.Id.ToString());
                    Encherir.CollClasse.Clear();
                    Thread.Sleep(10000);
                }
            });
        }

        public async void SetEncherir()
        {
            IdUser = await SecureStorage.GetAsync("ID");
            PseudoUser = await SecureStorage.GetAsync("PSEUDO");

            if (MonEnchere.LeTypeEnchere.Id == 1)
            {
                this.SetEncherirClassique();
            }
            /*if (MonEnchere.LeTypeEnchere.Id == 2)
            {
                this.SetEncherirInverse();
            }*/

        }
        public async void SetEncherirClassique()
        {

            IdUser = await SecureStorage.GetAsync("ID");
            PseudoUser = await SecureStorage.GetAsync("PSEUDO");

            // Ajout condition que si l'utilisateur est différent de celui qui a enchéris et que le timer est supérieur à 0, grâce au bouton,
            // l'enchère se mettra dans la BDD et l'enchère sera validée.
            if (PrixActuel != null && PrixActuel.Id != int.Parse(IdUser) && tmps.TempsRestant > TimeSpan.Zero)
            {
                int resultatEncherir = await _apiServices.PostAsync<Encherir>(new Encherir(0, (PrixActuel.PrixEnchere + 1), int.Parse(IdUser), MonEnchere.Id, PseudoUser), "api/postEncherir");
                Encherir.CollClasse.Clear();
                Thread.Sleep(3000);
                await Application.Current.MainPage.DisplayAlert("Succès ✔️ ", "Vous avez enchéris avec succès", "OK");
            }
            // Ajout condition dans le cas où si la personne a enchéris, elle ne pourra pas enchérir sur elle-même
            if (PrixActuel != null && PrixActuel.Id == int.Parse(IdUser) && tmps.TempsRestant > TimeSpan.Zero)
            {
                await Application.Current.MainPage.DisplayAlert("Echec ❌ ", "Vous avez déjà enchéris, attendez qu'une autre personne enchérisse.", "OK");

            }
            //Ajout condition que si l'enchère est terminée, la personne ne pourra pas enchérir et lui enverra un message d'erreur
            if (PrixActuel != null && PrixActuel.Id != int.Parse(IdUser) && tmps.TempsRestant <= TimeSpan.Zero)
            {
                await Application.Current.MainPage.DisplayAlert("Echec ❌ ", "Vous ne pouvez plus réenchérir, l'enchère est terminée.", "OK");
            }
            // Si tout autre problème, Affichage d'un message d'erreur
            else
            {
                await Application.Current.MainPage.DisplayAlert("Echec ❌ ", "Il y a eu un problème avec votre enchère", "OK");
            }
        }

        /*public async void SetEncherirInverse()
        {
            IdUser = await SecureStorage.GetAsync("ID");
            PseudoUser = await SecureStorage.GetAsync("PSEUDO");

            // Ajout condition que si le prix de l'enchère est différent de null et que le timer est supérieur à 0, grâce au bouton,
            // l'enchère se mettra dans la BDD et l'enchère sera validée.
            if (PrixActuel != null && tmps.TempsRestant > TimeSpan.Zero)
            {
                int resultatEncherir = await _apiServices.PostAsync<Encherir>(new Encherir(0, (PrixActuel.PrixEnchere + 1), int.Parse(IdUser), MonEnchere.Id, PseudoUser), "api/postEncherirInverse");
                Encherir.CollClasse.Clear();
                Thread.Sleep(3000);
                await Application.Current.MainPage.DisplayAlert("Succès ✔️ ", "Vous avez enchéris avec succès", "OK");
            }

        }*/

        #endregion
    }
}
