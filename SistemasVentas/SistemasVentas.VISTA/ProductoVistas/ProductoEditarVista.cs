using SistemasVentas.BSS;
using SistemasVentas.Modelos;
using SistemasVentas.VISTA.MarcaVistas;
using SistemasVentas.VISTA.TipoProdVistas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemasVentas.VISTA.ProductoVistas
{
    public partial class ProductoEditarVista : Form
    {
        int idx = 0;
        Producto p = new Producto();
        ProductoBss bss = new ProductoBss();
        public ProductoEditarVista(int id)
        {
            idx = id;
            InitializeComponent();
        }

        private void ProductoEditarVista_Load(object sender, EventArgs e)
        {
            p = bss.ObtenerProductoIdBss(idx);
            marca = bssmar.ObtenerMarcaIdBss(p.IdMarca);
            IdMarcaSeleccionada = p.IdMarca;
            tipoprod = bsstip.ObtenerTipoProdIdBss(p.IdTipoProducto);
            IdTipoProdSeleccionada = p.IdTipoProducto;
            textBox1.Text = tipoprod.Nombre;
            textBox2.Text = marca.Nombre;
            textBox3.Text = p.Nombre;
            textBox4.Text = p.CodigoBarra;
            textBox5.Text = p.Unidad.ToString();
            textBox6.Text = p.Descripcion;
            textBox7.Text = p.Estado;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            p.IdTipoProducto = IdTipoProdSeleccionada;
            p.IdMarca = IdMarcaSeleccionada;
            p.Nombre = textBox3.Text;
            p.CodigoBarra = textBox4.Text;
            p.Unidad = Convert.ToInt32(textBox5.Text);
            p.Descripcion = textBox6.Text;
            p.Estado = textBox7.Text;

            bss.EditarProductoBss(p);
            MessageBox.Show("Datos Actualizados");
        }

        public static int IdTipoProdSeleccionada = 0;
        TipoProdBss bsstip = new TipoProdBss();
        TipoProd tipoprod = new TipoProd();
        private void button3_Click(object sender, EventArgs e)
        {
            TipoProdListarVista fr = new TipoProdListarVista();
            if (fr.ShowDialog() == DialogResult.OK)
            {
                TipoProd tipoprod = bsstip.ObtenerTipoProdIdBss(IdTipoProdSeleccionada);
                IdTipoProdSeleccionada = tipoprod.IdTipoProd;
                textBox1.Text = tipoprod.Nombre;
            }
        }

        public static int IdMarcaSeleccionada = 0;
        MarcaBss bssmar = new MarcaBss();
        Marca marca = new Marca();
        private void button4_Click(object sender, EventArgs e)
        {
            MarcaListarVista fr = new MarcaListarVista();
            if (fr.ShowDialog() == DialogResult.OK)
            {
                Marca marca = bssmar.ObtenerMarcaIdBss(IdMarcaSeleccionada);
                IdMarcaSeleccionada = marca.IdMarca;
                textBox2.Text = marca.Nombre;
            }
        }
    }
}
