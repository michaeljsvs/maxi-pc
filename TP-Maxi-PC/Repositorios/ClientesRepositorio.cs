using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using TP_Maxi_PC.Helpers;

namespace TP_Maxi_PC.Repositorios
{
    public class ClientesRepositorio
    {
        private acceso_BD BD;

        public ClientesRepositorio()
        {
            BD = new acceso_BD();
        }


        public DataTable obtenerClientesDT()
        {
            string sql = "SELECT C.idCliente,T.nombre,C.nroDocumento,C.apellido,C.nombre,C.sexo,C.fechaIngreso,C.calle,C.nroCalle,B.nombre FROM Clientes C JOIN tiposDocumento T ON T.idTipoDocumento = C.tipoDocumento JOIN Barrios B ON B.idBarrio = C.idBarrio";

            return BD.consulta(sql);
        }
        
        public DataTable obtenerBarriosDT()
        {
            string sql = "SELECT * FROM Barrios";
            return BD.consulta(sql);
        }

        public DataTable obtenerDniDT()
        {
            string sql = "SELECT * FROM TiposDocumento";
            return BD.consulta(sql);
        }
        public bool insertarCliente(string nombre,string apellido,char sexo, DateTime fechaIngreso,string calle, String nroCalle,int idBarrio,int tipoDoc,int dni)
        {
            string sql = $"INSERT [dbo].[Clientes] ([tipoDocumento],[nroDocumento],[nombre],[apellido],[sexo],[fechaIngreso],[calle],[nroCalle],[idBarrio])" +
                    $" VALUES ('{tipoDoc}','{dni}','{nombre}','{apellido}','{sexo}','{fechaIngreso.ToString("yyyy-MM-dd")}','{calle}','{nroCalle}','{idBarrio}')";
            return BD.EjecutarSQL(sql);
        }

        public bool modificarCliente(int id, string nombre, string apellido, char sexo, DateTime fechaIngreso, string calle, String nroCalle, int idBarrio, int tipoDoc, int dni)
        {
            string sql = $"UPDATE [dbo].[Clientes] SET tipoDocumento = {tipoDoc},nroDocumento = {dni},nombre = '{nombre}',apellido= '{apellido}',sexo = '{sexo}',fechaIngreso= '{fechaIngreso.ToString("yyyy-MM-dd")}',calle = '{calle}',nroCalle = '{nroCalle}',idBarrio ={idBarrio} WHERE idCliente = {id}";
            return BD.EjecutarSQL(sql);
        }

        public void borrarCliente(String id)
        {
            string sql = "DELETE [dbo].[Clientes] WHERE idCliente = " + id;
             BD.EjecutarSQL(sql);
        }
    }
}
