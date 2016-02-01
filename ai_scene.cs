using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dogenova.controllers;

namespace Dogenova
{
    public partial class ai_scene : Form
    {
        List<Action> pre_combat = new List<Action>();
        List<Action> combat = new List<Action>();
        List<Action> post_combat = new List<Action>();

        bool end = false;

        battler[] battlerFormation = new battler[8];

        Label[] textBoxes = new Label[8];

        int[] speedTier = new int[8];

        int enemiesLeft = 4;
        int alliesLeft = 4;

        controller cont1;
        controller cont2;

        int turn = 0;

        public ai_scene(int[] battlers, int idController1, int idController2)
        {
            InitializeComponent();

            #region Assign arrays for better management
            textBoxes[0] = ally1;
            textBoxes[1] = ally2;
            textBoxes[2] = ally3;
            textBoxes[3] = ally4;

            textBoxes[4] = rival1;
            textBoxes[5] = rival2;
            textBoxes[6] = rival3;
            textBoxes[7] = rival4;
            #endregion

            #region Initialize data
            int[] jobFormation = battlers;
            int[] speeds = new int[8];

            for (int i = 0; i < 8; i++)
            {

                switch (jobFormation[i])
                {
                    case 0:
                        battlerFormation[i] = new battler(950, 53, 85, 35, 65, 40, 5, 13, i, true, (i < 4));
                        break;
                    case 1:
                        battlerFormation[i] = new battler(650, 95, 40, 30, 40, 70, 15, 25, i, true, (i < 4));
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

            // Calculate speed tiers
            speedTier = combat_methods.combatSpeed(speeds);

            // Initialize controllers
            cont1 = determineController(idController1, true);
            cont2 = determineController(idController2, false);

        }

        private void turnActions()
        {
            feedback.AppendText("-----------------------------------------------------" + Environment.NewLine);
            feedback.AppendText("Turn " + (++turn).ToString() + Environment.NewLine);
            feedback.AppendText("-----------------------------------------------------" + Environment.NewLine);

            foreach (Action a in pre_combat.Concat(combat).Concat(post_combat))
            {
                a.Invoke();

                refreshData();

                isAlive();

                if (enemiesLeft == 0 && alliesLeft == 0)
                {
                    MessageBox.Show("DRAW");
                    end = true;
                    break;
                }

                if (enemiesLeft == 0)
                {
                    MessageBox.Show("WIN");
                    end = true;
                    break;
                }

                if (alliesLeft == 0)
                {
                    MessageBox.Show("LOSE");
                    end = true;
                    break;
                }
            }

            clearOrders();
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

        private void determineActions(controller cont)
        {
            phases AIDecision = cont.getChoice(battlerFormation, speedTier);

            for (int i = 0; i < 8; i++)
            {
                #region Precombat
                List<int> pre = AIDecision.pre_combat[i];
                if (pre.Count != 0)
                    switch (pre[0])
                    {
                        case Constants.F_DEFEND:
                            battler temp = battlerFormation[pre[1]];
                            pre_combat[i] = (() => combat_methods.aDefend(temp, true, feedback));
                            break;
                        case Constants.F_ATTACK:
                            battler b1 = battlerFormation[pre[1]];
                            battler b2 = battlerFormation[pre[2]];
                            pre_combat[i] = (() => combat_methods.aAttack(b1, b2, feedback));
                            break;
                    }
                #endregion

                #region Combat
                List<int> mid = AIDecision.combat[i];
                if (mid.Count != 0)
                    switch (mid[0])
                    {
                        case Constants.F_ATTACK:
                            battler b1 = battlerFormation[mid[1]];
                            battler b2 = battlerFormation[mid[2]];
                            combat[i] = (() => combat_methods.aAttack(b1, b2, feedback));
                            break;
                    }
                #endregion

                #region Postcombat
                List<int> post = AIDecision.post_combat[i];
                if (post.Count != 0)
                    switch (post[0])
                    {
                        case Constants.F_DEFEND:
                            battler temp = battlerFormation[post[1]];
                            post_combat[i] = (() => combat_methods.aDefend(temp, false, feedback));
                            break;
                        case Constants.F_ATTACK:
                            battler b1 = battlerFormation[post[1]];
                            battler b2 = battlerFormation[post[2]];
                            post_combat[i] = (() => combat_methods.aAttack(b1, b2, feedback));
                            break;
                    }
                #endregion


            }
        }

        private void isAlive()
        {
            for (int i = 0; i < 8; i++)
            {
                battler target = battlerFormation[i];

                if (target.hp <= 0 && !target.dead)
                {
                    target.dead = true;

                    alliesLeft -= target.ally ? 1 : 0;
                    enemiesLeft -= target.ally ? 0 : 1;
                }
            }

        }

        private controller determineController(int id, bool actor)
        {
            switch (id)
            {
                case -1:
                    return new user_choice();
                case 0:
                    return new random_choice(actor);
                case 1:
                    return new classic_choice(actor);
                case 2:
                    return new alfabeta_choice(actor);
            }
            return null;
        }

        private void stepButton_Click(object sender, EventArgs e)
        {
            if (!end )
            {
                determineActions(cont1);
                determineActions(cont2);

                turnActions();
            }
        }

        private void endButton_Click(object sender, EventArgs e)
        {
            while (!end)
            {
                determineActions(cont1);
                determineActions(cont2);

                turnActions();
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
