using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Encheres.Modeles
{
    public class User
    {
        #region Attributs
        public static List<User> CollClasse = new List<User>();
        private string _email;
        private string _photo;
        private string _password;
        private string _pseudo;
        private int _id;

        //private ObservableCollection<Encherir> lesEncherir;
        #endregion

        #region Constructeurs



        public User(string email, string photo, string password, string pseudo)
        {
            User.CollClasse.Add(this);
            Email = email;
            Photo = photo;
            Password = password;
            Pseudo = pseudo;
        }

        public User()
        {

        }
        public User(string pseudo,string password, string email)
        {
            Email = email;
            Password = password;
            Pseudo = pseudo;
        }
        public User(string email, string password)
        {
            User.CollClasse.Add(this);
            Email = email;
            Password = password;
        }
        #endregion

        #region Getters/Setters
        public string Email { get => _email; set => _email = value; }
        public string Photo { get => _photo; set => _photo = value; }
        public string Password { get => _password; set => _password = value; }
        public string Pseudo { get => _pseudo; set => _pseudo = value; }
        public int Id { get => _id; set => _id = value; }

        #endregion

        #region Methodes

        #endregion
    }
}
