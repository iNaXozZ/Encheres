using Encheres.Modeles;
using Encheres.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Encheres.VuesModeles
{
    public class ListeEnchereEnCoursVueModele : BaseVueModele
    {
        #region Attributs
        private ObservableCollection<Enchere> _maListeEncheresEnCours;
        private ObservableCollection<Enchere> _maListeEncheresEnCoursTypeClassique;
        private ObservableCollection<Enchere> _maListeEncheresEnCoursTypeInverse;
        private ObservableCollection<Enchere> _maListeEncheresEnCoursTypeFlash;
        private readonly Api _apiServices = new Api();

        #endregion
        #region Constructeur
        public ListeEnchereEnCoursVueModele()
        {
            GetListeEncheres();
            GetListeEncheresEnCoursTypeClassique(1);
            GetListeEncheresEnCoursTypeInverse(2);
            GetListeEncheresEnCoursTypeFlash(3);
        }
        #endregion
        #region Getters/Setters
        public ObservableCollection<Enchere> MaListeEncheresEnCours
        {
            get { return _maListeEncheresEnCours; }
            set { SetProperty(ref _maListeEncheresEnCours, value); }
        }
        public ObservableCollection<Enchere> MaListeEncheresEnCoursTypeClassique
        {
            get { return _maListeEncheresEnCoursTypeClassique; }
            set { SetProperty(ref _maListeEncheresEnCoursTypeClassique, value); }
        }
        public ObservableCollection<Enchere> MaListeEncheresEnCoursTypeInverse
        {
            get { return _maListeEncheresEnCoursTypeInverse; }
            set { SetProperty(ref _maListeEncheresEnCoursTypeInverse, value); }
        }
        public ObservableCollection<Enchere> MaListeEncheresEnCoursTypeFlash
        {
            get { return _maListeEncheresEnCoursTypeFlash; }
            set { SetProperty(ref _maListeEncheresEnCoursTypeFlash, value); }
        }

        #endregion
        #region Méthode

        /// <summary>
        /// Cette méthode permet grâce à l'appel de l'API, de retourner la liste de toutes les enchères effectuées 
        /// </summary>
        public async void GetListeEncheres()
        {
            MaListeEncheresEnCours = await _apiServices.GetAllAsync<Enchere>
                ("api/getEncheresEnCours", Enchere.CollClasse);
            Enchere.CollClasse.Clear();
        }

        /// <summary>
        /// Cette méthode permet de retourner toutes les enchères classiques en cours grâce à l'appel de L'API
        /// </summary>
        /// <param name="id">Permet de récupérer les ecnhères selon l'id du type de l'enchère en cours</param>
        public async void GetListeEncheresEnCoursTypeClassique(int id)
        {

            MaListeEncheresEnCoursTypeClassique = await _apiServices.GetAllAsyncByID<Enchere>
                ("api/getEncheresEnCours", Enchere.CollClasse, "IdTypeEnchere", id);
            Enchere.CollClasse.Clear();
        }

        /// <summary>
        /// Cette méthode permet de retourner toutes les enchères inverses en cours grâce à l'appel de L'API
        /// </summary>
        /// <param name="id">Permet de récupérer les ecnhères selon l'id du type de l'enchère en cours</param>
        public async void GetListeEncheresEnCoursTypeInverse(int id)
        {
            
            MaListeEncheresEnCoursTypeInverse = await _apiServices.GetAllAsyncByID<Enchere>
                ("api/getEncheresEnCours", Enchere.CollClasse, "IdTypeEnchere", id);
            Enchere.CollClasse.Clear();
        }

        /// <summary>
        /// Cette méthode permet de retourner toutes les enchères flashs en cours grâce à l'appel de L'API
        /// </summary>
        /// <param name="id">Permet de récupérer les ecnhères selon l'id du type de l'enchère en cours</param>
        public async void GetListeEncheresEnCoursTypeFlash(int id)
        {
           
            MaListeEncheresEnCoursTypeFlash = await _apiServices.GetAllAsyncByID<Enchere>
                ("api/getEncheresEnCours", Enchere.CollClasse, "IdTypeEnchere", id);
            Enchere.CollClasse.Clear();
        }
        #endregion
    }
}
