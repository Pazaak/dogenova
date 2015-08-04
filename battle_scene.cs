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
    public partial class battle_scene : Form
    {
        int[] jobFormation = new int[8];

        List<Action> pre_combat = new List<Action>();
        List<Action> combat = new List<Action>();
        List<Action> post_combat = new List<Action>();

        battler[] battlerFormation = new battler[8];

        int[] speeds = new int[8];
        int[] speedTier = new int[8];

        PictureBox[] imgBoxes = new PictureBox[16];

        Label[] textBoxes = new Label[8];

        int[] imgFormation = new int[16];
        int[] charFormation = new int[8];

        int frontAllies = 0;
        int frontEnemies = 0;

        int enemiesLeft = 4;
        int alliesLeft = 4;

        bool blink = true;
        bool targeting = false;

        int row = 0;

        public battle_scene(int b1, int b2, int b3, int b4)
        {
            InitializeComponent();

            #region Assign arrays for better management
            imgBoxes[0] = backAlly1;
            imgBoxes[1] = backAlly2;
            imgBoxes[2] = backAlly3;
            imgBoxes[3] = backAlly4;

            imgBoxes[4] = frontAlly1;
            imgBoxes[5] = frontAlly2;
            imgBoxes[6] = frontAlly3;
            imgBoxes[7] = frontAlly4;

            imgBoxes[8] = backRival1;
            imgBoxes[9] = backRival2;
            imgBoxes[10] = backRival3;
            imgBoxes[11] = backRival4;

            imgBoxes[12] = frontRival1;
            imgBoxes[13] = frontRival2;
            imgBoxes[14] = frontRival3;
            imgBoxes[15] = frontRival4;

            textBoxes[0] = ally1;
            textBoxes[1] = ally2;
            textBoxes[2] = ally3;
            textBoxes[3] = ally4;

            textBoxes[4] = rival1;
            textBoxes[5] = rival2;
            textBoxes[6] = rival3;
            textBoxes[7] = rival4;
            #endregion

            #region Initialize formations
            for (int i = 0; i < 16; i++)
                imgFormation[i] = -1;
            #endregion

            #region Initialize data
            jobFormation[0] = b1;
            jobFormation[1] = b2;
            jobFormation[2] = b3;
            jobFormation[3] = b4;

            Random rnd = new Random();
            jobFormation[4] = rnd.Next(7);
            jobFormation[5] = rnd.Next(7);
            jobFormation[6] = rnd.Next(7);
            jobFormation[7] = rnd.Next(7);

            for (int i = 0; i < 8; i++)
            {
                InitializeBattler(jobFormation[i], (i<4), i%4);

                switch (jobFormation[i])
                {
                    case 0:
                        battlerFormation[i] = new battler(950, 53, 85, 35, 65, 40, 5, 13, i, true, (i<4));
                        break;
                    case 1:
                        battlerFormation[i] = new battler(650, 95, 40, 30, 40, 70, 15, 25, i, true, (i<4));
                        break;
                    case 2:
                        battlerFormation[i] = new battler(800, 60, 60, 5, 85, 65, 15, 15, i, true, (i < 4));
                        break;
                    case 3:
                        battlerFormation[i] = new battler(600, 40, 45, 80, 70, 60, 10, 20, i, false, (i < 4));
                        break;
                    case 4:
                        battlerFormation[i] = new battler(775, 40, 65, 70, 60, 50, 10, 15, i, true, (i < 4));
                        break;
                    case 5:
                        battlerFormation[i] = new battler(700, 40, 50, 60, 80, 55, 15, 15, i, false, (i < 4));
                        break;
                    case 6:
                        battlerFormation[i] = new battler(650, 75, 40, 10, 40, 80, 30, 30, i, true, (i < 4));
                        break;
                    case 7:
                        battlerFormation[i] = new battler(600, 75, 40, 50, 40, 69, 22, 22, i, false, (i < 4));
                        break;
                }

                speedTier[i] = i;
                speeds[i] = battlerFormation[i].sp;

                textBoxes[i].Text = battlerFormation[i].hp + " / " + battlerFormation[i].maxHp;
            }
            #endregion

            clearOrders();

            timer1.Start();

            combat_methods.combatSpeed(speeds, speedTier);
        }

        private void retreat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void attack_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            targeting = true;
        }

        private void defend_Click(object sender, EventArgs e)
        {
            battler b1 = battlerFormation[row];
            pre_combat[speedTier[row]] = (() => aDefend(b1, true));
            post_combat[speedTier[row]] = (() => aDefend(b1, false));
            imgBoxes[charFormation[row++]].Show();

            while (battlerFormation[row].dead) row++;

            if (row >= 4)
            {
                IAactions();
                turnActions();
            }
        }

        private void onTick(object sender, EventArgs e)
        {
            if( blink )
                imgBoxes[charFormation[row]].Hide();
            else
                imgBoxes[charFormation[row]].Show();

            blink = !blink;
        }

        private void mouseEnter(object sender, EventArgs e)
        {
            PictureBox temp = (PictureBox)sender;
            int id = Convert.ToInt32(temp.Tag.ToString());

            if (targeting && (imgFormation[id] != -1) && id > 7 && id < 12 && frontEnemies != 0 && battlerFormation[row].front)
            {
                this.Cursor = Cursors.No;
            }
        }

        private void mouseLeave(object sender, EventArgs e)
        {
            if (targeting)
                this.Cursor = Cursors.Hand;
        }

        private void target(object sender, EventArgs e)
        {
            PictureBox temp = (PictureBox)sender;
            int id = Convert.ToInt32(temp.Tag.ToString());

            if (targeting && (imgFormation[id] != -1) && id > 11)
            {
                battler b1 = battlerFormation[row];
                battler b2 = battlerFormation[imgFormation[id]];
                combat[speedTier[row]] = (() => aAttack(b1, b2));
                targeting = false;
                imgBoxes[charFormation[row++]].Show();
                this.Cursor = Cursors.Default;
            }

            if (targeting && (imgFormation[id] != -1) && id > 7 && id < 12 && (frontEnemies == 0 || !battlerFormation[row].front))
            {
                battler b1 = battlerFormation[row];
                battler b2 = battlerFormation[imgFormation[id]];
                combat[speedTier[row]] = (() => aAttack(b1, b2));
                targeting = false;
                imgBoxes[charFormation[row++]].Show();
                this.Cursor = Cursors.Default;
            }

            while (battlerFormation[row].dead) row++;

            if (row >= 4)
            {
                IAactions();
                turnActions();
            }
        }

        private void InitializeBattler(int battler, bool ally, int id)
        {
            bool front = (battler < 3 || battler == 4 || battler == 6);

            int code = 0;

            code = ally ? 0 : 2;
            code += front ? 1 : 0;

            frontAllies += (ally && front) ? 1 : 0;
            frontEnemies += (!ally && front) ? 1 : 0;

            switch (battler)
            {
                case 0:
                case 1:
                case 2:
                    imgBoxes[code * 4 + id].Image = Properties.Resources.knight;
                    break;
                case 3:
                case 4:
                case 5:
                    imgBoxes[code * 4 + id].Image = Properties.Resources.mage;
                    break;
                case 6:
                case 7:
                    imgBoxes[code * 4 + id].Image = Properties.Resources.knight;
                    break;
            }

            imgFormation[code * 4 + id] = id + ((ally) ? 0 : 4);
            charFormation[id + ((ally) ? 0 : 4)] = code * 4 + id;

            if (code > 1)
            {
                // Maybe change colors
                imgBoxes[code * 4 + id].Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            }

        }

        private void aAttack(battler source, battler target)
        {
            combat_methods.damageOT(source, target);
        }

        private void aDefend(battler target, bool begin)
        {
            target.defending = begin;
        }

        private void turnActions()
        {
            foreach (Action a in pre_combat)
                a.Invoke();

            foreach(Action a in combat)
                a.Invoke();

            foreach (Action a in post_combat)
                a.Invoke();

            refreshData();

            for (int i = 0; i < 8; i++)
            {
                isAlive(i);
                if ( battlerFormation[i].dead )
                    imgBoxes[charFormation[i]].Hide();
            }

            if (enemiesLeft == 0 && alliesLeft == 0)
            {
                MessageBox.Show("DRAW");
                this.Close();
            }

            if (enemiesLeft == 0)
            {
                MessageBox.Show("WIN");
                this.Close();
            }

            if (alliesLeft == 0)
            {
                MessageBox.Show("LOSE");
                this.Close();
            }

            clearOrders();

            row = 0;
            while (battlerFormation[row].dead) row++;
        }

        private void refreshData()
        {
            for (int i = 0; i < 8; i++)
            {
                textBoxes[i].Text = battlerFormation[i].hp.ToString() + " / " + battlerFormation[i].maxHp.ToString();
            }
        }

        private void clearOrders()
        {
            pre_combat.Clear();
            combat.Clear();
            post_combat.Clear();

            for (int i = 0; i < 8; i++)
            {
                pre_combat.Add(() => combat_methods.EMPTY());
                combat.Add(() => combat_methods.EMPTY());
                post_combat.Add(() => combat_methods.EMPTY());

            }
        }

        private void IAactions()
        {
            Random rnd = new Random();

            for (int i = row; i < 8; i++)
            {
                battler b1 = battlerFormation[i];
                if (rnd.Next(3) == 0)
                {
                    pre_combat[speedTier[i]] = (() => aDefend(b1, true));
                    post_combat[speedTier[i]] = (() => aDefend(b1, false));
                }
                else
                {
                    if (b1.front && frontAllies != 0)
                    {
                        int target = rnd.Next(4);
                        while (!battlerFormation[target].front) target = rnd.Next(4);

                        battler b2 = battlerFormation[target];
                        combat[speedTier[i]] = (() => aAttack(b1, b2));
                    }
                    else
                    {
                        battler b2 = battlerFormation[rnd.Next(4)];
                        combat[speedTier[i]] = (() => aAttack(b1, b2));
                    }

                }
            }
        }

        private void isAlive(int id)
        {
            battler target = battlerFormation[id];

            if (target.hp <= 0 && !target.dead)
            {
                target.dead = true;

                if (target.ally)
                {
                    alliesLeft--;
                    frontAllies -= target.front ? 1 : 0;
                }
                else
                {
                    enemiesLeft--;
                    frontEnemies -= target.front ? 1 : 0;
                }
            }
        }
    }
}
