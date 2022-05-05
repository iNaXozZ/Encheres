using Encheres.Modeles;
using Encheres.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Essentials;

namespace Encheres.VuesModeles
{
    class EncheresParticipeesVueModele : BaseVueModele
    {
        #region Attributs
        private readonly Api _apiServices = new Api();
        private ObservableCollection<Enchere> _maListeEncheresParticipees;
        private string _idUser;
        #endregion

        #region Constructeur
        public EncheresParticipeesVueModele()
        {
            AfficherEncheresParticipees();

        }
        #endregion

        #region Getters/Setters
        public ObservableCollection<Enchere> MaListeEncheresParticipees
        {
            get { return _maListeEncheresParticipees; }
            set { SetProperty(ref _maListeEncheresParticipees, value); }
        }

        public string IdUser { get => _idUser; set => _idUser = value; }


        #endregion

        #region Méthodes

        /// <summary>
        /// Cette méthode permet grâce à l'appel de l'API d'afficher toutes les enchères auquelles l'utilisateur a participé.
        /// </summary>
        public async void AfficherEncheresParticipees()
        {
           //On récupère dans le SecureStorage l'id de l'utilisateur
            IdUser = await SecureStorage.GetAsync("ID");

            //On demande à l'API de nous renvoyer la liste des enchères auquelles l'utilisateur et on le stock dans une collection
            MaListeEncheresParticipees = await _apiServices.GetAllAsyncByID<Enchere>("api/getEncheresParticipes", Enchere.CollClasse, "Id", IdUser.ToString());
            // Pour éviter tout doublon, on rénitialise la collclasse.
            Enchere.CollClasse.Clear();
        }
        #endregion
    }
}
