using System;
using System.Collections.Generic;
using System.Text;

namespace Encheres.Modeles
{
   public class Encherir
    {
        #region Attributs
        public static List<Encherir> CollClasse = new List<Encherir>();
        //private Encheres laEnchere;
        private User leUser;

        private int _id;
        private float _prixEnchere;
        private int _idUser;
        private int _idEnchere;

        #endregion

        #region Constructeurs

        public Encherir(Enchere laEnchere, User leUser, int id, float prixEnchere, int idUser, int idEnchere)
        {
            Encherir.CollClasse.Add(this);
            //this.LaEnchere = laEnchere;
            this.LeUser = leUser;
            Id = id;
            PrixEnchere = prixEnchere;
            IdUser = idUser;
            IdEnchere = idEnchere;
        }



        #endregion

        #region Getters/Setters
        //internal Encheres LaEnchere { get => laEnchere; set => laEnchere = value; }
        internal User LeUser { get => leUser; set => leUser = value; }
        public int Id { get => _id; set => _id = value; }
        public float PrixEnchere { get => _prixEnchere; set => _prixEnchere = value; }
        public int IdUser { get => _idUser; set => _idUser = value; }
        public int IdEnchere { get => _idEnchere; set => _idEnchere = value; }
        #endregion

        #region Methodes

        #endregion
    }
}
