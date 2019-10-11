using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Maxi_PC.Modelos
{
    public class OrdenServicio
    {
        public int idOrdenServicio { get; set; }

        public Empleado legajoEmpleado { get; set; }

        public int montoSeña { get; set; }

        public DateTime fechaIngreso { get; set; }

        public DateTime fechaEstimadaEntregada { get; set; }

        public DateTime fechaRealEntrega { get; set; }

        public int costoTotal { get; set; }
        
        public IList<OrdenesXPc> OrdenesXPc { get; set; }
    }
}
