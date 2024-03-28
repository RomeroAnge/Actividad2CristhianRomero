using SistemasVentas.BSS;
using SistemasVentas.Modelos;
using SistemasVentas.VISTA.ProductoVistas;
using SistemasVentas.VISTA.VentaVistas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SistemasVentas.VISTA.DetalleVentaVistas
{
    public partial class DetalleVentaEditarVista : Form
    {
        int idx = 0;
        DetalleVent p = new DetalleVent();
        DetalleVentaBss bss = new DetalleVentaBss();
        public DetalleVentaEditarVista(int id)
        {
            idx = id;
            InitializeComponent();
        }

        private void DetalleVentaEditarVista_Load(object sender, EventArgs e)
        {
            p = bss.ObtenerDetalleVentaIdBss(idx);
            venta = bssven.ObtenerVentaIdBss(p.IdVenta);
            IdVentaSeleccionada = p.IdVenta;
            producto = bsspro.ObtenerProductoIdBss(p.IdProducto);
            IdProductoSeleccionada = p.IdProducto;
            textBox1.Text = venta.IdVenta.ToString();
            textBox2.Text = producto.Nombre;
            textBox3.Text = p.Cantidad.ToString();
            textBox4.Text = p.PrecioVenta.ToString();
            textBox5.Text = p.SubTotal.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            p.IdVenta = IdVentaSeleccionada;
            p.IdProducto = IdProductoSeleccionada;
            p.Cantidad = Convert.ToInt32(textBox3.Text);
            p.PrecioVenta = Convert.ToDecimal(textBox4.Text);
            p.SubTotal = Convert.ToDecimal(textBox5.Text);

            bss.EditarDetalleVentaBss(p);
            MessageBox.Show("Datos Actualizados");
        }
        public static int IdVentaSeleccionada = 0;
        VentaBss bssven = new VentaBss();
        Venta venta = new Venta();
        private void button3_Click(object sender, EventArgs e)
        {
            VentaListarVista fr = new VentaListarVista();
            if (fr.ShowDialog() == DialogResult.OK)
            {
                Venta venta = bssven.ObtenerVentaIdBss(IdVentaSeleccionada);
                IdVentaSeleccionada = venta.IdVenta;
                textBox1.Text = venta.IdVenta.ToString();
            }
        }
        public static int IdProductoSeleccionada = 0;
        ProductoBss bsspro = new ProductoBss();
        Producto producto = new Producto();
        private void button4_Click(object sender, EventArgs e)
        {
            ProductoListarVista fr = new ProductoListarVista();
            if (fr.ShowDialog() == DialogResult.OK)
            {
                Producto producto = bsspro.ObtenerProductoIdBss(IdProductoSeleccionada);
                IdProductoSeleccionada = producto.IdProducto;
                textBox2.Text = producto.Nombre;
            }
        }
    }
}
