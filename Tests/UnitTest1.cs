using Encheres.Modeles;
using Encheres.Services;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Tests
{
    public class Tests
    {
        /// <summary>
        /// Test de la connexion d'un utilisateur à l'API en utilisant un mot de passe et un email présent dans la Base de données
        /// </summary>
        [Test]
        public void ConnexionUtilisateurSuccess()
        {
            // Jeu d'essai
            ApiAuthentification _apiServicesAuthentification = new ApiAuthentification();
            string _email = "romain@gmail.com";
            string _password = "romain";
            bool _resultat = false;


            //Grâce à l'adresse email et le mot de passe entrés en valeur, on demande à l'API de vérifier
            //l'exactitude des informations. Dans ce cas, l'API ne devrait rien retourner car les informations sont fausses.
            var task = _apiServicesAuthentification.GetAuthAsync<User>
                   (_email, _password, "api/getUserByMailAndPass");
            
            // On récupère le résultat de la requête et on l'instancie à un utilisateur.
            User res = task.Result;

            //Afin de savoir si un utilisateur a bien été renvoyée par l'api ou non, on créer une condition qui va nous dire si 
            // la variable res contient des éléments ou non.
            if (res != null)
            {
                _resultat = true;
            }

            //Assert : Le résultat attendu est true car les informations envoyées à la BDD correspondent à un utilisateur 
            Assert.AreEqual(true, _resultat);
        }





        /// <summary>
        /// Test de la connexion d'un utilisateur à l'API en utilisant un mot de passe et un email qui ne correspondent pas à un utilisateur inscrit dans la BDD
        /// </summary>
        [Test]
        public void ConnexionUtilisateurFailure()
        {
            // Jeu d'essai
            ApiAuthentification _apiServicesAuthentification = new ApiAuthentification();
            string _password = "rom";
            string _email = "romaintest@test.com";
            bool _resultat = false;


            //Grâce à l'adresse email et le mot de passe entrés en valeur, on demande à l'API de vérifier
            //l'exactitude des informations, et va renvoyer les informations de l'utilisateur si l'utilisateur est bien présent dans la BDD.
            var task = _apiServicesAuthentification.GetAuthAsync<User>
                   (_email, _password, "api/getUserByMailAndPass");

            // On récupère le résultat de la requête et on l'instancie à un utilisateur.
            User res = task.Result;

            // Afin de savoir si un utilisateur a bien été renvoyée par l'api ou non, on créer une condition qui va nous dire si 
            // la variable res contient des éléments ou non.
            if (res != null)
            {
                _resultat = true;
            }

            //Assert : Le résultat attendu est false car les informations envoyées à la BDD ne correspondent à aucun utilisateur présent dans la BDD
            Assert.AreEqual(false, _resultat);
        }

    }
}