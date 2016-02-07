using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dogenova
{
    public partial class mode_selection : Form
    {
        public mode_selection()
        {
            InitializeComponent();
        }

        private void manualButton_Click(object sender, EventArgs e)
        {
            class_select scene = new class_select();
            this.Hide();
            scene.ShowDialog();
            this.Show();
        }

        private void automaticButton_Click(object sender, EventArgs e)
        {
            automatic_scene scene = new automatic_scene();
            this.Hide();
            scene.ShowDialog();
            this.Show();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
