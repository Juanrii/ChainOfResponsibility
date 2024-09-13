using ChainOfResponsibility.BE;
using ChainOfResponsibility.DAL;
using System;
using System.Collections;
using System.Data;

namespace ChainOfResponsibility.MPP
{
    public class UserMPP
    {
        public static UserBE BuscarUsuario(UserBE user)
        {
            try
            {
                Hashtable parametros = new Hashtable();

                parametros.Add("@Password", user.Password);
                parametros.Add("@Email", user.Email);

                string query = "SELECT Email, Username, Password FROM [User] WHERE Email = @Email AND Password = @Password";

                DataTable table = Access.ExecuteDataTable(query, parametros);

                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        UserBE u = new UserBE()
                        {
                            Email    = row["Email"].ToString(),
                            Username = row["Username"].ToString(),
                            Password = row["Password"].ToString()
                        };
                        return u;
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Registrar(UserBE user)
        {
            try
            {
                Hashtable parametros = new Hashtable();

                parametros.Add("@Username", user.Username);
                parametros.Add("@Email",    user.Email);
                parametros.Add("@Password", user.Password);
                parametros.Add("@Activo",   user.Activo);

                string query = "INSERT INTO [User] (Username, Email, Password, Activo) VALUES (@Username, @Email, @Password, @Activo)";

                Access.ExecuteNonQuery(query, parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool UsuarioActivo(UserBE user)
        {
            try
            {
                Hashtable parametros = new Hashtable();

                parametros.Add("@Password", user.Password);
                parametros.Add("@Email", user.Email);

                string query = "SELECT Activo FROM [User] WHERE Email = @Email AND Password = @Password";

                return Convert.ToBoolean(Access.ExecuteScalar(query, parametros));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
