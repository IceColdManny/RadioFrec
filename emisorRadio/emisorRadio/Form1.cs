using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace emisorRadio
{
    public partial class Form1 : Form
    {
        // Declaración del puerto serie
        private SerialPort serialPort;

        public Form1()
        {
            InitializeComponent();

            // Configurar el puerto serie al iniciar el formulario
            serialPort = new SerialPort
            {
                PortName = "COM12", // Cambia a tu puerto COM
                BaudRate = 9600,   // Baud rate del Arduino
                Parity = Parity.None,
                DataBits = 8,
                StopBits = StopBits.One
            };

            try
            {
                serialPort.Open(); // Abrir la conexión al puerto serie
                MessageBox.Show("Conectado al puerto " + serialPort.PortName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el puerto: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                string message = textBox1.Text;

                if (!string.IsNullOrWhiteSpace(message))
                {
                    serialPort.WriteLine(message); // Enviar el mensaje al Arduino
                    MessageBox.Show("Mensaje enviado: " + message);
                }
                else
                {
                    MessageBox.Show("Por favor ingresa un mensaje.");
                }
            }
            else
            {
                MessageBox.Show("El puerto serie no está abierto.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // Cerrar el puerto serie al cerrar el formulario
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }

            base.OnFormClosing(e);
        }
    }
}