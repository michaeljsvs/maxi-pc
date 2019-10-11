using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Maxi_PC.Modelos
{
    public class OrdenesXPc
    {
        public int idOrdenXPc { get; set; }

        public Pc idPc { get; set; }

        public int tiempoTrabajado { get; set; }
    }
}
