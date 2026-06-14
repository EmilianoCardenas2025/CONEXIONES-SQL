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

namespace tienda
{
    public partial class Form1 : Form
    {
        string conexion = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Tienda;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void clientesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.clientesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.tiendaDataSet);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();

            textBox4.Focus();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(conexion);

            string sql = "INSERT INTO Clientes (Nombre, Apellido, Edad) VALUES (@nombre,@apellido,@edad)";

            SqlCommand cmd = new SqlCommand(sql, cn);

            cmd.Parameters.AddWithValue("@nombre", textBox4.Text);
            cmd.Parameters.AddWithValue("@apellido", textBox5.Text);
            cmd.Parameters.AddWithValue("@edad", int.Parse(textBox6.Text));

            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();

            MessageBox.Show("Registro guardado");

            this.clientesTableAdapter.Fill(this.tiendaDataSet.Clientes);
        }

        private void clientesBindingSource1BindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.clientesBindingSource1.EndEdit();
            this.tableAdapterManager1.UpdateAll(this.tiendaDataSet1);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'tiendaDataSet1.Clientes' Puede moverla o quitarla según sea necesario.
            this.clientesTableAdapter1.Fill(this.tiendaDataSet1.Clientes);

        }

        private void clientesDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = clientesDataGridView.Rows[e.RowIndex];

                textBox4.Text = fila.Cells["Nombre"].Value.ToString();
                textBox5.Text = fila.Cells["Apellido"].Value.ToString();
                textBox6.Text = fila.Cells["Edad"].Value.ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.clientesTableAdapter.Fill(this.tiendaDataSet.Clientes);

            clientesDataGridView1.Refresh();

            MessageBox.Show("Tabla actualizada");
        }
        

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(
        clientesDataGridView1.CurrentRow.Cells["IdCliente"].Value);

            SqlConnection cn = new SqlConnection(conexion);

            string sql = "DELETE FROM Clientes WHERE IdCliente=@id";

            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@id", id);

            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();

            this.clientesTableAdapter.Fill(this.tiendaDataSet.Clientes);

            MessageBox.Show("Registro eliminado");
        }
    }
}
