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
    public partial class PageProfilVue : ContentPage
    {
        PageProfilVueModele  VuesModele;
        public PageProfilVue()
        {
            InitializeComponent();
            BindingContext = VuesModele =  new PageProfilVueModele();
        }

        private void OnClickDeconnexion(object sender, EventArgs e)
        {
            //Lors de l'appuie sur le bouton de déconnexion, on efface l'id et le pseudo de l'utilisateur
            //présent dans le cache de l'application.
            SecureStorage.Remove("ID");
            SecureStorage.Remove("PSEUDO");

            //On redirige l'utilisateur vers la page de connexion de l'application
            Navigation.PushAsync(new LoginPageVue());
        }

        private void OnClickListeEnchere(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListeEnchereEnCoursVue());
        }

        private void OnClickEncheresParticipees(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EncheresParticipeesVue());
        }
    }
}