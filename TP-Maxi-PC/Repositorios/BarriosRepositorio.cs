using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Maxi_PC.Helpers;
using TP_Maxi_PC.Modelos;

namespace TP_Maxi_PC.Repositorios
{
    class BarriosRepositorio
    {
        public BarriosRepositorio()
        {

        }

        //OBTENER TABLA Y CONVERTIRLA A LISTA
        public DataTable ObtenerBarriosDT()
        {
            string sqltxt = "SELECT * FROM Barrios";
            return acceso_BD.Singleton().consulta(sqltxt);
        }

        public List<Barrio> ObtenerBarrios()
        {
            var tablaTemporal = ObtenerBarriosDT();
            var barrios = new List<Barrio>();
            foreach (DataRow fila in tablaTemporal.Rows)
            {
                var barrio = new Barrio();
                if (fila.HasErrors)
                    continue;

                barrio.idBarrio = int.Parse(fila.ItemArray[0].ToString()); // idBarrio
                barrio.nombre = fila.ItemArray[1].ToString();// Nombre Tipo Documento

                barrios.Add(barrio);
            }
            return barrios;
        }

        //GUARDAR (VER SI SE PUEDEN SACAR LOS SET IDENTITY AL ELIMINAR LAS PK)
        public bool Guardar(Barrio barrio)
        {
            string sqltxt = $"INSERT [dbo].[Barrios] ([nombre]) " +
                $"VALUES ('{barrio.nombre}')";

            return acceso_BD.Singleton().EjecutarSQL(sqltxt);
        }

        //ACTUALIZAR
        public bool Actualizar(Barrio barrio)
        {
            string sqltxt = $"UPDATE [dbo].[Barrios] SET nombre = '{barrio.nombre}' WHERE idBarrio = {barrio.idBarrio}";

            return acceso_BD.Singleton().EjecutarSQL(sqltxt);
        }

        //ELIMINAR
        public bool Eliminar(string idbarrio)
        {
            string sqltxt = $"DELETE FROM [dbo].[Barrios] WHERE idBarrio = {idbarrio}";

            return acceso_BD.Singleton().EjecutarSQL(sqltxt);
        }

        //OBTENER UN OBJETO ESPECIFICO A TRAVES DE SU PK
        public Barrio ObtenerBarrio(string idbarrio)
        {
            string sqltxt = $"SELECT * FROM [dbo].[Barrios] WHERE idBarrio = {idbarrio}";
            var tablaTemporal = acceso_BD.Singleton().consulta(sqltxt);

            if (tablaTemporal.Rows.Count == 0)
                return null;

            var barrio = new Barrio();
            foreach (DataRow fila in tablaTemporal.Rows)
            {
                if (fila.HasErrors)
                    continue;

                barrio.idBarrio = int.Parse(fila.ItemArray[0].ToString()); // idBarrio
                barrio.nombre = fila.ItemArray[1].ToString();// Nombre Barrio
            }
            return barrio;
        }
    }
}
