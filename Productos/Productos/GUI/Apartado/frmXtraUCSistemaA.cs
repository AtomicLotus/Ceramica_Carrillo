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

namespace CeramicaCarrillo.GUI.Apartado
{
    public partial class frmXtraUCSistemaA : DevExpress.XtraEditors.XtraUserControl
    {
        public frmXtraUCSistemaA()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {
            folioApartadoTableAdapter.Fill(dsSisApartado.FolioApartado);
            abonosTableAdapter1.Fill(dsSisApartado.Abonos);
        }
    }
}
