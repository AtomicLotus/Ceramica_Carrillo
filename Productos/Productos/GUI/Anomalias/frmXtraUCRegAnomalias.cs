﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using CeramicaCarrillo.Model;

namespace CeramicaCarrillo.GUI.Anomalias
{
    public partial class frmXtraUCRegAnomalias : DevExpress.XtraEditors.XtraUserControl
    {
        public static BDCarrilloEntities bdCarrillo = null;

        public frmXtraUCRegAnomalias()
        {
            InitializeComponent();

            CargarDatos();
        }

        private void CargarDatos()
        {
            Actualizaciones.dtgAnomalias = gridControl1;
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            DevExpress.XtraReports.UI.ReportPrintTool imprimir = new DevExpress.XtraReports.UI.ReportPrintTool(new frmXtraReporteAnomalias());
            imprimir.ShowRibbonPreviewDialog();
        }
    }
}