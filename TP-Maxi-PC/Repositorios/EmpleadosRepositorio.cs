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
    class EmpleadosRepositorio
    {
        public EmpleadosRepositorio()
        {

        }

        //OBTENER TABLA Y CONVERTIRLA A LISTA
        public DataTable ObtenerEmpleadosDT()
        {
            string sqltxt = "SELECT e.legajo, td.nombre, e.nroDocumento, e.apellido, e.nombre, te.nombre, e.fechaAlta, e.fechaBaja " +
            "FROM Empleados e INNER JOIN TiposDocumento td ON e.tipoDocumento = td.idTipoDocumento" +
            " INNER JOIN TiposEmpleado te ON e.idTipoEmpleado = te.idTipoEmpleado";

            return acceso_BD.Singleton().consulta(sqltxt);
        }

        public List<Empleado> ObtenerEmpleados()
        {
            var tablaTemporal = ObtenerEmpleadosDT();
            var empleados = new List<Empleado>();
            foreach (DataRow fila in tablaTemporal.Rows)
            {
                var empleado = new Empleado();
                if (fila.HasErrors)
                    continue;

                // tratamiento de fechas
                DateTime fecha = DateTime.MinValue;
                DateTime fecha1 = DateTime.MinValue;

                // Si lo que esta en la BD de datos se puede parsear a date se lo parsea y almacena en la varaible fecha
                DateTime.TryParse(fila.ItemArray[6]?.ToString(), out fecha);
                DateTime.TryParse(fila.ItemArray[7]?.ToString(), out fecha1);

                empleado.legajo = int.Parse(fila.ItemArray[0].ToString()); // Legajo
                empleado.TiposDocumento = new TiposDocumento() { nombre = fila.ItemArray[1].ToString() };// Nombre Tipo Documento
                empleado.nroDocumento = int.Parse(fila.ItemArray[2].ToString()); // Nro Documento
                empleado.apellido = fila.ItemArray[3].ToString(); // Apellido
                empleado.nombre = fila.ItemArray[4].ToString(); // Nombre
                empleado.idTipoEmpleado = new TiposEmpleado() { nombre = fila.ItemArray[5].ToString() }; // Nombre Tipo Empleado
                empleado.fechaAlta = fecha; // Fecha Alta
                empleado.fechaBaja = fecha1; // Fecha Baja

                empleados.Add(empleado);
            }
            return empleados;
        }

        //GUARDAR (VER SI SE PUEDEN SACAR LOS SET IDENTITY AL ELIMINAR LAS PK)
        public bool Guardar(Empleado empleado)
        {
            string sqltxt = $"SET IDENTITY_INSERT [dbo].[Empleados] ON " +
                $"INSERT [dbo].[Empleados] ([legajo], [tipoDocumento], [nroDocumento], [apellido], [nombre], [idTipoEmpleado], [fechaAlta], [fechaBaja]) " +
                $"VALUES ('{empleado.legajo}', '{empleado.TiposDocumento.idTipoDocumento}', '{empleado.nroDocumento}', '{empleado.apellido}', '{empleado.nombre}', '{empleado.idTipoEmpleado.idTipoEmpleado}', '{empleado.fechaAlta.ToString("yyyy-MM-dd")}', '{empleado.fechaBaja.ToString("yyyy-MM-dd")}')" +
                $"SET IDENTITY_INSERT [dbo].[Empleados] OFF";

            return acceso_BD.Singleton().EjecutarSQL(sqltxt);
        }

        //ACTUALIZAR
        public bool Actualizar(Empleado empleado)
        {
            string sqltxt = $"UPDATE [dbo].[Empleados] SET tipoDocumento = '{empleado.TiposDocumento.idTipoDocumento}'," +
                $"nroDocumento = '{empleado.nroDocumento}', apellido= '{empleado.apellido}', nombre = '{empleado.nombre}', idTipoEmpleado = '{empleado.idTipoEmpleado.idTipoEmpleado}', fechaAlta = '{empleado.fechaAlta.ToString("yyyy-MM-dd")}', fechaBaja = '{empleado.fechaBaja.ToString("yyyy-MM-dd")}' WHERE legajo = {empleado.legajo}";

            return acceso_BD.Singleton().EjecutarSQL(sqltxt);
        }

        //ELIMINAR
        public bool Eliminar(string empleadoLeg)
        {
            string sqltxt = $"DELETE FROM [dbo].[Empleados] WHERE legajo = {empleadoLeg}";

            return acceso_BD.Singleton().EjecutarSQL(sqltxt);
        }

        //OBTENER TABLA DE TIPOEMPLEADOS
        public DataTable ObtenerTipoEmpleado()
        {
            string sqltxt = "SELECT * FROM tiposEmpleado";
            return acceso_BD.Singleton().consulta(sqltxt);
        }

        //OBTENER UN OBJETO ESPECIFICO A TRAVES DE SU PK
        public Empleado ObtenerEmpleado(string empleadoLegajo)
        {
            string sqltxt = $"SELECT * FROM [dbo].[Empleados] WHERE legajo = {empleadoLegajo}";
            var tablaTemporal = acceso_BD.Singleton().consulta(sqltxt);

            if (tablaTemporal.Rows.Count == 0)
                return null;

            var empleado = new Empleado();
            foreach (DataRow fila in tablaTemporal.Rows)
            {
                if (fila.HasErrors)
                    continue; // no corto el ciclo

                // tratamiento de fechas
                DateTime fecha = DateTime.MinValue;
                DateTime fecha1 = DateTime.MinValue;

                // Si lo que esta en la BD de datos se puede parsear a date se lo parsea y almacena en la varaible fecha
                DateTime.TryParse(fila.ItemArray[6]?.ToString(), out fecha);
                DateTime.TryParse(fila.ItemArray[7]?.ToString(), out fecha1);

                empleado.legajo = int.Parse(fila.ItemArray[0].ToString()); // Legajo
                empleado.TiposDocumento = new TiposDocumento() { idTipoDocumento = int.Parse(fila.ItemArray[1].ToString()) };// Tipo Documento
                empleado.nroDocumento = int.Parse(fila.ItemArray[2].ToString()); // Nro Documento
                empleado.apellido = fila.ItemArray[3].ToString(); // Apellido
                empleado.nombre = fila.ItemArray[4].ToString(); // Nombre
                empleado.idTipoEmpleado = new TiposEmpleado() { idTipoEmpleado = int.Parse(fila.ItemArray[5].ToString()) }; // Id Tipo Empleado
                empleado.fechaAlta = fecha; // Fecha Alta
                empleado.fechaBaja = fecha1; // Fecha Baja
            }
            return empleado;
        }
    }
}
