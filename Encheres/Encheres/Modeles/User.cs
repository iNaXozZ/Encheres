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
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Pseudo { get; set; }
        public string Photo { get; set; }

        #endregion

        #region Methodes

        #endregion
    }
}
