using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aerolinea.Modelos;
using Aerolinea.Conexion;

namespace Aerolinea
{
    public partial class Form2 : Form
    {
        private Model model;
        private usuarios user;
        public Form2()
        {
            InitializeComponent();
            model = new Model();
            Object u = model
                .Entidades
                .usuarios
                .Select(
                p => new { 
                    p.idusuario, 
                    p.nombres, 
                    p.roles.rol,
                    p.paises.pais
                })
                .ToList();
            dataGridView1.DataSource = u;
            cmbPais.DisplayMember = "pais";
            cmbPais.ValueMember = "idpais";
            cmbPais.DataSource = model.Entidades.paises.ToList();
            cmbRol.DisplayMember = "rol";
            cmbRol.ValueMember = "idrol";
            cmbRol.DataSource = model.Entidades.roles.ToList();
            //user = aerolineaContext.usuarios.Find("admin");
            //txtIdusuario.DataBindings.Add("Text", user, "idusuario");
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            usuarios u = new usuarios();
            u.idusuario = txtIdusuario.Text;
            u.nombres = "juan";
            u.apellidos = "perez";
            u.email = "juan@aerolinea";
            u.telefono = "1234";
            u.clave = "1234";
            u.idpais = (int)cmbPais.SelectedValue;
            u.idrol = (int)cmbRol.SelectedValue;
            model.Entidades.usuarios.Add(u);
            model.Entidades.SaveChanges();
            dataGridView1.DataSource = model.Entidades.usuarios.ToList();
        }
    }
}
