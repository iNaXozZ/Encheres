using Encheres.Modeles;
using Encheres.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Encheres.VuesModeles
{
    class ListeProduitVueModele : BaseVueModele
    {
        #region Attributs

        private ObservableCollection<Produit> _maListeProduits;
        private readonly Api _apiServices = new Api();
        private bool _resultat;

        #endregion

        #region Constructeurs
        public ListeProduitVueModele()
        {
            _resultat = false; 
            GetListeProduits();
            //PostProduit(new Produit(0,"test","test", 10));
        }
        #endregion

        #region Getters/Setters
        public ObservableCollection<Produit> MaListeProduits
        {
            get { return _maListeProduits; }
            set { SetProperty(ref _maListeProduits, value); }
        }
        public bool Resultat { get => _resultat; set => _resultat = value; }

        #endregion

        #region Méthodes
        public async void GetListeProduits()
        {
            MaListeProduits = await _apiServices.GetAllAsync<Produit>
                ("api/getProduit", Produit.CollClasse);
        }

        public async void PostProduit(Produit unProduit)
        {
            Resultat =  await _apiServices.PostAsync<Produit>
                (unProduit,"api/postProduit");
        }
        #endregion

    }
}
