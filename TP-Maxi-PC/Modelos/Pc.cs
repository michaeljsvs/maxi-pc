using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Maxi_PC.Modelos
{
    public class Pc
    {
        public int idPc { get; set; }

        public Marca idMarca { get; set; }

        public Modelo idModelo { get; set; }

        public TipoPc idTipoPc { get; set; }

        public string descripcion { get; set; }
    }
}
