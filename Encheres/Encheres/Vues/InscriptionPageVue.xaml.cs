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
    
    public partial class InscriptionPageVue : ContentPage 
    {
        InscriptionPageVueModele VuesModele;
        public InscriptionPageVue()
        {
            InitializeComponent();
            BindingContext = VuesModele = new InscriptionPageVueModele();
        }

        private void OnClickRetour(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPageVue());
        }

        private void EntryPseudo_Unfocused(object sender, FocusEventArgs e)
        {
            EntryEmail.Focus();
        }

        private void EntryEmail_Unfocused(object sender, FocusEventArgs e)
        {
            EntryPassword.Focus();
        }
    }
}