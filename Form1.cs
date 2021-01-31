using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IP_Finder
{
    public partial class Form1 : Form
    {
        private WebClient wb;

        public Form1()
        {
            this.wb = new WebClient();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtSaida_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtEndereco_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            txtSaida.Text = this.wb.DownloadString(string.Format("http://ip-api.com/line/" + this.txtEndereco.Text));
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtSaida.Clear();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text Documents(*.txt)|*.txt|All Files(*.*)|*.*";
                saveFileDialog.Title = "Salvar Arquivo";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    this.txtSaida.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
                this.Text = saveFileDialog.FileName;

            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show("Algo deu Errado:/", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
    }
}
