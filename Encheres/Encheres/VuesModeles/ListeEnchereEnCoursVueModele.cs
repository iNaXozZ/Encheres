using Encheres.Modeles;
using Encheres.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Encheres.VuesModeles
{
    class ListeEnchereEnCoursVueModele : BaseVueModele
    {
        #region Attributs
        private ObservableCollection<Enchere> _maListeEncheresEnCours;
        private ObservableCollection<Enchere> _maListeEncheresEnCoursType;
        private readonly Api _apiServices = new Api();

        #endregion
        #region Constructeur
        public ListeEnchereEnCoursVueModele()
        {
            GetListeEncheres();
            GetListeEncheresEnCoursParType()
        }
        #endregion
        #region Getters/Setters
        public ObservableCollection<Enchere> MaListeEncheresEnCours
        {
            get { return _maListeEncheresEnCours; }
            set { SetProperty(ref _maListeEncheresEnCours, value); }
        }
        public ObservableCollection<Enchere> MaListeEncheresEnCoursType
        {
            get { return _maListeEncheresEnCoursType; }
            set { SetProperty(ref _maListeEncheresEnCoursType, value); }
        }

        #endregion
        #region Méthode
        public async void GetListeEncheres()
        {
            MaListeEncheresEnCours = await _apiServices.GetAllAsync<Enchere>
                ("api/getEncheresEnCours", Enchere.CollClasse);
        }
       
        #endregion
    }
}
