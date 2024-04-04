using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alquiler
{
    class Alquilado
    {

        int nit;
        string placa;
        DateTime fechaAlq;
        DateTime fechaDevo;
        int recorrido;

        public int Nit { get => nit; set => nit = value; }
        public string Placa { get => placa; set => placa = value; }
        public DateTime FechaAlq { get => fechaAlq; set => fechaAlq = value; }
        public DateTime FechaDevo { get => fechaDevo; set => fechaDevo = value; }
        public int Recorrido { get => recorrido; set => recorrido = value; }


    }
}
