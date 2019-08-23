using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using TP_Maxi_PC.Helpers;

namespace TP_Maxi_PC.Repositorios
{
    public class ClientesRepositorio
    {
        private acceso_BD BD;

        public ClientesRepositorio()
        {
            BD = new acceso_BD();
        }


        public DataTable obtenerClientesDT()
        {
            string sql = "SELECT * FROM Clientes";

            return BD.consulta(sql);
        }
        
        public DataTable obtenerBarriosDT()
        {
            string sql = "SELECT * FROM Barrios";
            return BD.consulta(sql);
        }
    }
}
