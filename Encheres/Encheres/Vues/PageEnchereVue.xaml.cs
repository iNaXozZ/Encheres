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
    public partial class PageEnchereVue : ContentPage
    {

        public PageEnchereVue(Enchere param)
        {
            InitializeComponent();
            BindingContext = new PageEnchereVueModele(param);
        }
    }
}