﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using DevExpress.XtraEditors;
using CeramicaCarrillo.Model;
using System.Windows.Forms;
using System.Drawing;

using CeramicaCarrillo.Model.Mensajes;

namespace CeramicaCarrillo.GUI.Ventas
{
    public partial class frmXtraCobroV : DevExpress.XtraEditors.XtraForm
    {
        public static BDCarrilloEntities datos = null;
        public static bool mayorista = false;
        Sesiones sesion;
        List<Model.Productos> Compra;
        List<int> Cantidad;
        double total = 0;

        public frmXtraCobroV(List<Model.Productos> lista, List<int> unidades, String Total, Sesiones ses)
        {
            InitializeComponent();
            Compra = lista;
            Cantidad = unidades;
            txtTotal.Text = Total;
            sesion = ses;
        }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            validarCobro();
        }

        private void validarCobro()
        {
            double validar = Convert.ToDouble(txtTotal.Text) - Convert.ToDouble(txtMonto.Text);
            if ((validar) <= 0)
            {
                if (XtraMessageBox.Show("¿De sea realizar la compra?", "Cobrando", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    realizarCompra();
                    DialogResult = DialogResult.OK;
                }
            }
            else
            {
                MessageBox.Show("El monto ingresado no cubre el total de la compra.");
            }
        }

        private void realizarCompra()
        {
            try
            {
                double totalVenta = 0;
                Folio folio = new Folio();
                folio.FechaVenta = DateTime.Now;
                folio.IdPersonal = sesion.Id;
                folio.Status = true;
                folio.Faltante = 0;
                datos.Folio.Add(folio);
                datos.SaveChanges();
                int idFolio = Convert.ToInt32((from f in datos.Folio orderby f.IdFolio descending select f.IdFolio).ToList()[0]);
                DetalleFolio detalle;
                for (int i = 0; i < Compra.Count; i++)
                {
                    detalle = new DetalleFolio();
                    detalle.IdFolio = idFolio;
                    Model.Productos producto = datos.Productos.Find(Compra[i].IdProductos);
                    producto.Unidades -= Cantidad[i];
                    detalle.IdProductos = producto.IdProductos;
                    detalle.Precio = (mayorista) ? producto.PrecioMayoreo : producto.PrecioVenta;
                    detalle.Unidades = Cantidad[i];
                    detalle.Total = Cantidad[i] * detalle.Precio;
                    totalVenta += detalle.Total;
                    datos.DetalleFolio.Add(detalle);
                    datos.SaveChanges();
                }
                folio = datos.Folio.Find(idFolio);
                folio.TotalVenta = totalVenta;
                datos.SaveChanges();

                new MensajeVentaRealizada(sesion.Id);

                Hide();
            }
            catch (Exception e) {
                XtraMessageBox.Show("Error: " + e.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void frmXtraCobroV_Load(object sender, EventArgs e)
        {
            txtCambio.Text = "0";
            txtMonto.Focus();
            total = Convert.ToDouble(txtTotal.Text);
        }

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {
            if (txtMonto.Text != string.Empty)
            {
                double cambio = total - Convert.ToInt32(txtMonto.Text);
                if (cambio >= 0)
                {
                    txtCambio.ForeColor = Color.Green;
                    txtCambio.Text = "0";
                }
                else
                {
                    txtCambio.ForeColor = Color.Black;
                    txtCambio.Text = (cambio * -1).ToString();
                }
            }
            else { txtCambio.Text = "0"; }
        }
    }
}