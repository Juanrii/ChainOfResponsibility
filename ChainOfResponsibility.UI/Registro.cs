using ChainOfResponsibility.BE;
using ChainOfResponsibility.BLL;
using ChainOfResponsibility.Services.Validator;
using System;
using System.Windows.Forms;

namespace ChainOfResponsibility.UI
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (CamposInvalidos())
                    throw new Exception("Debe completar todos los campos.");

                UserBE user = new UserBE()
                {
                    Email    = inputEmail.Text,
                    Username = inputUsername.Text,
                    Password = inputPassword.Text
                };

                if (!Validator.Email(user.Email))
                    throw new Exception("Debe ingresar un email valido.");

                UserBLL.Registrar(user);

                MessageBox.Show("Usuario registrado.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private bool CamposInvalidos()
        {
            return string.IsNullOrEmpty(inputEmail.Text) 
                || string.IsNullOrEmpty(inputUsername.Text) 
                || string.IsNullOrEmpty(inputPassword.Text);
        }
    }
}
