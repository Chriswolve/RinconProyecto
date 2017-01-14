using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Rincon_Norteño
{
    public partial class Login : Form
    {

        OleDbConnection connection;//Representa una conexión abierta a un origen de datos
        string connectionString;

        public string VerificarUsuario(string code)
        {
            try
            {
                
                connection = new OleDbConnection(connectionString);
                connection.Open();
                OleDbDataReader reader = null;

                OleDbCommand command = new OleDbCommand("SELECT * from  TA_USUARIO WHERE usu_codigo=@1", connection);
                command.Parameters.AddWithValue("@1", code);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return reader[2].ToString();
                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show("ERROR:" + ex.Message);
              
            }
            return "";

        }



        public Login()
        {

            InitializeComponent();
            connectionString = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = "+ Directory.GetCurrentDirectory()+ @"\DB_RINCON.mdb";
           


        }
        public bool Tam_Cod()//Verifica si el tamaño del codigo es menor 
        {
            string texto = TextoCodigo.Text;
            int num_car = texto.Length;
            if (num_car < 4)
                return true;
            return false;
        }
        private void Login_Load(object sender, EventArgs e)
        {

        }
        
        private void Boton1_Click(object sender, EventArgs e)
        {
            if(Tam_Cod())
                TextoCodigo.Text += "1";
        }
        private void Boton2_Click(object sender, EventArgs e)
        {
            if (Tam_Cod())
                TextoCodigo.Text += "2";
        }
        private void Boton3_Click(object sender, EventArgs e)
        {
            if (Tam_Cod())
                TextoCodigo.Text += "3";
        }
        private void Boton4_Click(object sender, EventArgs e)
        {
            if (Tam_Cod())
                TextoCodigo.Text += "4";
        }
        private void Boton5_Click(object sender, EventArgs e)
        {
            if (Tam_Cod())
                TextoCodigo.Text += "5";
        }
        private void Boton6_Click(object sender, EventArgs e)
        {
            if (Tam_Cod())
                TextoCodigo.Text += "6";
        }
        private void Boton7_Click(object sender, EventArgs e)
        {
            if (Tam_Cod())
                TextoCodigo.Text += "7";
        }
        private void Boton8_Click(object sender, EventArgs e)
        {
            if (Tam_Cod())
                TextoCodigo.Text += "8";
        }
        private void Boton9_Click(object sender, EventArgs e)
        {
            if (Tam_Cod())
                TextoCodigo.Text += "9";
        }
        private void BotonPunto_Click(object sender, EventArgs e)
        {
            if (Tam_Cod())
                TextoCodigo.Text += ".";
        }
        private void Boton0_Click(object sender, EventArgs e)
        {
            if (Tam_Cod())
                TextoCodigo.Text += "0";
        }
        private void BotonBorrar_Click(object sender, EventArgs e)
        {
            TextoCodigo.Clear();
        }

        private void BotonEntrar_Click(object sender, EventArgs e)
        {
            string codigo = TextoCodigo.Text;
            if(VerificarUsuario(codigo).Length > 0){
                MessageBox.Show("Bienvenido");
            }
            else
            {
                MessageBox.Show("Usuario incorrecto");
            }

           

        }

        


    }
}
