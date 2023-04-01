using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Binary3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            listBox1.Items.Clear();
            listBox2.Items.Clear();
            FileStream DataStream = new FileStream("texty.dat", FileMode.Open, FileAccess.Read);
            FileStream DataStream2 = new FileStream("textyopraveny.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);


            BinaryReader Reader = new BinaryReader(DataStream, Encoding.GetEncoding("windows-1250"));
            BinaryWriter Writer = new BinaryWriter(DataStream2, Encoding.GetEncoding("windows-1250"));


            Reader.BaseStream.Position = 0;
            while (Reader.BaseStream.Position < Reader.BaseStream.Length)
            {
                string text = Reader.ReadString();
                listBox1.Items.Add(text);
                text = text.Replace('.', '!');
                Writer.Write(text);
            }


            BinaryReader Reader2 = new BinaryReader(DataStream2, Encoding.GetEncoding("windows-1250"));
            Reader2.BaseStream.Position = 0;
            while (Reader2.BaseStream.Position < Reader2.BaseStream.Length)
            {
                string text = Reader2.ReadString();
                listBox2.Items.Add(text);
            }


            DataStream.Close();
            DataStream2.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream DataStream = new FileStream("texty.dat", FileMode.Open, FileAccess.ReadWrite);
            BinaryWriter Writer = new BinaryWriter(DataStream, Encoding.GetEncoding("windows-1250"));
            Writer.Write("Dobrý den.");
            Writer.Write("Přeji Vám úžasný den.");
            Writer.Write("Dnes je krásný den.");
            Writer.Write("Mám hlad +-/* =D.");
            DataStream.Close();
        }
    }
}
