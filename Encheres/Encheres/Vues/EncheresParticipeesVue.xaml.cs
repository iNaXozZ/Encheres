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
    public partial class EncheresParticipeesVue : ContentPage
    {
        EncheresParticipeesVueModele vueModele;
        public EncheresParticipeesVue()
        {
            InitializeComponent();
            BindingContext = vueModele = new EncheresParticipeesVueModele();
        }
        private void OnClickRetour(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageProfilVue());
        }

        private void OnClickEncheres(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListeEnchereEnCoursVue());
        }
    }
}