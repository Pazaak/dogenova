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
    public partial class class_select : Form
    {
        public class_select()
        {
            InitializeComponent();
            drop1.SelectedIndex = 0;
            drop2.SelectedIndex = 2;
            drop3.SelectedIndex = 3;
            drop4.SelectedIndex = 5;

            class1.Image = Properties.Resources.knight;
            class2.Image = Properties.Resources.knight;
            class3.Image = Properties.Resources.mage;
            class4.Image = Properties.Resources.mage;
        }

        private void quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void drop1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (drop1.SelectedIndex)
            {
                case 0:
                case 1:
                case 2:
                    class1.Image = Properties.Resources.knight;
                    break;
                case 3:
                case 4:
                case 5:
                    class1.Image = Properties.Resources.mage;
                    break;
                case 6:
                case 7:
                    class1.Image = Properties.Resources.knight;
                    break;
            }
        }

        private void drop2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (drop2.SelectedIndex)
            {
                case 0:
                case 1:
                case 2:
                    class2.Image = Properties.Resources.knight;
                    break;
                case 3:
                case 4:
                case 5:
                    class2.Image = Properties.Resources.mage;
                    break;
                case 6:
                case 7:
                    class2.Image = Properties.Resources.knight;
                    break;
            }
        }

        private void drop3_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (drop3.SelectedIndex)
            {
                case 0:
                case 1:
                case 2:
                    class3.Image = Properties.Resources.knight;
                    break;
                case 3:
                case 4:
                case 5:
                    class3.Image = Properties.Resources.mage;
                    break;
                case 6:
                case 7:
                    class3.Image = Properties.Resources.knight;
                    break;
            }
        }

        private void drop4_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (drop4.SelectedIndex)
            {
                case 0:
                case 1:
                case 2:
                    class4.Image = Properties.Resources.knight;
                    break;
                case 3:
                case 4:
                case 5:
                    class4.Image = Properties.Resources.mage;
                    break;
                case 6:
                case 7:
                    class4.Image = Properties.Resources.knight;
                    break;
            }
        }

        private void next_Click(object sender, EventArgs e)
        {
            battle_scene bscene = new battle_scene(drop1.SelectedIndex, drop2.SelectedIndex, drop3.SelectedIndex, drop4.SelectedIndex);
            this.Hide();
            bscene.ShowDialog();
            this.Show();
        }
    }
}
