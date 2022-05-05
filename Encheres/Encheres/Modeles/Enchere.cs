using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Encheres.Modeles
{
     public class Enchere
    {
        #region Attributs
        public static List<Enchere> CollClasse = new List<Enchere>();
        private int id;
        private DateTime _datedebut;
        private DateTime _datefin;
        private Produit _leProduit;
        private TypeEnchere _leTypeEnchere;
        private Magasin _leMagasin;
        private double _prixReserve;
        private string _tableauFlash;

        #endregion

        #region Constructeurs

        public Enchere(int id, Produit leProduit, DateTime datedebut, DateTime datefin, TypeEnchere leTypeEnchere, Magasin leMagasin, double prixReserve, string tableauFlash = null)
        {
            Enchere.CollClasse.Add(this);
            this.id = id;
            this._leProduit = leProduit;
            this._datedebut = datedebut;
            this._datefin = datefin;
            this._leTypeEnchere = leTypeEnchere;
            _leMagasin = leMagasin;
            _prixReserve = prixReserve;
            TableauFlash = tableauFlash;
        }

        #endregion

        #region Getters/Setters
        public int Id { get => id; set => id = value; }

       
        public Produit LeProduit { get => _leProduit; set => _leProduit = value; }
        public DateTime Datedebut { get => _datedebut; set => _datedebut = value; }
        public DateTime Datefin { get => _datefin; set => _datefin = value; }
        public TypeEnchere LeTypeEnchere { get => _leTypeEnchere; set => _leTypeEnchere = value; }
        public Magasin LeMagasin { get => _leMagasin; set => _leMagasin = value; }
        public double PrixReserve { get => _prixReserve; set => _prixReserve = value; }
        public string TableauFlash { get => _tableauFlash; set => _tableauFlash = value; }

        #endregion

        #region Methodes

        #endregion
    }
}
