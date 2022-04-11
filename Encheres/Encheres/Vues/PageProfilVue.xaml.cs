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
        public PageProfilVue()
        {
            InitializeComponent();
            BindingContext = new PageProfilVueModele();
        }

        private void OnClickDeconnexion(object sender, EventArgs e)
        {
            SecureStorage.Remove("ID");
            SecureStorage.Remove("PSEUDO");
            Navigation.PushAsync(new LoginPageVue());
        }

        private void OnClickListeEnchere(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListeEnchereEnCoursVue());
        }
    }
}