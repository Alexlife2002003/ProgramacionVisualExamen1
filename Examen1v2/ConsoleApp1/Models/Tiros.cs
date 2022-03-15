using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class Tiros
    {
        int _tiro;
        int _numero_girado;
        int _dinero_apostado;
        String _ganado_perdido;
        String _tipoApuesta;

        public Tiros(int giro, int numero_girado, int dinero_apostado, string ganado_perdido, string tipoApuesta)
        {
            _tiro=giro;
            _numero_girado=numero_girado;
            _dinero_apostado=dinero_apostado;
            _ganado_perdido=ganado_perdido;
            _tipoApuesta = tipoApuesta;
        }

        public override string ToString()
        {
            return $"Tiro:{_tiro}, numero tirado:{_numero_girado}, Dinero apostado:{_dinero_apostado}, Estatus:{_ganado_perdido}, Tipo:{_tipoApuesta}";
        }

        public int Tiro
        {
            get { return _tiro; }
            set { _tiro = value; }
        }

        public int numero_Girado
        {
            get { return _numero_girado; }
            set { _numero_girado = value; }
        }

        public int DineroApostado
        {
            set { _dinero_apostado = value; }
            get { return _dinero_apostado; }
        }

        public String GanadoPerdido
        {
            set { _ganado_perdido=value; }
            get { return _ganado_perdido;}
        }

        public String TipoApuesta
        {
            set { _tipoApuesta=value; }
            get { return _tipoApuesta;}
        }
    }
}
