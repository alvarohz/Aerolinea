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
using Aerolinea.Controladores;

namespace Aerolinea
{
    public partial class Form1 : Form
    {
        private ControladorPaises controladorPaises;
        int operacion=0;
        public Form1()
        {
            InitializeComponent();

            controladorPaises = new ControladorPaises();

            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "ID Pais";
            dataGridView1.Columns[0].Width = 60;
            dataGridView1.Columns[0].DataPropertyName = "idpais";
            dataGridView1.Columns[1].Name = "Pais";
            dataGridView1.Columns[1].Width = 300;
            dataGridView1.Columns[1].DataPropertyName = "pais";
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = controladorPaises.ListarPaises();            
            deshabilitar();
        }

        public void habilitar() {
            txtIdpais.Enabled = true;
            txtPais.Enabled = true;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            txtPais.Focus();
            dataGridView1.Enabled = false;
            txtBuscar.Enabled = false;
            btnAgregar.Enabled = false;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        public void deshabilitar()
        {
            txtIdpais.Enabled = false;
            txtPais.Enabled = false;
            txtIdpais.Text = "";
            txtPais.Text = "";
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;            
            dataGridView1.Enabled = true;
            txtBuscar.Enabled = true;
            btnAgregar.Enabled = true;
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
            dataGridView1.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            deshabilitar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            habilitar();
            operacion = 1;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (operacion == 1) {                
                paises p = new paises();
                p.pais = txtPais.Text.ToUpper();
                if (controladorPaises.InsertarPais(p))
                    MessageBox.Show("Registro guardado satisfactoriamente");
                else
                    MessageBox.Show("Ocurrio un error al insertar registro");
                dataGridView1.DataSource = controladorPaises.ListarPaises();
                deshabilitar();
            }
            else if (operacion == 2) {                
                paises p = new paises();
                p.pais = txtPais.Text.ToUpper();
                int id = Convert.ToInt32(txtIdpais.Text);
                if (controladorPaises.ModificarPais(id, p))
                    MessageBox.Show("Registro actualizado satisfactoriamente");
                else
                    MessageBox.Show("Ocurrio un error al actualizar registro");
                dataGridView1.DataSource = controladorPaises.ListarPaises();
                deshabilitar();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            txtIdpais.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtPais.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            habilitar();
            operacion = 2;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Desea eliminar este registro?", "Alert", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes) { 
                int id =(int)dataGridView1.CurrentRow.Cells[0].Value;
                if (controladorPaises.EliminarPais(id))
                    MessageBox.Show("Registro eliminado satisfactoriamente");
                else
                    MessageBox.Show("Ocurrio un error al eliminar registro");
                dataGridView1.DataSource = controladorPaises.ListarPaises();
                txtBuscar.Focus();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = controladorPaises.ListarPaises(txtBuscar.Text);
        }
    }
}
