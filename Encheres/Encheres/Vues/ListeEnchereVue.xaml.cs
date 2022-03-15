using Encheres.Modeles;
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
    public partial class ListeEnchereVue : ContentPage
    {
        ListeEnchereVueModele vueModel;
        public ListeEnchereVue()
        {
            InitializeComponent();
            BindingContext = vueModel = new ListeEnchereVueModele();
           
        }


        private void ListeEnchere_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            var current = (Enchere)e.CurrentSelection.FirstOrDefault();
             Navigation.PushAsync(new PageEnchereVue(current));
        }
    }
}