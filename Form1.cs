using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Alquiler
{
    public partial class Form1 : Form
    {


        List<Cliente> clientes = new List<Cliente>();
        List<Vehículo> vehiculos = new List<Vehículo>();
        List<Alquilado> alquileres = new List<Alquilado>();

        public Form1()
        {
            InitializeComponent();
        }



        public void CargarClientes()
        {
            string fileName = "Clientes.txt";

            if (File.Exists(fileName))
            {
                StreamReader reader = new StreamReader(fileName);

                while (!reader.EndOfStream)
                {
                    Cliente cliente = new Cliente();
                    cliente.Nit = Convert.ToInt32(reader.ReadLine());
                    cliente.Nombre = reader.ReadLine();
                    cliente.Direccion = reader.ReadLine();
                    clientes.Add(cliente);
                }

                reader.Close();
            }
                else
                {
                    MessageBox.Show("El archivo de clientes no existe.");
                }

        }

        public void MostrarClientes()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = clientes;
            dataGridView1.Refresh();

        }


        public void CargarVehiculos()
        {

            string fileName = "Vehiculos.txt";

            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);


            while (reader.Peek() > -1)
            {
              
                //reader.ReadLine();

            }


            if (File.Exists(fileName))
            {
                StreamReader reader = new StreamReader(fileName);

                while (!reader.EndOfStream)
                {
                    string[] datos = reader.ReadLine().Split(',');
                    Vehículo vehiculo = new Vehículo ();
                    vehiculo.Placa= datos[0];
                    vehiculo.Marca = datos[1];
                    vehiculo.Modelo = datos[2];
                    vehiculo.Color = datos[3];
                    vehiculo.PrecioPorKm = Convert.ToDecimal(datos[4]);
                    vehiculos.Add(vehiculo);
                }

                reader.Close();
            }
            else
            {
                MessageBox.Show("El archivo de vehículos no existe.");
            }

        }

        public void MostrarVehiculos()
        {

            dataGridView2.DataSource = null;
            dataGridView2.DataSource = vehiculos;
            dataGridView2.Refresh();


        }



        private void Form1_Load(object sender, EventArgs e)
        {

            CargarClientes();
            MostrarClientes();
            
            
            //CargarVehiculos();
            //MostrarVehiculos();
            //MostrarAlquileres();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargarClientes();
            MostrarClientes();

        }

        private void textBoxPlaca_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Vehículo vehiculo = new Vehículo();
            vehiculo.Placa = textBoxPlaca.Text;
            vehiculo.Marca = textBoxMarca.Text;
            vehiculo.Modelo = textBoxModelo.Text;
            vehiculo.Color = textBoxColor.Text;
            vehiculo.PrecioPorKm = Convert.ToDecimal(textBoxPrecio.Text);

            vehiculos.Add(vehiculo);

            GuardarDatosVehiculo();

          


        }

        private void GuardarDatosVehiculo()
        {

            FileStream stream = new FileStream("Vehiculos.txt", FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            foreach(var vehiculo in vehiculos)
            {
                writer.WriteLine(vehiculo.Placa);
                writer.WriteLine(vehiculo.Marca);
                writer.WriteLine(vehiculo.Modelo);
                writer.WriteLine(vehiculo.Color);
                writer.WriteLine(vehiculo.PrecioPorKm);
            }
            writer.Close();



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            CargarVehiculos();
            MostrarVehiculos();
        }
    }
}
