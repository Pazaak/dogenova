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
            drop6.SelectedIndex = 0;

            Random rnd1 = new Random();

            drop2.SelectedIndex = rnd1.Next(8);
            drop3.SelectedIndex = rnd1.Next(8);
            drop4.SelectedIndex = rnd1.Next(8);
            drop5.SelectedIndex = rnd1.Next(8);

            drop7.SelectedIndex = rnd1.Next(8);
            drop8.SelectedIndex = rnd1.Next(8);
            drop9.SelectedIndex = rnd1.Next(8);
            drop10.SelectedIndex = rnd1.Next(8);
        }

        private void quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void drop2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (drop2.SelectedIndex)
            {
                case 0:
                    class1.Image = Properties.Resources.knight;
                    break;
                case 1:
                    class1.Image = Properties.Resources.soldier;
                    break;
                case 2:
                    class1.Image = Properties.Resources.fighter;
                    break;
                case 3:
                    class1.Image = Properties.Resources.mage;
                    break;
                case 4:
                    class1.Image = Properties.Resources.heretic;
                    break;
                case 5:
                    class1.Image = Properties.Resources.priest;
                    break;
                case 6:
                    class1.Image = Properties.Resources.scout;
                    break;
                case 7:
                    class1.Image = Properties.Resources.shooter;
                    break;
            }
        }

        private void drop3_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (drop3.SelectedIndex)
            {
                case 0:
                    class2.Image = Properties.Resources.knight;
                    break;
                case 1:
                    class2.Image = Properties.Resources.soldier;
                    break;
                case 2:
                    class2.Image = Properties.Resources.fighter;
                    break;
                case 3:
                    class2.Image = Properties.Resources.mage;
                    break;
                case 4:
                    class2.Image = Properties.Resources.heretic;
                    break;
                case 5:
                    class2.Image = Properties.Resources.priest;
                    break;
                case 6:
                    class2.Image = Properties.Resources.scout;
                    break;
                case 7:
                    class2.Image = Properties.Resources.shooter;
                    break;
            }
        }

        private void drop4_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (drop4.SelectedIndex)
            {
                case 0:
                    class3.Image = Properties.Resources.knight;
                    break;
                case 1:
                    class3.Image = Properties.Resources.soldier;
                    break;
                case 2:
                    class3.Image = Properties.Resources.fighter;
                    break;
                case 3:
                    class3.Image = Properties.Resources.mage;
                    break;
                case 4:
                    class3.Image = Properties.Resources.heretic;
                    break;
                case 5:
                    class3.Image = Properties.Resources.priest;
                    break;
                case 6:
                    class3.Image = Properties.Resources.scout;
                    break;
                case 7:
                    class3.Image = Properties.Resources.shooter;
                    break;
            }
        }

        private void drop5_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (drop5.SelectedIndex)
            {
                case 0:
                    class4.Image = Properties.Resources.knight;
                    break;
                case 1:
                    class4.Image = Properties.Resources.soldier;
                    break;
                case 2:
                    class4.Image = Properties.Resources.fighter;
                    break;
                case 3:
                    class4.Image = Properties.Resources.mage;
                    break;
                case 4:
                    class4.Image = Properties.Resources.heretic;
                    break;
                case 5:
                    class4.Image = Properties.Resources.priest;
                    break;
                case 6:
                    class4.Image = Properties.Resources.scout;
                    break;
                case 7:
                    class4.Image = Properties.Resources.shooter;
                    break;
            }
        }

        private void drop7_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (drop7.SelectedIndex)
            {
                case 0:
                    class5.Image = Properties.Resources.knight;
                    break;
                case 1:
                    class5.Image = Properties.Resources.soldier;
                    break;
                case 2:
                    class5.Image = Properties.Resources.fighter;
                    break;
                case 3:
                    class5.Image = Properties.Resources.mage;
                    break;
                case 4:
                    class5.Image = Properties.Resources.heretic;
                    break;
                case 5:
                    class5.Image = Properties.Resources.priest;
                    break;
                case 6:
                    class5.Image = Properties.Resources.scout;
                    break;
                case 7:
                    class5.Image = Properties.Resources.shooter;
                    break;
            }
        }

        private void drop8_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (drop8.SelectedIndex)
            {
                case 0:
                    class6.Image = Properties.Resources.knight;
                    break;
                case 1:
                    class6.Image = Properties.Resources.soldier;
                    break;
                case 2:
                    class6.Image = Properties.Resources.fighter;
                    break;
                case 3:
                    class6.Image = Properties.Resources.mage;
                    break;
                case 4:
                    class6.Image = Properties.Resources.heretic;
                    break;
                case 5:
                    class6.Image = Properties.Resources.priest;
                    break;
                case 6:
                    class6.Image = Properties.Resources.scout;
                    break;
                case 7:
                    class6.Image = Properties.Resources.shooter;
                    break;
            }
        }

        private void drop9_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (drop9.SelectedIndex)
            {
                case 0:
                    class7.Image = Properties.Resources.knight;
                    break;
                case 1:
                    class7.Image = Properties.Resources.soldier;
                    break;
                case 2:
                    class7.Image = Properties.Resources.fighter;
                    break;
                case 3:
                    class7.Image = Properties.Resources.mage;
                    break;
                case 4:
                    class7.Image = Properties.Resources.heretic;
                    break;
                case 5:
                    class7.Image = Properties.Resources.priest;
                    break;
                case 6:
                    class7.Image = Properties.Resources.scout;
                    break;
                case 7:
                    class7.Image = Properties.Resources.shooter;
                    break;
            }
        }

        private void drop10_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (drop10.SelectedIndex)
            {
                case 0:
                    class8.Image = Properties.Resources.knight;
                    break;
                case 1:
                    class8.Image = Properties.Resources.soldier;
                    break;
                case 2:
                    class8.Image = Properties.Resources.fighter;
                    break;
                case 3:
                    class8.Image = Properties.Resources.mage;
                    break;
                case 4:
                    class8.Image = Properties.Resources.heretic;
                    break;
                case 5:
                    class8.Image = Properties.Resources.priest;
                    break;
                case 6:
                    class8.Image = Properties.Resources.scout;
                    break;
                case 7:
                    class8.Image = Properties.Resources.shooter;
                    break;
            }
        }

        private void next_Click(object sender, EventArgs e)
        {
            int[] args = {drop2.SelectedIndex, drop3.SelectedIndex, drop4.SelectedIndex, drop5.SelectedIndex, drop7.SelectedIndex, drop8.SelectedIndex,
            drop9.SelectedIndex, drop10.SelectedIndex};
            battle_scene bscene = new battle_scene(args, drop1.SelectedIndex-1, drop6.SelectedIndex);
            this.Hide();
            bscene.ShowDialog();
            this.Show();
        }
    }
}
