using Microsoft.VisualStudio.TestTools.UnitTesting;
using Encheres.VuesModeles;
using System;
using System.Collections.Generic;
using System.Text;
using Encheres.Services;
using Encheres.Modeles;

namespace Encheres.VuesModeles.Tests
{
    [TestClass()]
    public class LoginPageVueModeleTests
    {
        [TestMethod()]
        public async void ConnexionUtilisateurSuccess()
        {
            ApiAuthentification _apiServicesAuthentification = new ApiAuthentification();
            string _password = "romain";
            string _email = "romain@gmail.com";

            //Grâce à l'adresse email et le mot de passe entrés en dans le formulaire, on demande à l'API de vérifier
            //l'exactitude des informations, de récupérer les données de l'utilisateur.
            User res = await _apiServicesAuthentification.GetAuthAsync<User>
                   (_email, _password, "api/getUserByMailAndPass");

            bool _resultat = false;

            if (res != null)
            {
                _resultat = true;
            }
            Assert.AreEqual(_resultat, true);
        }

    }
}