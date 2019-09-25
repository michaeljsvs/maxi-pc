using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Maxi_PC.Helpers;

namespace TP_Maxi_PC.Repositorios
{
    public class TiposPCRepositorio
    {
        private acceso_BD BD;

        public TiposPCRepositorio()
        {
            BD = acceso_BD.Singleton();
        }

        public DataTable obtenerTiposDT()
        {
            string sql = "SELECT * FROM TiposPCs";
            return acceso_BD.Singleton().consulta(sql);
        }

        public bool insertarTipoPC(string descripcion)
        {
            string sql = $"INSERT [dbo].[TiposPCs] ([descripcion])" +
                    $" VALUES ('{descripcion}')";
            return BD.EjecutarSQL(sql);
        }

        public bool modificarTipoPC(int id, string descripcion)
        {
            string sql = $"UPDATE [dbo].[TiposPCs] SET descripcion = '{descripcion}' WHERE idTipoPC = {id}";
            return BD.EjecutarSQL(sql);
        }

        public void borrarTipoPC(String id)
        {
            string sql = "DELETE [dbo].[TiposPCs] WHERE idTipoPC = " + id;
            BD.EjecutarSQL(sql);
        }
    }
}
