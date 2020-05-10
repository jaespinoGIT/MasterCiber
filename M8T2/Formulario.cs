using System;
using System.Windows.Forms;

namespace GoogleAuthenticator
{
    public partial class Formulario : Form
    {
        Totp tf;        
        private byte[] rngBytes = new byte[10];
        public Formulario()
        {
            InitializeComponent();
            tf = new Totp(rngBytes);           
        }

        private void cmdGenerarQR_Click(object sender, EventArgs e)
        {
            GenerarImagen();
        }

        private void GenerarImagen()
        {
            pictureBox1.Image = HelperImagen.GenerarImagen(pictureBox1.Width, pictureBox1.Height, txtEmail.Text, rngBytes);
        }

        private void cmdGenerarPin_Click(object sender, EventArgs e)
        {
            txtPin.Text = tf.GenerarPin(rngBytes);
        }
    }
}
