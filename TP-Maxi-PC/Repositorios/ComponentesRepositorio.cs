using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Maxi_PC.Helpers;

namespace TP_Maxi_PC.Repositorios
{
    public class ComponentesRepositorio
    {

        private acceso_BD BD;

        public ComponentesRepositorio()
        {
            BD = acceso_BD.Singleton();
        }


        public DataTable obtenerComponentesDT()
        {
            string sql = "SELECT C.idComponente,C.nombre,C.descripcion,T.nombre,M.nombre,C.precio FROM Componentes C JOIN tiposComponente T ON T.idTipoComponente = C.tipoComponente JOIN Modelos M ON M.idModelo = C.idModelo";

            return acceso_BD.Singleton().consulta(sql);
        }

        public DataTable obtenerTiposComponenteDT()
        {
            string sql = "SELECT * FROM TiposComponente";
            return acceso_BD.Singleton().consulta(sql);
        }

        public DataTable obtenerModelosDT()
        {
            string sql = "SELECT * FROM Modelos";
            return BD.consulta(sql);
        }
        public bool insertarComponente(string nombre, string descripcion, int tipoComponente, int idModelo, decimal precio)
        {
            string sql = $"INSERT [dbo].[Componentes] ([nombre],[descripcion],[tipoComponente],[idModelo],[precio])" +
                    $" VALUES ('{nombre}','{descripcion}','{tipoComponente}','{idModelo}','{precio}')";
            return BD.EjecutarSQL(sql);
        }

        public bool modificarComponente(int id, string nombre, string descripcion, int tipoComponente, int idModelo, decimal precio)
        {
            string sql = $"UPDATE [dbo].[Componentes] SET nombre = '{nombre}',descripcion= '{descripcion}',tipoComponente = '{tipoComponente}',idModelo = {idModelo},precio = '{precio}' WHERE idComponente = {id}";
            return BD.EjecutarSQL(sql);
        }

        public void borrarComponente(String id)
        {
            string sql = "DELETE [dbo].[Componentes] WHERE idComponente = " + id;
            BD.EjecutarSQL(sql);
        }

    }
}
