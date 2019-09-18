using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
//Esta clase en parte de una de las capas de programación en el modelo de tres capas.
//Es la capa de atrás (backend) que conecta con la base de datos y realiza toda acción
//con la base de datos
namespace TP_Maxi_PC.Helpers
{
    class acceso_BD
    {
        private static acceso_BD _accesoDBSingleton;

        private readonly OleDbConnection conexion;

        private readonly OleDbCommand cmd;

        private readonly string cadena_conexion = "Provider=SQLNCLI11;workstation id=PAV-Maxi-PC.mssql.somee.com;" +
            "packet size=4096;user id=BraianEmanuel19_SQLLogin_1;pwd=6aef7thwh9;data source=PAV-Maxi-PC.mssql.somee.com;" +
            "persist security info=False;initial catalog=PAV-Maxi-PC";

        private acceso_BD()
        {
            conexion = new OleDbConnection();
            cmd = new OleDbCommand();
        }

        public static acceso_BD Singleton()
        {
            if (_accesoDBSingleton == null)
                _accesoDBSingleton = new acceso_BD();
            return _accesoDBSingleton;
        }

        private void conectar()
        {
            //asigan al objeto <conexion> la cadena de conexion
            conexion.ConnectionString = cadena_conexion;
            //agrega la conexion (se crea el pipe entre la aplicación y la base de datos)
            conexion.Open();
            //se comunica al objeto <cmd> sobre que conexion debe trabajar
            cmd.Connection = conexion;
            //se establece el tipo de comando que va ha ejecutar
            cmd.CommandType = CommandType.Text;
        }
        //procedimiento privado <cerrar> que finaliza la conexión con la base de datos
        private void cerrar()
        {
            //cierra la conexión con la base de datos
            conexion.Close();
        }
        //función pública <consulta> que permite a través de parámetro de entra recibir
        //un comando SQL del tipo SELECT para ser ejecutado en la base de datos.
        //Este comando SELECT selecciona un conjunto de datos en la base de datos, que
        //es devuelto un cursor a travéz de <cmd>.
        //Por esto la función tiene como valor de devolución una DataTable.
        public DataTable consulta(string comando)
        {
            //ejecuta el procedimiento local <conectar>
            conectar();
            //asigna a <cmd> el comando que se debe ejecutar, que viene por parámetro
            //de entrada <comando>
            cmd.CommandText = comando;
            //instancia un objeto <tabla> del tipo DataTable
            DataTable tabla = new DataTable();
            //aquí dos acciones. 1) Ejecuta el comando SQL que ingreso por parámetro de entrada
            //en el pedazo de comando <cmd.ExecuteReader()>
            //2) Carga la tabla con el valor de resultado del comando SQL en el pedazo de texto
            //<tabla.Load(. . . )>
            tabla.Load(cmd.ExecuteReader());
            //ejecuta el procedimiento <cerrar>
            cerrar();
            //devuelve el valor calculado a través de la función
            return tabla;
        }

        public bool EjecutarSQL(string comando)
        {
            conectar();

            cmd.CommandText = comando;

            var filasAfectadas = cmd.ExecuteNonQuery(); //Cantidad de filas afectadas

            //ejecuta el procedimiento <cerrar>
            cerrar();

            return filasAfectadas > 0;
        }


        public bool EjecutarSentenciaPreparadaSQL(string comando)
        {
            conectar();

            cmd.CommandText = comando;

            var filasAfectadas = cmd.ExecuteNonQuery(); //Cantidad de filas afectadas

            //ejecuta el procedimiento <cerrar>
            cerrar();

            return filasAfectadas > 0;
        }
    }
}
