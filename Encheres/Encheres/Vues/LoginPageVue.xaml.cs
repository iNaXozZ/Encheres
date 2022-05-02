using Encheres.VuesModeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Encheres.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPageVue : ContentPage
    {
        LoginPageVueModele Vuesmodele;
        public LoginPageVue()
        {
            InitializeComponent();
            BindingContext = Vuesmodele = new LoginPageVueModele();
        }

      

        private void OnClickEncheresEnCours(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListeEnchereEnCoursVue());
        }

        private void OnClickInscription(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InscriptionPageVue());
        }

        private void Email_Unfocused(object sender, FocusEventArgs e)
        {
            EntryPassword.Focus();
        }
    }
}