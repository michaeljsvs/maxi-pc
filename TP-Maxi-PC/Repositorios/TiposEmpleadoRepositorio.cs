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
    class TiposEmpleadoRepositorio
    {
        public TiposEmpleadoRepositorio()
        {

        }

        //OBTENER TABLA Y CONVERTIRLA A LISTA
        public DataTable ObtenerTiposEmpleadoDT()
        {
            string sqltxt = "SELECT * FROM TiposEmpleado";
            return acceso_BD.Singleton().consulta(sqltxt);
        }

        public List<TiposEmpleado> ObtenerTiposEmpleado()
        {
            var tablaTemporal = ObtenerTiposEmpleadoDT();
            var tiposEmpleado = new List<TiposEmpleado>();
            foreach (DataRow fila in tablaTemporal.Rows)
            {
                var tipoEmpleado = new TiposEmpleado();
                if (fila.HasErrors)
                    continue;

                tipoEmpleado.idTipoEmpleado = int.Parse(fila.ItemArray[0].ToString()); // idTipoEmpleado
                tipoEmpleado.nombre = fila.ItemArray[1].ToString();// Nombre Tipo Empleado

                tiposEmpleado.Add(tipoEmpleado);
            }
            return tiposEmpleado;
        }

        //GUARDAR (VER SI SE PUEDEN SACAR LOS SET IDENTITY AL ELIMINAR LAS PK)
        public bool Guardar(TiposEmpleado tipoEmpleado)
        {
            string sqltxt = $"INSERT [dbo].[TiposEmpleado] ([nombre]) " +
                $"VALUES ('{tipoEmpleado.nombre}')";

            return acceso_BD.Singleton().EjecutarSQL(sqltxt);
        }

        //ACTUALIZAR
        public bool Actualizar(TiposEmpleado tipoEmpleado)
        {
            string sqltxt = $"UPDATE [dbo].[TiposEmpleado] SET nombre = '{tipoEmpleado.nombre}' WHERE idTipoEmpleado = {tipoEmpleado.idTipoEmpleado}";

            return acceso_BD.Singleton().EjecutarSQL(sqltxt);
        }

        //ELIMINAR
        public bool Eliminar(string idTipoEmpleado)
        {
            string sqltxt = $"DELETE FROM [dbo].[TiposEmpleado] WHERE idTipoEmpleado = {idTipoEmpleado}";

            return acceso_BD.Singleton().EjecutarSQL(sqltxt);
        }

        //OBTENER UN OBJETO ESPECIFICO A TRAVES DE SU PK
        public TiposEmpleado ObtenerTipoEmpleado(string idTipoEmpleado)
        {
            string sqltxt = $"SELECT * FROM [dbo].[TiposEmpleado] WHERE idTipoEmpleado = {idTipoEmpleado}";
            var tablaTemporal = acceso_BD.Singleton().consulta(sqltxt);

            if (tablaTemporal.Rows.Count == 0)
                return null;

            var tipoEmpleado = new TiposEmpleado();
            foreach (DataRow fila in tablaTemporal.Rows)
            {
                if (fila.HasErrors)
                    continue;

                tipoEmpleado.idTipoEmpleado = int.Parse(fila.ItemArray[0].ToString()); // idTipoEmpleado
                tipoEmpleado.nombre = fila.ItemArray[1].ToString();// Nombre Tipo Empleado
            }
            return tipoEmpleado;
        }
    }
}
