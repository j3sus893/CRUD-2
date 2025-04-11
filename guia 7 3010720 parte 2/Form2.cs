using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace guia_7_3010720_parte_2
{
    public partial class Form2 : Form
    {
        private SqlConnection conn;
        private SqlCommand insert1;
        private string sCn;


        public Form2()
        {
            InitializeComponent();

            Conexion cn = new Conexion();
            cn.conec();

            sCn = cn.cadena;
            conn = new SqlConnection(sCn);
            conn.Open();
        }

        private void Incertar1_Click(object sender, EventArgs e)
        {
            try
            {
                string insertAlumno = "INSERT INTO Alumno(CodigoAlumno, PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido, Edad, Direccion)" +
                                      "VALUES(@CodigoAlumno, @PrimerNombre, @SegundoNombre, @PrimerApellido, @SegundoApellido, @Edad, @Direccion)";
                insert1 = new SqlCommand(insertAlumno, conn);
                insert1.Parameters.AddWithValue("@CodigoAlumno", textcodigo1.Text);
                insert1.Parameters.AddWithValue("@PrimerNombre", textnom1.Text);
                insert1.Parameters.AddWithValue("@SegundoNombre", text2nom1.Text);
                insert1.Parameters.AddWithValue("@PrimerApellido", textape1.Text);
                insert1.Parameters.AddWithValue("@SegundoApellido", text2ape1.Text);
                insert1.Parameters.AddWithValue("@Edad", Convert.ToInt32(textedad1.Text));
                insert1.Parameters.AddWithValue("@Direccion", textdirrecion1.Text);
                insert1.ExecuteNonQuery();

                string insertMateria = "INSERT INTO Materia(CodigoMateria, NombreMateria, UV, Prerequisitos)" +
                                       "VALUES(@CodigoMateria, @NombreMateria, @UV, @Prerequisitos)";
                insert1 = new SqlCommand(insertMateria, conn);
                insert1.Parameters.AddWithValue("@CodigoMateria", textcodM1.Text);
                insert1.Parameters.AddWithValue("@NombreMateria", textnomM1.Text);
                insert1.Parameters.AddWithValue("@UV", Convert.ToInt32(textUV1.Text));
                insert1.Parameters.AddWithValue("@Prerequisitos", textprere1.Text);
                insert1.ExecuteNonQuery();

                MessageBox.Show("Registros Agregados");

                textcodigo1.Text = "";
                textnom1.Text = "";
                text2nom1.Text = "";
                textape1.Text = "";
                text2ape1.Text = "";
                textedad1.Text = "";
                textdirrecion1.Text = "";
                textcodM1.Text = "";
                textnomM1.Text = "";
                textUV1.Text = "";
                textprere1.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void buscar1_Click(object sender, EventArgs e)
        {
            Form1 formu1 = new Form1();
            formu1.Show();
            this.Hide();
        }
    }
}
