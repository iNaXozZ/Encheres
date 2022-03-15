using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Encheres.Modeles
{
    public class Produit
    {
        #region Attributs
        public static List<Produit> CollClasse = new List<Produit>();
        private int id;
        private string nom;
        private float _prixreel;
        private string photo;
        //private ObservableCollection<Magasin> lesMagasins;
        //private ObservableCollection<Encheres> lesEncheres;

        #endregion

        #region Constructeurs

        public Produit(int id, string nom, string photo, float prixreel )
        {
            Produit.CollClasse.Add(this);
            this.id = id;
            this.nom = nom;
            this.Prixreel = prixreel;
            this.photo = photo;
            //this.lesMagasins = lesMagasins;
            //this.lesEncheres = lesEncheres;
        }

        #endregion

        #region Getters/Setters
        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public float Prixreel { get => _prixreel; set => _prixreel = value; }
        public string Photo { get => photo; set => photo = value; }
        #endregion

        #region Methodes

        #endregion
    }
}
