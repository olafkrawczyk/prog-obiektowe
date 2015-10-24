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
    public partial class zablokowaneStrOkno : Form
    {
        SystemOtwieraniaDrzwi system;
        public zablokowaneStrOkno(SystemOtwieraniaDrzwi iSystem)
        {
            InitializeComponent();
            system = iSystem;
        }

        private void zablokowaneStrOkno_Load(object sender, EventArgs e)
        {
            if (system.zablokowaneReadOnly.Count > 0)
            {
                foreach (Strefa s in system.zablokowaneReadOnly)
                {
                    listBox1.Items.Add(s.wymaganeUpr());
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
