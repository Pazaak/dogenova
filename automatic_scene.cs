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
    public partial class automatic_scene : Form
    {
        private int iterations, t1wins, t2wins, mageWins, hereticWins, priestWins, scoutWins, shooterWins, knightWins, soldierWins, fighterWins;
        private List<int> turns, t1time, t2time;

        private bool stop;

        public automatic_scene()
        {
            InitializeComponent();
            clearData();
            stop = false;
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
            mageWins = 0;
            hereticWins = 0;
            priestWins = 0;
            scoutWins = 0;
            shooterWins = 0;
            knightWins = 0;
            soldierWins = 0;
            fighterWins = 0;

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
            t1ratioLabel.Text = "Win Ratio of Team 1: " + (t1wins / iterations) + "%";
            double mean = turns.Average();
            mturnsLabel.Text = "Mean of turns: " + mean;
            stdturnsLabel.Text = "Standard deviation of turns: " + standardDeviation(turns, mean);
            mean = t1time.Average();
            t1mtimeLabel.Text = "Mean of decision time of T1: " + mean;
            t1stdtimeLabel.Text = "Standard deviation of decision time of T1: " + standardDeviation(t1time, mean);
            mean = t2time.Average();
            t2mtimeLabel.Text = "Mean of decision time of T2: " + mean;
            t2stdtimeLabel.Text = "Standard deviation of decision time of T2: " + standardDeviation(t2time, mean);

            mageLabel.Text = "Mage Win Ratio: " + (int)(mageWins * 100 / iterations) + "%";
            hereticLabel.Text = "Heretic Win Ratio: " + (int)(hereticWins * 100 / iterations) + "%";
            priestLabel.Text = "Priest Win Ratio: " + (int)(priestWins * 100 / iterations) + "%";
            scoutLabel.Text = "Scout Win Ratio: " + (int)(scoutWins * 100 / iterations) + "%";
            shooterLabel.Text = "Shooter Win Ratio: " + (int)(shooterWins * 100 / iterations) + "%";
            knightLabel.Text = "Knight Win Ratio: " + (int)(knightWins * 100 / iterations) + "%";
            soldierLabel.Text = "Soldier Win Ratio: " + (int)(soldierWins * 100 / iterations) + "%";
            fighterLabel.Text = "Fighter Win Ratio: " + (int)(fighterWins * 100 / iterations) + "%";
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
            stop = true;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            stop = true;
        }

        private void runButton_Click(object sender, EventArgs e)
        {

        }
    }
}
