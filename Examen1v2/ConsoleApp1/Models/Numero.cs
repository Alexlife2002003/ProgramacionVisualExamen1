using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class Numero
    {
        int id;
        int veces;


        public Numero(int ID, int v)
        {
            id = ID;
            veces = v;
        }

        public int Veces
        {
            get { return veces; }
            set { veces = value; }
        }
        public int Id
        {
            set { id = value; }
            get { return id; }
        }

        public override string ToString()
        {
            return $"El numero {id} ha sido tirado {veces} veces";
        }


    }
}
