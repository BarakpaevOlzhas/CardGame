using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class Karta
    {
        public Mast Mast { set; get; }

        public TypeKarta Type {
            set;
            get;
           
        }

        public int Znach { get; set; }

        public Karta(Mast mast, TypeKarta type)
        {
            Mast = mast;
            Type = type;
        }

        public Karta()
        {
                
        }
    }
}
