using Encheres.Modeles;
using Encheres.VuesModeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Encheres.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListeEnchereEnCoursVue : ContentPage
    {
        ListeEnchereEnCoursVueModele VuesModele;
        private string _idUser;
        public ListeEnchereEnCoursVue()
        {
            InitializeComponent();
            BindingContext = VuesModele = new ListeEnchereEnCoursVueModele();
        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var current = (Enchere)e.CurrentSelection.FirstOrDefault();
            Navigation.PushAsync(new PageEnchereVue(current));
        }

        /// <summary>
        /// Ce bouton permet à l'utilisateur de retourner vers sa page de profil ou la page de connexion de l'application
        /// suivant si il est connecté ou non.
        /// </summary>
        private async void OnClickRetourPageProfil(object sender, EventArgs e)
        {
            //On vérifie si un utilisateur est connecté en cherchant un id d'utilisateur dans le cache de l'application
            _idUser = await  SecureStorage.GetAsync("ID");

            // Si le cache renvoi un id d'utilisateur, on retourne l'utilisateur connecté vers sa page de profil
            if (_idUser != null)
            {
                await Navigation.PushAsync(new PageProfilVue());
            }

            //Si le cahce ne renvoi pas d'id, on renvoi l'utilisateur vers la page de connexion de l'application
            else
            {
                await Navigation.PushAsync(new LoginPageVue());
            }
                
        }

    }
}