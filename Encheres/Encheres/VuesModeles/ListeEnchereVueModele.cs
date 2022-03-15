using Encheres.Modeles;
using Encheres.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Encheres.VuesModeles
{
    class ListeEnchereVueModele :BaseVueModele
    {
        
        #region Attributs
        private ObservableCollection<Enchere> _maListeEncheres;
        private readonly Api _apiServices = new Api();

        #endregion
        #region Constructeur
        public ListeEnchereVueModele()
        {
            GetListeEncheres();
        }
        #endregion
        #region Getters/Setters
        public ObservableCollection<Enchere> MaListeEncheres
        {
            get { return _maListeEncheres; }
            set { SetProperty(ref _maListeEncheres, value); }
        }
        
        #endregion
        #region Méthode
        public async void GetListeEncheres()
        {
            MaListeEncheres = await _apiServices.GetAllAsync<Enchere>
                ("api/getEnchere", Enchere.CollClasse);
        }
        #endregion
    }
}
