using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Maxi_PC.Helpers;

namespace TP_Maxi_PC.Repositorios
{
    class MarcasRepositorio
    {
        private acceso_BD BD;

        public MarcasRepositorio()
        {
            BD = acceso_BD.Singleton();
        }


        public DataTable obtenerMarcasDT()
        {
            string sql = "SELECT * FROM Marcas";

            return acceso_BD.Singleton().consulta(sql);
        }

        
        public bool insertarMarca(string nombre)
        {
            string sql = $"INSERT [dbo].[Marcas] ([nombre]) VALUES ('{nombre}')";
            return BD.EjecutarSQL(sql);
        }

        public bool modificarMarca(int id, string nombre)
        {
            string sql = $"UPDATE [dbo].[Marcas] SET nombre = '{nombre}' WHERE idMarca = {id}";
            return BD.EjecutarSQL(sql);
        }

        public void borrarMarca(String id)
        {
            string sql = "DELETE [dbo].[Marcas] WHERE idMarca = " + id;
            BD.EjecutarSQL(sql);
        }
    }
}
