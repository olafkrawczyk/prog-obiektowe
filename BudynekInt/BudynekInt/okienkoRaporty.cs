using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BudynekInt
{
    public partial class okienkoRaporty : Form
    {
        // Okienko wyświetlające rapoty 
        // Wyświetlana jest data, id osoby, dane osoby oraz żądana strefa i piętro
        SystemOtwieraniaDrzwi system;
        public okienkoRaporty(SystemOtwieraniaDrzwi iSys)
        {
            InitializeComponent();
            system = iSys;
        }

        private void okienkoRaporty_Load(object sender, EventArgs e)
        {
            listBox1.DataSource = system.udaneReadOnly;
            listBox2.DataSource = system.nieudaneReadOnly;
        }

        private void button_Zamknij_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void wyczyśćToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Wyczyścić raporty?", "Raporty", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                system.wyczysc();
                listBox1.DataSource = system.udaneReadOnly;
                listBox2.DataSource = system.nieudaneReadOnly;
            }
        }

    }
}
