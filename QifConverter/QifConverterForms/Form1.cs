using QifApi;
using QifConverter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QifConverterForms
{
    public partial class ConvertQifForm : Form
    {

        private QifDom qifdom = null;

        public ConvertQifForm()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.CheckFileExists = true;
            // "Textdateien (*.txt)|*.txt|Alle Dateien (*.*)|*.*"
            openFileDialog1.Filter = " DiBa-Exports (*.csv)|*.csv";
            openFileDialog1.Multiselect = false;

            //this.openFileDialog1.InitialDirectory = OperatingSystem
            DialogResult diares = this.openFileDialog1.ShowDialog();
            if (diares == DialogResult.OK)
            {
                this.textBox1.Text = openFileDialog1.FileName;
            }


            qifdom = QifConverterBusiness.ConvertDiBaToQuif(this.openFileDialog1.FileName);

            if(qifdom != null && qifdom.BankTransactions != null)
            {
                this.lblSourceFileState.Text = String.Format("Records: {0}",qifdom.BankTransactions.Count);
            }
            
        }

        private void bntExport_Click(object sender, EventArgs e)
        {
            DialogResult diares = saveFileDialog1.ShowDialog();
            if(diares == DialogResult.OK)
            {
                var tmp = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en");

                qifdom.Export(saveFileDialog1.FileName);

                System.Threading.Thread.CurrentThread.CurrentCulture = tmp;

            }
        }
    }
}
