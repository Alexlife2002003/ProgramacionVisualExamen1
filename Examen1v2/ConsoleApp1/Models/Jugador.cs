using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class Jugador
    {
        public int dinero;

        public Jugador()
        {
            dinero = 300;
        }

        public int Dinero
        {
            set { dinero = value; }
            get { return dinero; }
        }

    }
}
