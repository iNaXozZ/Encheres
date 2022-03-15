using Encheres.Modeles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Encheres.VuesModeles
{
    class PageEnchereVueModele : BaseVueModele
    {
        private Enchere _monEnchere;
        public PageEnchereVueModele(Enchere param)
        {

            _monEnchere = param;
        }

        public Enchere MonEnchere
        { get
            { return _monEnchere; }
            set
            {
             SetProperty(ref _monEnchere, value);
       
            }
        }
    }
}
