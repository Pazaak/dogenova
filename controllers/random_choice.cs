using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Dogenova.controllers
{
    class random_choice : controller
    {
        bool user;
        bool controller1;

        public random_choice(bool controller)
        {
            controller1 = controller;
            user = true;
        }

        public bool controller.isUser()
        {
            return user;
        }

        public bool controller.isCon1()
        {
            return controller1;
        }

        public phases controller.getChoice(battler[] battlers, int[] tiers)
        {
            int allies = controller1 ? 4 : 8;
            int enemies = controller1 ? 8 : 4;

            List<int> frontTargets = new List<int>();
            List<int> backTargets = new List<int>();

            phases output = new phases();

            for (int k = enemies - 4; k < enemies; k++)
            {
                if (!battlers[k].dead)
                {
                    if (battlers[k].front)
                        frontTargets.Add(k);
                    else
                        backTargets.Add(k);
                }
            }

            for (int i = allies - 4; i < allies; i++)
            {
                int choices = 1 + frontTargets.Count;
                if (!battlers[i].front)
                    choices += backTargets.Count;

                Random rng = new Random();

                int choice = rng.Next(choices);

                if (choice == 0)
                {
                    // Defend
                    output.pre_combat[tiers[i]].Add(Constants.F_DEFEND);
                    output.pre_combat[tiers[i]].Add(i);
                    output.post_combat[tiers[i]].Add(Constants.F_DEFEND);
                    output.post_combat[tiers[i]].Add(i);
                }
                else if (choice - 1 < frontTargets.Count)
                {
                    // Attack front target
                    output.combat[tiers[i]].Add(Constants.F_ATTACK);
                    output.combat[tiers[i]].Add(i);
                    output.combat[tiers[i]].Add(frontTargets[choice-1]);
                }
                else if (choice - 1 - frontTargets.Count < backTargets.Count)
                {
                    // Attack back target
                    output.combat[tiers[i]].Add(Constants.F_ATTACK);
                    output.combat[tiers[i]].Add(i);
                    output.combat[tiers[i]].Add(frontTargets[choice - 1 - frontTargets.Count]);
                }
            }

            return output;
        }
    }
}
