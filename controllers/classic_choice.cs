using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dogenova.logic;

namespace Dogenova.controllers
{
    class classic_choice : controller
    {
        private bool user;
        private bool con1;

        public classic_choice(bool con1_)
        {
            this.user = false;
            this.con1 = con1_;
        }

        public bool isUser()
        {
            return this.user;
        }

        public bool isCon1()
        {
            return this.con1;
        }

        public phases getChoice(battler[] btls, int[] tiers)
        {
            bool frontTargets = false;
            for (int i = con1 ? 4 : 0; i < (con1 ? 8 : 4); i++)
            {
                if (!btls[i].dead && btls[i].front) frontTargets = true;
            }

            phases output = new phases();

            for (int i = con1 ? 0 : 4; i < (con1 ? 4 : 8); i++)
            {
                if (!btls[i].dead)
                {
                    int target = classicFunctions.killableTarget(btls, i, con1, frontTargets);

                    if (target != -1)
                    {
                        // Attack target
                        output.combat[tiers[i]].Add(Constants.F_ATTACK);
                        output.combat[tiers[i]].Add(i);
                        output.combat[tiers[i]].Add(target);
                    }
                    else if (classicFunctions.criticalLife(btls[i]))
                    {
                        //Defend
                        output.pre_combat[tiers[i]].Add(Constants.F_DEFEND);
                        output.pre_combat[tiers[i]].Add(i);
                        output.post_combat[tiers[i]].Add(Constants.F_DEFEND);
                        output.post_combat[tiers[i]].Add(i);
                    }
                    else
                    {
                        // Attack the target that will receive the greatest damage
                        target = classicFunctions.greatestDamageTarget(btls, i, con1, frontTargets);
                        output.combat[tiers[i]].Add(Constants.F_ATTACK);
                        output.combat[tiers[i]].Add(i);
                        output.combat[tiers[i]].Add(target);

                    }
                }
            }

            return output;
        }
    }
}
