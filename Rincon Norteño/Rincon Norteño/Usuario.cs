using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.IO;

namespace Rincon_Norteño
{
    class Usuario
    {
        private string name;
        
        private string code;
        private char role;
        public bool isnull;
        private string errormessage;
        OleDbConnection connection; //Conexion a la base de datos
        string connectionString;

        public Usuario(string code)
        {
            this.code = code;
            this.isnull = false;
            try
            {
                connectionString = @"Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + Directory.GetCurrentDirectory() + @"\DB_RINCON.mdb";
                connection = new OleDbConnection(connectionString);
                connection.Open();
                OleDbDataReader reader = null;

                OleDbCommand command = new OleDbCommand("SELECT * from  TA_USUARIO WHERE usu_codigo=@1", connection);
                command.Parameters.AddWithValue("@1", code);
                reader = command.ExecuteReader();
                while (reader.Read())
                {

                    this.name =  reader[2].ToString();
                    this.role = reader[3].ToString()[0];
                }
                //verificar si existe el usuario en la bd
                if(!reader.HasRows)
                {
                    this.isnull = true;
                }

            }
            catch (System.Exception ex)
            {
                errormessage = "ERROR:" + ex.Message;
                this.isnull = true;
            }

        }

        public string NAME
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public char ROL 
        {
            get
            {
                return this.role;
            }
            set
            {
                this.role = value;
            }
        }
        public string CODE
        {
            get
            {
                return this.code;
            }
            set
            {
                this.code = value;
            }
        }


    }
}
