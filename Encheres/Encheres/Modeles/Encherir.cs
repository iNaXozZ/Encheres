using Newtonsoft.Json;
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
        //private User leUser;

        private int _id;
        private float _prixEnchere;
        private int _idUser;
        private int _idEnchere;
        private string _pseudo;
        #endregion

        #region Constructeurs

        public Encherir(int id, float prixEnchere, int idUser, int idEnchere, string pseudo)
        {
            Encherir.CollClasse.Add(this);
            Id = id;
            PrixEnchere = prixEnchere;
            IdUser = idUser;
            IdEnchere = idEnchere;
            _pseudo = pseudo;
        }



        #endregion

        #region Getters/Setters
        //internal Encheres LaEnchere { get => laEnchere; set => laEnchere = value; }
        //internal User LeUser { get => leUser; set => leUser = value; }
        public int Id { get => _id; set => _id = value; }
        public float PrixEnchere { get => _prixEnchere; set => _prixEnchere = value; }
        
        public int IdUser { get => _idUser; set => _idUser = value; }
        public int IdEnchere { get => _idEnchere; set => _idEnchere = value; }
        public string Pseudo { get => _pseudo; set => _pseudo = value; }
        #endregion

        #region Methodes

        #endregion
    }
}
