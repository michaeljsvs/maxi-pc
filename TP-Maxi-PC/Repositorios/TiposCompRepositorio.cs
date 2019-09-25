using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Maxi_PC.Helpers;

namespace TP_Maxi_PC.Repositorios
{
    class TiposCompRepositorio
    {
        private acceso_BD BD;

        public TiposCompRepositorio()
        {
            BD = acceso_BD.Singleton();
        }

        public DataTable obtenerTiposComponente()
        {
            string sql = "SELECT * FROM TiposComponente";
            return acceso_BD.Singleton().consulta(sql);
        }

        public bool insertarTiposComponente(string nombre)
        {
            string sql = $"INSERT [dbo].[TiposComponente] ([nombre])" +
                    $" VALUES ('{nombre}')";
            return BD.EjecutarSQL(sql);
        }

        public bool modificarTiposComponente(int id, string nombre)
        {
            string sql = $"UPDATE [dbo].[TiposComponente] SET nombre = '{nombre}' WHERE idTipoComponente = {id}";
            return BD.EjecutarSQL(sql);
        }

        public void borrarTiposComponente(String id)
        {
            string sql = "DELETE [dbo].[TiposComponente] WHERE idTipoComponente = " + id;
            BD.EjecutarSQL(sql);
        }
    }
}
