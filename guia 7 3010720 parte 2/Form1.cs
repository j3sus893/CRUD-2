using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace guia_7_3010720_parte_2
{
    public partial class Form1 : Form
    {
        private SqlConnection conn1;
        private SqlDataAdapter da1;
        private SqlDataReader dr1;

        private string sCn1;
        OleDbConnection cnn = new OleDbConnection();

      

        public Form1()
        {
           

            InitializeComponent();
            cnn.ConnectionString =
               @"PROVIDER=SQLOLEDB;Server=DESKTOP-HLFGC2T\SQLEXPRESS;Database=CRUD2 3010720;Uid=sa;Pwd=123456";

            Conexion cn1 = new
                Conexion();
            cn1.conec();
            sCn1 = cn1.cadena;
            conn1 = new SqlConnection(sCn1);
            conn1.Open();
        

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void busca2_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Alumno WHERE CodigoAlumno = @Codigo";
            SqlCommand cmd = new SqlCommand(query, conn1);
            cmd.Parameters.AddWithValue("@Codigo", textcod2.Text);
            dr1 = cmd.ExecuteReader();

            if (dr1.Read())
            {
                text1nom2.Text = dr1["PrimerNombre"].ToString().Trim();
                text2nom2.Text = dr1["SegundoNombre"].ToString().Trim();
                textape2.Text = dr1["PrimerApellido"].ToString().Trim();
                text2ape2.Text = dr1["SegundoApellido"].ToString().Trim();
                textedad2.Text = dr1["Edad"].ToString().Trim();
                textdirrecion2.Text = dr1["Direccion"].ToString().Trim();
                MessageBox.Show("Datos Encontrados");
            }
            else
            {
                MessageBox.Show("Alumno no encontrado");
            }
            dr1.Close();
        }

        private void modificar2_Click(object sender, EventArgs e)
        {
            string updateQuery = "UPDATE Alumno SET PrimerNombre=@PrimerNombre, SegundoNombre=@SegundoNombre, " +
                           "PrimerApellido=@PrimerApellido, SegundoApellido=@SegundoApellido, Edad=@Edad, Direccion=@Direccion " +
                           "WHERE Codigo=@Codigo";
            SqlCommand cmd = new SqlCommand(updateQuery, conn1);
            cmd.Parameters.AddWithValue("@Codigo", textcod2.Text);
            cmd.Parameters.AddWithValue("@PrimerNombre", text1nom2.Text);
            cmd.Parameters.AddWithValue("@SegundoNombre", text2nom2.Text);
            cmd.Parameters.AddWithValue("@PrimerApellido", textape2.Text);
            cmd.Parameters.AddWithValue("@SegundoApellido", text2ape2.Text);
            cmd.Parameters.AddWithValue("@Edad", textedad2.Text);
            cmd.Parameters.AddWithValue("@Direccion", textdirrecion2.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Registro actualizado");

        }

        private void burcaras2_Click(object sender, EventArgs e)
        {

            string query = "SELECT * FROM Materia WHERE CodigoMateria = @CodigoMateria";
            SqlCommand cmd = new SqlCommand(query, conn1);
            cmd.Parameters.AddWithValue("@CodigoMateria", textcodM2.Text);
            dr1 = cmd.ExecuteReader();

            if (dr1.Read())
            {
                textnomM2.Text = dr1["NombreMateria"].ToString().Trim(); //error
                textuv2.Text = dr1["UV"].ToString().Trim();
                textprere2.Text = dr1["Prerequisitos"].ToString().Trim();
                MessageBox.Show("Datos Encontrados");
            }
            else
            {
                MessageBox.Show("Materia no encontrada");
            }
            dr1.Close();
        }

        private void modificaras2_Click(object sender, EventArgs e)
        {
            string updateQuery = "UPDATE Materia SET Nombre=@Nombre, UV=@UV, Prerrequisitos=@Prerrequisitos WHERE Codigo=@Codigo";
            SqlCommand cmd = new SqlCommand(updateQuery, conn1);
            cmd.Parameters.AddWithValue("@Codigo Materia", textcodM2.Text);
            cmd.Parameters.AddWithValue("@Nombre", textnomM2.Text);
            cmd.Parameters.AddWithValue("@UV", textuv2.Text);
            cmd.Parameters.AddWithValue("@Prerrequisitos", textprere2.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Registro actualizado");
        }

        private void btnEliminarAlumno_Click(object sender, EventArgs e)
        {

            string deleteQuery = "DELETE FROM Alumno WHERE CodigoAlumno = @CodigoAlumno";
            SqlCommand cmd = new SqlCommand(deleteQuery, conn1);
            cmd.Parameters.AddWithValue("@CodigoAlumno", textcod2.Text);

            int filasAfectadas = cmd.ExecuteNonQuery();

            if (filasAfectadas > 0)
            {
                MessageBox.Show("Alumno eliminado correctamente");
            }
            else
            {
                MessageBox.Show("Alumno no encontrado");
            }
        }

        private void btnMateria_Click(object sender, EventArgs e)
        {
            string deleteQuery = "DELETE FROM Materia WHERE CodigoMateria = @CodigoMateria";
            SqlCommand cmd = new SqlCommand(deleteQuery, conn1);
            cmd.Parameters.AddWithValue("@CodigoMateria", textcodM2.Text);

            int filasAfectadas = cmd.ExecuteNonQuery();

            if (filasAfectadas > 0)
            {
                MessageBox.Show("Materia eliminada correctamente");
            }
            else
            {
                MessageBox.Show("Materia no encontrada");
            }
        }

    }
}
  
