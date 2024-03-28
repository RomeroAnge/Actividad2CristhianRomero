using SistemasVentas.BSS;
using SistemasVentas.Modelos;
using SistemasVentas.VISTA.PersonaVistas;
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

namespace SistemasVentas.VISTA.UsuarioVistas
{
    public partial class UsuarioEditarVista : Form
    {
        int idx = 0;
        Usuario p = new Usuario();
        UsuarioBss bss = new UsuarioBss();
        public UsuarioEditarVista(int id)
        {
            idx = id;
            InitializeComponent();
        }
        private void UsuarioEditarVista_Load(object sender, EventArgs e)
        {
            p = bss.ObtenerUsuarioIdBss(idx);
            persona = bssper.ObtenerPersonaIdBss(p.IdPersona);
            textBox1.Text = persona.Nombre + " " + persona.Apellido;
            IdPersonaSeleccionada = persona.IdPersona;
            textBox2.Text = p.NombreUser;
            textBox3.Text = p.Contraseña;
            dateTimePicker1.Value = p.FechaReg;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            p.IdPersona = IdPersonaSeleccionada;
            p.NombreUser = textBox2.Text;
            p.Contraseña = textBox3.Text;
            p.FechaReg = dateTimePicker1.Value;
            bss.EditarUsuarioBss(p);
            MessageBox.Show("Datos Actualizados");
        }

        public static int IdPersonaSeleccionada = 0;
        Persona persona = new Persona();
        PersonaBss bssper = new PersonaBss();
        private void button3_Click(object sender, EventArgs e)
        {
            PersonaListarVista fr = new PersonaListarVista();
            if (fr.ShowDialog() == DialogResult.OK)
            {
                Persona persona = bssper.ObtenerPersonaIdBss(IdPersonaSeleccionada);
                IdPersonaSeleccionada = persona.IdPersona;
                textBox1.Text = persona.Nombre + " " + persona.Apellido;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
