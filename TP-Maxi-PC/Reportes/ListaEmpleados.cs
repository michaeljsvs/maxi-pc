using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_Maxi_PC.Helpers;


namespace TP_Maxi_PC.Reportes
{
    public partial class ListaEmpleados : Form
    {

        

        public ListaEmpleados()
        {
            
            InitializeComponent();
        }

        private void ListaEmpleados_Load(object sender, EventArgs e)
        {

            this.reporteEmpleados.RefreshReport();
            this.reporteEmpleados.RefreshReport();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                ReportParameter p;
                p = new ReportParameter("activo", chkActivo.Checked.ToString());
                this.reporteEmpleados.LocalReport.SetParameters(p);

                p = new ReportParameter("noActivo", chkNoActivo.Checked.ToString());
                this.reporteEmpleados.LocalReport.SetParameters(p);

                p = new ReportParameter("desde", txtDesde.Value.Date.ToString());
                this.reporteEmpleados.LocalReport.SetParameters(p);

                p = new ReportParameter("hasta", txtHasta.Value.Date.ToString());
                this.reporteEmpleados.LocalReport.SetParameters(p);

                string consultaActivos = "SELECT E.legajo, TD.nombre As 'tipoDoc', E.nroDocumento As 'nroDoc'," +
                    " (E.apellido+', '+E.nombre) As 'nombre', TE.nombre As 'tipoEmpleado', E.fechaAlta, E.fechaBaja" +
                    " FROM Empleados E INNER JOIN TiposDocumento TD ON E.tipoDocumento = TD.idTipoDocumento" +
                    " INNER JOIN TiposEmpleado te ON e.idTipoEmpleado = te.idTipoEmpleado" +
                    " WHERE E.fechaBaja IS NULL ORDER BY E.fechaAlta";

                string consultaExEmpleados = "SELECT E.legajo, TD.nombre As 'tipoDoc', E.nroDocumento As 'nroDoc'," +
                    " (E.apellido+', '+E.nombre) As 'nombre', TE.nombre As 'tipoEmpleado', E.fechaAlta, E.fechaBaja" +
                    " FROM Empleados E INNER JOIN TiposDocumento TD ON E.tipoDocumento = TD.idTipoDocumento" +
                    " INNER JOIN TiposEmpleado te ON e.idTipoEmpleado = te.idTipoEmpleado" +
                    " WHERE E.fechaBaja IS NOT NULL ORDER BY E.fechaAlta";

                DataTable tabla1 = acceso_BD.Singleton().consulta(consultaActivos);
                ReportDataSource ds = new ReportDataSource("empleadosActivos", tabla1);
                DataTable tabla2 = acceso_BD.Singleton().consulta(consultaExEmpleados);
                ReportDataSource ds2 = new ReportDataSource("exEmpleados", tabla2);

                this.reporteEmpleados.LocalReport.DataSources.Clear();
                this.reporteEmpleados.LocalReport.DataSources.Add(ds);
                this.reporteEmpleados.LocalReport.DataSources.Add(ds2);
                this.reporteEmpleados.LocalReport.Refresh();

                this.reporteEmpleados.RefreshReport();

            }
        }

        public bool validar()
        {
            if (!chkActivo.Checked & !chkNoActivo.Checked)
            {
                MessageBox.Show("Seleccione al menos una opción");
                return false;
            }

            if (txtDesde.Value >= txtHasta.Value)
            {
                MessageBox.Show("Ingrese un período de tiempo válido");
                return false;
            }

            return true;
        }
    }
}
