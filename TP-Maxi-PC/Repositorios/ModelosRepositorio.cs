using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Maxi_PC.Helpers;

namespace TP_Maxi_PC.Repositorios
{
    class ModelosRepositorio
    {
        private acceso_BD BD;

        public ModelosRepositorio()
        {
            BD = acceso_BD.Singleton();
        }


        public DataTable obtenerModelosDT()
        {
            string sql = "SELECT M.idModelo,M.nombre,A.nombre FROM Modelos M JOIN Marcas A ON M.idMarca = A.idMarca";

            return acceso_BD.Singleton().consulta(sql);
        }

        public DataTable obtenerMarcasDT()
        {
            string sql = "SELECT * FROM Marcas";
            return acceso_BD.Singleton().consulta(sql);
        }

        
        public bool insertarModelo(string nombre, int idMarca)
        {
            string sql = $"INSERT [dbo].[Modelos] ([nombre],[idMarca]) VALUES ('{nombre}','{idMarca}')";
            return BD.EjecutarSQL(sql);
        }

        public bool modificarModelo(int id, string nombre, int idMarca)
        {
            string sql = $"UPDATE [dbo].[Modelos] SET nombre = '{nombre}',idMarca = {idMarca} WHERE idModelo = {id}";
            return BD.EjecutarSQL(sql);
        }

        public void borrarModelo(String id)
        {
            string sql = "DELETE [dbo].[Modelos] WHERE idModelo = " + id;
            BD.EjecutarSQL(sql);
        }

    }
}
