using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Maxi_PC.Helpers;
using System.Data;
using System.Data.SqlClient;


namespace TP_Maxi_PC.Repositorios
{
    
    public class PCRepositorio
    {
        private acceso_BD BD;

        public PCRepositorio()
        {
            BD = acceso_BD.Singleton();
        }

        public DataTable obtenerPC()
        {
            string sql = "SELECT P.idPC,concat (D.nombre, ' ' , D.apellido) as duenio, A.nombre as marca, O.nombre as modelo, T.descripcion AS TipoPC, P.descripcion FROM PCs P JOIN Marcas A ON P.idMarca = A.idMarca JOIN Modelos O ON P.idModelo = O.idModelo JOIN TiposPCS T ON T.idTipoPC = P.idTipoPC JOIN Clientes D ON D.idCliente = P.idDueño";
            return acceso_BD.Singleton().consulta(sql);
        }

        public DataTable obtenerMarcasDT()
        {
            string sql = "SELECT * FROM Marcas";
            return acceso_BD.Singleton().consulta(sql);
        }
        public DataTable obtenerModelosDT()
        {
            string sql = "SELECT * FROM Modelos";
            return acceso_BD.Singleton().consulta(sql);
        }
        public DataTable obtenerModeloDT(int id)
        {
            string sql = "SELECT * FROM Modelos WHERE idMarca = " + id;
            return acceso_BD.Singleton().consulta(sql);
        }
        public DataTable obtenerTipos()
        {
            string sql = "SELECT * FROM TiposPCs";
            return acceso_BD.Singleton().consulta(sql);
        }
        public bool insertarPC(int dueño,int marca, int modelo, string descripcion,int tipoPC)
        {
            string sql = $"INSERT [dbo].[Pcs] ([idDueño],[idMarca],[idModelo],[descripcion],[idTipoPC]) VALUES ('" + dueño + "','" + marca +"','" + modelo + "','" + descripcion +"','"+ tipoPC + "')"; 
            return BD.EjecutarSQL(sql);
        }
        //public int obtenerID(string apellido)
        //{
        //    string sql = "SELECT idCliente FROM Clientes WHERE apellido = '" + apellido + "'";
        //    return Convert.ToInt32(BD.EjecutarSQL(sql));
        //}
        //public int obtenerIDMarca(string nombre)
        //{
        //    string sql = "SELECT idMarca FROM Marcas WHERE nombre = '" + nombre + "'";
        //    return Convert.ToInt32(BD.EjecutarSQL(sql));
        //}
        //public int obtenerIDModelo (string nombre)
        //{
        //    string sql = "SELECT idModelo FROM Modelos WHERE nombre = '" + nombre + "'";
        //    return Convert.ToInt32(BD.EjecutarSQL(sql));
        //}
    }
}
