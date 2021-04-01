using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        static RegistryKey currentUserKey = Registry.CurrentUser;
        static RegistryKey Parameters = currentUserKey.CreateSubKey("Parameters", true);

        public Form1()
        {
            InitializeComponent();

            // расширенное окно для выбора цвета
            colorDialog1.FullOpen = true;
            // установка начального цвета для colorDialog
            colorDialog1.Color = this.BackColor;

            BackColor = Color.FromArgb(int.Parse(Parameters.GetValue("Color", Color.White.ToArgb()).ToString()));
            Height = Convert.ToInt32(Parameters.GetValue("Height", 300).ToString());
            Width = Convert.ToInt32(Parameters.GetValue("Width", 300).ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // установка цвета формы
            this.BackColor = colorDialog1.Color;

            Parameters.SetValue("Color", BackColor.ToArgb());
            Parameters.SetValue("Height", Height);
            Parameters.SetValue("Width", Width);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Parameters.Close();
        }
    }
}
