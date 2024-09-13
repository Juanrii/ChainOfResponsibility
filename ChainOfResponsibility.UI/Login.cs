using ChainOfResponsibility.BE;
using ChainOfResponsibility.BLL;
using System;
using System.Windows.Forms;

namespace ChainOfResponsibility.UI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                UserBE user = new UserBE()
                {
                    Email    = inputEmail.Text,
                    Password = inputPassword.Text
                };

                UserBLL.Login(user);

                MessageBox.Show("Login exitoso.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MostrarFormSistema();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void MostrarFormSistema()
        {
            Sistema sistema = new Sistema();
            sistema.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Registro registro = new Registro();
                registro.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
