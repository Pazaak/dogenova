using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dogenova.controllers;
using System.Diagnostics;

namespace Dogenova
{
    public partial class automatic_scene : Form
    {
        private int iterations, t1wins, t2wins;
        private int[] classWins;
        private List<int> turns, t1time, t2time;

        List<Action> pre_combat = new List<Action>();
        List<Action> combat = new List<Action>();
        List<Action> post_combat = new List<Action>();

        bool end = false;

        battler[] battlerFormation = new battler[8];

        int[] speedTier = new int[8];

        int enemiesLeft;
        int alliesLeft;
        int iters;

        controller cont1;
        controller cont2;

        int turn;

        Random rng;
        Stopwatch sw;

        public automatic_scene()
        {
            InitializeComponent();

            drop1.SelectedIndex = 0;
            drop2.SelectedIndex = 0;

            rng = new Random();
            sw = new Stopwatch();

            clearData();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clearData()
        {
            iterations = 0;
            t1wins = 0;
            t2wins = 0;
            turns = new List<int>();
            t1time = new List<int>();
            t2time = new List<int>();

            clearOrders();

            classWins = new int[8];

            iterLabel.Text = "Iterations: 0";
            t1Label.Text = "Wins by Team 1: 0";
            t2Label.Text = "Wins by Team 2: 0";
            t1ratioLabel.Text = "Win Ratio of Team 1: 0%";
            mturnsLabel.Text = "Mean of turns: 0";
            stdturnsLabel.Text = "Standard deviation of turns: 0";
            t1mtimeLabel.Text = "Mean of decision time of T1: 0";
            t1stdtimeLabel.Text = "Standard deviation of decision time of T1: 0";
            t2mtimeLabel.Text = "Mean of decision time of T2: 0";
            t2stdtimeLabel.Text = "Standard deviation of decision time of T2: 0";

            mageLabel.Text = "Mage Win Ratio: 0%";
            hereticLabel.Text = "Heretic Win Ratio: 0%";
            priestLabel.Text = "Priest Win Ratio: 0%";
            scoutLabel.Text = "Scout Win Ratio: 0%";
            shooterLabel.Text = "Shooter Win Ratio: 0%";
            knightLabel.Text = "Knight Win Ratio: 0%";
            soldierLabel.Text = "Soldier Win Ratio: 0%";
            fighterLabel.Text = "Fighter Win Ratio: 0%";

        }

        private void updateData()
        {
            iterLabel.Text = "Iterations: " + iterations;
            t1Label.Text = "Wins by Team 1: " + t1wins;
            t2Label.Text = "Wins by Team 2: " + t2wins;
            t1ratioLabel.Text = "Win Ratio of Team 1: " + (t1wins*100 / iterations) + "%";
            double mean = mathMean(turns);
            mturnsLabel.Text = "Mean of turns: " + mean;
            stdturnsLabel.Text = "Standard deviation of turns: " + standardDeviation(turns, mean);
            mean = mathMean(t1time);
            t1mtimeLabel.Text = "Mean of decision time of T1: " + mean;
            t1stdtimeLabel.Text = "Standard deviation of decision time of T1: " + standardDeviation(t1time, mean);
            mean = mathMean(t2time);
            t2mtimeLabel.Text = "Mean of decision time of T2: " + mean;
            t2stdtimeLabel.Text = "Standard deviation of decision time of T2: " + standardDeviation(t2time, mean);

            mageLabel.Text = "Mage Win Ratio: " + (int)(classWins[0] * 100 / iterations) + "%";
            hereticLabel.Text = "Heretic Win Ratio: " + (int)(classWins[1] * 100 / iterations) + "%";
            priestLabel.Text = "Priest Win Ratio: " + (int)(classWins[2] * 100 / iterations) + "%";
            scoutLabel.Text = "Scout Win Ratio: " + (int)(classWins[3] * 100 / iterations) + "%";
            shooterLabel.Text = "Shooter Win Ratio: " + (int)(classWins[4] * 100 / iterations) + "%";
            knightLabel.Text = "Knight Win Ratio: " + (int)(classWins[5] * 100 / iterations) + "%";
            soldierLabel.Text = "Soldier Win Ratio: " + (int)(classWins[6] * 100 / iterations) + "%";
            fighterLabel.Text = "Fighter Win Ratio: " + (int)(classWins[7] * 100 / iterations) + "%";
        }

        private double mathMean(List<int> samples)
        {
            int output = 0;
            foreach (int elem in samples)
                output += elem;
            return output * 1.0 / samples.Count;
        }

        private double standardDeviation(List<int> sample, double mean)
        {
            double accumulator = 0;

            foreach (int item in sample)
            {
                accumulator += (item - mean) * (item - mean);
            }

            accumulator /= sample.Count();

            return Math.Sqrt(accumulator);
        }

        private void SelectedIndexChanged(object sender, EventArgs e)
        {
            clearData();
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            iters = iterations + (int)nIter.Value;
            while (iterations < iters)
            {
                turn = 0;
                iterations++;
                end = false;
                t1time.Add(0);
                t2time.Add(0);
                enemiesLeft = 4;
                alliesLeft = 4;

                #region Random battlers
                int btl;
                int[] classes = new int[8];
                int[] speeds = new int[8];
                for (int i = 0; i < 8; i++)
                {
                    btl = rng.Next(8);
                    classes[i] = btl;
                    switch (btl)
                    {
                        case 0:
                            battlerFormation[i] = new battler(950, 53, 85, 35, 65, 40, 5, 13, i, true, (i < 4));
                            speeds[i] = 40;
                            break;
                        case 1:
                            battlerFormation[i] = new battler(650, 95, 40, 30, 40, 70, 15, 25, i, true, (i < 4));
                            speeds[i] = 70;
                            break;
                        case 2:
                            battlerFormation[i] = new battler(800, 60, 60, 5, 85, 65, 15, 15, i, true, (i < 4));
                            speeds[i] = 65;
                            break;
                        case 3:
                            battlerFormation[i] = new battler(600, 40, 45, 80, 70, 60, 10, 20, i, false, (i < 4));
                            speeds[i] = 60;
                            break;
                        case 4:
                            battlerFormation[i] = new battler(775, 40, 65, 70, 60, 50, 10, 15, i, true, (i < 4));
                            speeds[i] = 50;
                            break;
                        case 5:
                            battlerFormation[i] = new battler(700, 40, 50, 60, 80, 55, 15, 15, i, false, (i < 4));
                            speeds[i] = 55;
                            break;
                        case 6:
                            battlerFormation[i] = new battler(650, 75, 40, 10, 40, 80, 30, 30, i, true, (i < 4));
                            speeds[i] = 80;
                            break;
                        case 7:
                            battlerFormation[i] = new battler(600, 75, 40, 50, 40, 69, 22, 22, i, false, (i < 4));
                            speeds[i] = 69;
                            break;
                    }
                }
                #endregion

                // Initialize controllers
                cont1 = determineController(drop1.SelectedIndex, true);
                cont2 = determineController(drop2.SelectedIndex, false);

                // Calculate speed tiers
                speedTier = combat_methods.combatSpeed(speeds);

                #region Main battle bucle
                while (!end)
                {
                    turn++;

                    sw.Start();
                    determineActions(cont1);
                    sw.Stop();

                    t1time[t1time.Count - 1] += (int)sw.ElapsedMilliseconds;

                    sw.Restart();

                    sw.Start();
                    determineActions(cont2);
                    sw.Stop();

                    t2time[t2time.Count - 1] += (int)sw.ElapsedMilliseconds;

                    switch (turnActions())
                    {
                        case 0:
                            end = true;
                            t1wins++;
                            awardClasses(classes, true);
                            break;
                        case 1:
                            end = true;
                            t2wins++;
                            awardClasses(classes, false);
                            break;
                    }

                    clearOrders();
                }
                #endregion

                // Aftermath and metrics
                turns.Add(turn);
            }
            updateData();
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
                            pre_combat[i] = (() => combat_methods.aDefend(temp, true, null));
                            break;
                        case Constants.F_ATTACK:
                            battler b1 = battlerFormation[pre[1]];
                            battler b2 = battlerFormation[pre[2]];
                            pre_combat[i] = (() => combat_methods.aAttack(b1, b2, null));
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
                            combat[i] = (() => combat_methods.aAttack(b1, b2, null));
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
                            post_combat[i] = (() => combat_methods.aDefend(temp, false, null));
                            break;
                        case Constants.F_ATTACK:
                            battler b1 = battlerFormation[post[1]];
                            battler b2 = battlerFormation[post[2]];
                            post_combat[i] = (() => combat_methods.aAttack(b1, b2, null));
                            break;
                    }
                #endregion
            }
        }

        private int turnActions()
        {
            foreach (Action a in pre_combat.Concat(combat).Concat(post_combat))
            {
                a.Invoke();

                isAlive();

                if (enemiesLeft == 0 && alliesLeft == 0)
                {
                    return -1;
                }

                if (enemiesLeft == 0)
                {
                    return 0;
                }

                if (alliesLeft == 0)
                {
                    return 1;
                }
            }

            return -1;
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

        private void awardClasses(int[] cla, bool side)
        {
            for (int i = side ? 0 : 4; i < (side ? 4 : 8); i++)
            {
                classWins[cla[i]]++;
            }

        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            clearData();
        }
    }
}
