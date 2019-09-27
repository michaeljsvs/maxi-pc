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
    class TiposDocumentoRepositorio
    {

        public TiposDocumentoRepositorio()
        {

        }

        //OBTENER TABLA Y CONVERTIRLA A LISTA
        public DataTable ObtenerTiposDocumentoDT()
        {
            string sqltxt = "SELECT * FROM TiposDocumento";
            return acceso_BD.Singleton().consulta(sqltxt);
        }

        public List<TiposDocumento> ObtenerTiposDocumento()
        {
            var tablaTemporal = ObtenerTiposDocumentoDT();
            var tiposDocumento = new List<TiposDocumento>();
            foreach (DataRow fila in tablaTemporal.Rows)
            {
                var tipoDocumento = new TiposDocumento();
                if (fila.HasErrors)
                    continue;

                tipoDocumento.idTipoDocumento = int.Parse(fila.ItemArray[0].ToString()); // idTipoDocumento
                tipoDocumento.nombre = fila.ItemArray[1].ToString();// Nombre Tipo Documento

                tiposDocumento.Add(tipoDocumento);
            }
            return tiposDocumento;
        }

        //GUARDAR (VER SI SE PUEDEN SACAR LOS SET IDENTITY AL ELIMINAR LAS PK)
        public bool Guardar(TiposDocumento tipoDocumento)
        {
            string sqltxt = $"SET IDENTITY_INSERT [dbo].[TiposDocumento] ON " +
                $"INSERT [dbo].[TiposDocumento] ([idTipoDocumento], [nombre]) " +
                $"VALUES ('{tipoDocumento.idTipoDocumento}', '{tipoDocumento.nombre}')" +
                $"SET IDENTITY_INSERT [dbo].[TiposDocumento] OFF";

            return acceso_BD.Singleton().EjecutarSQL(sqltxt);
        }

        //ACTUALIZAR
        public bool Actualizar(TiposDocumento tipoDocumento)
        {
            string sqltxt = $"UPDATE [dbo].[TiposDocumento] SET nombre = '{tipoDocumento.nombre}' WHERE idTipoDocumento = {tipoDocumento.idTipoDocumento}";

            return acceso_BD.Singleton().EjecutarSQL(sqltxt);
        }

        //ELIMINAR
        public bool Eliminar(string idTipoDocumento)
        {
            string sqltxt = $"DELETE FROM [dbo].[TiposDocumento] WHERE idTipoDocumento = {idTipoDocumento}";

            return acceso_BD.Singleton().EjecutarSQL(sqltxt);
        }

        //OBTENER UN OBJETO ESPECIFICO A TRAVES DE SU PK
        public TiposDocumento ObtenerTipoDocumento(string idTipoDocumento)
        {
            string sqltxt = $"SELECT * FROM [dbo].[TiposDocumento] WHERE idTipoDocumento = {idTipoDocumento}";
            var tablaTemporal = acceso_BD.Singleton().consulta(sqltxt);

            if (tablaTemporal.Rows.Count == 0)
                return null;

            var tipoDocumento = new TiposDocumento();
            foreach (DataRow fila in tablaTemporal.Rows)
            {
                if (fila.HasErrors)
                    continue;

                tipoDocumento.idTipoDocumento = int.Parse(fila.ItemArray[0].ToString()); // idTipoDocumento
                tipoDocumento.nombre = fila.ItemArray[1].ToString();// Nombre Tipo Documento
            }
            return tipoDocumento;
        }
    }
}
