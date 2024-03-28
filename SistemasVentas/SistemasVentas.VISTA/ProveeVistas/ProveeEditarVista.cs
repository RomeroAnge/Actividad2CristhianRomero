using SistemasVentas.BSS;
using SistemasVentas.Modelos;
using SistemasVentas.VISTA.ProductoVistas;
using SistemasVentas.VISTA.ProveedorVistas;
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

namespace SistemasVentas.VISTA.ProveeVistas
{
    public partial class ProveeEditarVista : Form
    {
        int idx = 0;
        Provee p = new Provee();
        ProveeBss bss = new ProveeBss();
        public ProveeEditarVista(int id)
        {
            idx = id;
            InitializeComponent();
        }

        private void ProveeEditarVista_Load(object sender, EventArgs e)
        {
            p = bss.ObtenerProveeIdBss(idx);
            producto = bsspro.ObtenerProductoIdBss(p.IdProducto);
            IdProductoSeleccionada = p.IdProducto;
            proveedor = bssprov.ObtenerProveedorIdBss(p.IdProveedor);
            IdProveedorSeleccionada= p.IdProveedor;
            textBox1.Text = producto.Nombre;
            textBox2.Text = proveedor.Nombre;
            dateTimePicker1.Value = p.Fecha;
            textBox3.Text = p.Precio.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            p.IdProducto = IdProductoSeleccionada;
            p.IdProveedor = IdProveedorSeleccionada;
            p.Fecha = dateTimePicker1.Value;
            p.Precio = Convert.ToDecimal(textBox3.Text);

            bss.EditarProveeBss(p);
            MessageBox.Show("Datos Actualizados");
        }
        public static int IdProductoSeleccionada = 0;
        ProductoBss bsspro = new ProductoBss();
        Producto producto = new Producto();
        private void button3_Click(object sender, EventArgs e)
        {
            ProductoListarVista fr = new ProductoListarVista();
            if (fr.ShowDialog() == DialogResult.OK)
            {
                Producto producto = bsspro.ObtenerProductoIdBss(IdProductoSeleccionada);
                IdProductoSeleccionada = producto.IdProducto;
                textBox1.Text = producto.Nombre;
            }
        }
        public static int IdProveedorSeleccionada = 0;
        ProveedorBss bssprov = new ProveedorBss();
        Proveedor proveedor = new Proveedor();
        private void button4_Click(object sender, EventArgs e)
        {
            ProveedorListarVista fr = new ProveedorListarVista();
            if (fr.ShowDialog() == DialogResult.OK)
            {
                Proveedor proveedor = bssprov.ObtenerProveedorIdBss(IdProveedorSeleccionada);
                IdProveedorSeleccionada = proveedor.IdProveedor;
                textBox2.Text = proveedor.Nombre;
            }
        }
    }
}
