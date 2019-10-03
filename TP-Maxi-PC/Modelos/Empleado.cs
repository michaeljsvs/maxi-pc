using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Maxi_PC.Modelos
{
    public class Empleado
    {
        public int legajo { get; set; }

        public TiposDocumento TiposDocumento { get; set; }

        public int nroDocumento { get; set; }

        public string apellido { get; set; }

        public string nombre { get; set; }

        public TiposEmpleado idTipoEmpleado { get; set; }

        public DateTime fechaAlta { get; set; }

        public DateTime fechaBaja { get; set; }

        public bool ValidarApellido()
        {
            if (apellido.Length < 30)
                return true;
            return false;
        }

        public bool ValidarNombre()
        {
            if (!string.IsNullOrEmpty(nombre) && nombre.Length < 30)
                return true;
            return false;
        }

        public bool ValidarFechaAlta()
        {
            if (fechaAlta != DateTime.MinValue && fechaAlta < DateTime.Today)
                return true;
            return false;
        }

        public bool ValidarFechaBaja()
        {
            if (fechaBaja != DateTime.MinValue && fechaBaja >= DateTime.Today)
                return true;
            return false;
        }
    }
}
