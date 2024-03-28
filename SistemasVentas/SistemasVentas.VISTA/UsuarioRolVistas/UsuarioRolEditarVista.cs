using SistemasVentas.BSS;
using SistemasVentas.Modelos;
using SistemasVentas.VISTA.RolVistas;
using SistemasVentas.VISTA.UsuarioVistas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemasVentas.VISTA.UsuarioRolVistas
{
    public partial class UsuarioRolEditarVista : Form
    {
        int idx = 0;
        UsuarioRol p = new UsuarioRol();
        UsuarioRolBss bss = new UsuarioRolBss();
        public UsuarioRolEditarVista(int id)
        {
            idx = id;
            InitializeComponent();
        }

        private void UsuarioRolEditarVista_Load(object sender, EventArgs e)
        {
            p = bss.ObtenerUsuarioRolIdBss(idx);
            usuario = bssuser.ObtenerUsuarioIdBss(p.IdUsuario);
            rol = bssrol.ObtenerRolIdBss(p.IdRol);
            IdUsuarioSeleccionada = usuario.IdUsuario;
            IdRolSeleccionada = rol.IdRol;
            textBox1.Text = usuario.NombreUser;
            textBox2.Text = rol.Nombre;
            dateTimePicker1.Value = p.FechaAsigna;
            textBox3.Text = p.Estado;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            p.IdUsuario = IdUsuarioSeleccionada;
            p.IdRol = IdRolSeleccionada;
            p.FechaAsigna = dateTimePicker1.Value;
            p.Estado = textBox3.Text;
            bss.EditarUsuarioRolBss(p);
            MessageBox.Show("Datos Actualizados");
        }

        public static int IdUsuarioSeleccionada = 0;
        Usuario usuario = new Usuario();
        UsuarioBss bssuser = new UsuarioBss();
        private void button3_Click(object sender, EventArgs e)
        {
            UsuarioListarVista fr = new UsuarioListarVista();
            if (fr.ShowDialog() == DialogResult.OK)
            {
                Usuario usuario = bssuser.ObtenerUsuarioIdBss(IdUsuarioSeleccionada);
                IdUsuarioSeleccionada = usuario.IdUsuario;
                textBox1.Text = usuario.NombreUser;
            }
        }
        public static int IdRolSeleccionada = 0;
        RolBss bssrol = new RolBss();
        Rol rol = new Rol();
        private void button4_Click(object sender, EventArgs e)
        {
            RolListarVista fr = new RolListarVista();
            if (fr.ShowDialog() == DialogResult.OK)
            {
                Rol rol = bssrol.ObtenerRolIdBss(IdRolSeleccionada);
                IdRolSeleccionada = rol.IdRol;
                textBox2.Text = rol.Nombre;
            }
        }
    }
}
