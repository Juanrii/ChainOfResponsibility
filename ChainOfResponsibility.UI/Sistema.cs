using ChainOfResponsibility.Services.Session;
using System;
using System.Windows.Forms;

namespace ChainOfResponsibility.UI
{
    public partial class Sistema : Form
    {
        public Sistema()
        {
            InitializeComponent();
            label1.Text += $" {Session.GetUsuario().Email }"; 
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("¿Desea cerrar la sesion?", "Cerrar sesion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Session.Logout();
                    Login login = new Login();
                    login.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
