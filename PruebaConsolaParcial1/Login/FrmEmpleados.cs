using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Login
{
    public partial class FrmEmpleados : Form
    {
        Empleado auxEmpleado;

        private FrmEmpleados()
        {
            InitializeComponent();
        }

        public FrmEmpleados(string usuario): this()
        {
            lblUsuario.Text = usuario;
        }

        private void btnAltaEmpleado_Click(object sender, EventArgs e)
        {
            lblNombre.Visible = true;
            lblApellido.Visible = true;
            lblUsuaEmpleado.Visible = true;
            lblSueldo.Visible = true;
            btnGuardar.Visible = true;
            btnModificar.Visible = false;
            txtBuscar.Enabled = false;
            btnBuscar.Enabled = false;
            txtBuscar.PlaceholderText = string.Empty;
            txtNombre.Visible = true;
            txtApellido.Visible = true;
            txtUsuario.Visible = true;
            txtSueldo.Visible = true;
            lblDni.Visible = true;
            txtDni.Visible = true;
            txtDatosEmpleado.Visible = false;
            lblDatosEmpleado.Visible = false;
            btnEliminar.Visible = false;
            Limpiar();
        }

        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            dgvListaEmpleados.DataSource = Comercio.ListaEmpleados.Values.ToArray();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            FrmMenuPrincipal frmMenu = new FrmMenuPrincipal(lblUsuario.Text);
            frmMenu.Show();
            this.Hide();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Administrador.AltaEmpleado(txtNombre.Text, txtApellido.Text, txtDni.Text, txtUsuario.Text, txtSueldo.Text))
            {
                lblAviso.Visible = true;
                lblAviso.ForeColor = Color.Green;
                lblAviso.Text = "Empleado dado de alta exitosamente.";
                dgvListaEmpleados.DataSource = null;
                dgvListaEmpleados.DataSource = Comercio.ListaEmpleados.Values.ToArray();
            }
            else
            {
                lblAviso.Visible = true;
                lblAviso.ForeColor = Color.Red;
                lblAviso.Text = "Hubo un problema al dar de alta al empleado, verifique datos ingresado (Ya existe el usuario?).";
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Empleado empleado = new Empleado("Prueba");
            Administrador auxAdmi = new Administrador("Prueba");

            auxEmpleado = Comercio.BuscarEmpleado(txtBuscar.Text);
            if(auxEmpleado != null)
            {
                txtNombre.Text = auxEmpleado.Nombre;
                txtApellido.Text = auxEmpleado.Apellido;
                txtDni.Text = auxEmpleado.Dni.ToString();
                txtUsuario.Text = auxEmpleado.Usuario;
                txtSueldo.Text = auxEmpleado.Sueldo.ToString();

                if (!Comercio.VerificarAdministrador(auxEmpleado.Usuario))
                    txtDatosEmpleado.Text = empleado.DatosEmpleadoToString(auxEmpleado.Legajo);
                else
                    txtDatosEmpleado.Text = auxAdmi.DatosEmpleadoToString(auxEmpleado.Legajo);
            }
            else
            {
                lblAviso.Visible = true;
                lblAviso.ForeColor = Color.Red;
                lblAviso.Text = "No se encontro empleado con el numero de legajo seleccionado";
            }
        }

        private void btnModificarEmpleado_Click(object sender, EventArgs e)
        {
              
            lblNombre.Visible = true;
            lblApellido.Visible = true;
            lblUsuaEmpleado.Visible = true;
            lblSueldo.Visible = true;
            btnGuardar.Visible = false;
            btnModificar.Visible = true;
            txtBuscar.Enabled = true;
            txtBuscar.PlaceholderText = "Ingrese Legajo a modificar";
            btnBuscar.Enabled = true;
            txtDatosEmpleado.Visible = false;
            lblDatosEmpleado.Visible = false;
            txtNombre.Visible = true;
            txtApellido.Visible = true;
            txtUsuario.Visible = true;
            txtSueldo.Visible = true;
            lblDni.Visible = true;
            txtDni.Visible = true;
            btnEliminar.Visible = false;
            Limpiar();
            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if(Administrador.ModificarEmpleado(txtNombre.Text, txtApellido.Text, txtDni.Text, txtUsuario.Text, txtSueldo.Text, txtBuscar.Text))
            {
                lblAviso.Visible = true;
                lblAviso.ForeColor = Color.Green;
                lblAviso.Text = "Empleado Modificado";
                dgvListaEmpleados.DataSource = null;
                dgvListaEmpleados.DataSource = Comercio.ListaEmpleados.Values.ToArray();
                Limpiar();
            }
            else
            {
                lblAviso.Visible = true;
                lblAviso.ForeColor = Color.Red;
                lblAviso.Text = "Hubo un problema al modificar al empleado, verifique datos ingresados.";
            }
        }

        public void Limpiar()
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtDni.Text = string.Empty;
            txtUsuario.Text = string.Empty;
            txtSueldo.Text = string.Empty;
            txtDatosEmpleado.Text = string.Empty;
        }

        private void btnBajaEpleado_Click(object sender, EventArgs e)
        {
            txtBuscar.Enabled = true;
            btnBuscar.Enabled = true;
            lblNombre.Visible = false;
            txtNombre.Visible = false;
            lblApellido.Visible = false;
            txtApellido.Visible = false;
            lblDni.Visible = false;
            txtDni.Visible = false;
            lblUsuaEmpleado.Visible = false;
            txtUsuario.Visible = false;
            lblSueldo.Visible = false;
            txtSueldo.Visible = false;
            btnModificar.Visible = false;
            btnGuardar.Visible = false;
            lblDatosEmpleado.Visible = true;
            txtDatosEmpleado.Visible = true;
            btnEliminar.Visible = true;
            txtBuscar.PlaceholderText = "Ingrese legajo a eliminar";

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            FrmConfirmaBaja confirmaBaja = new FrmConfirmaBaja();
            
            if(confirmaBaja.ShowDialog() == DialogResult.OK)
            {
                if (Administrador.EliminarEmpleado(txtBuscar.Text))
                {
                    lblAviso.Visible = true;
                    lblAviso.ForeColor = Color.Green;
                    lblAviso.Text = "Empleado eliminado";
                    dgvListaEmpleados.DataSource = null;
                    dgvListaEmpleados.DataSource = Comercio.ListaEmpleados.Values.ToArray();
                    Limpiar();
                }
                else
                {
                    lblAviso.Visible = true;
                    lblAviso.ForeColor = Color.Red;
                    lblAviso.Text = "Hubo un problema al eliminar al empleado, verifique datos ingresados";
                }
            }
            else
            {
                lblAviso.Visible = true;
                lblAviso.ForeColor = Color.Red;
                lblAviso.Text = "Baja cancelada";
            }
        }
    }
}
