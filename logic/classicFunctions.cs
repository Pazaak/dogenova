using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dogenova.logic
{
    static class classicFunctions
    {
        public static bool criticalLife(battler b)
        {
            return b.hp < (int)b.maxHp * 0.3;
        }

        public static int killableTarget(battler[] btls, int act, bool con1, bool frontTargets)
        {
            // Looking for enemies
            for (int i = con1 ? 4 : 0; i < (con1 ? 8 : 4); i++)
            {
                if ( !btls[i].dead && (!btls[act].front || btls[i].front || !frontTargets))
                {
                    int dmg = combat_methods.damageOT(btls[act], btls[i].Clone());
                    if (dmg >= btls[i].hp)
                        return i;
                }
            }

            // Return no possible target
            return -1;
        }

        public static int greatestDamageTarget(battler[] btls, int act, bool con1, bool frontTargets)
        {
            int maxDamage = 0;
            int maxTarget = -1;

            // Looking for enemies
            for (int i = con1 ? 4 : 0; i < (con1 ? 8 : 4); i++)
            {
                if (!btls[i].dead && (!btls[act].front || btls[i].front || !frontTargets))
                {
                    int dmg = combat_methods.damageOT(btls[act], btls[i].Clone());
                    if (dmg >= maxDamage)
                    {
                        maxDamage = dmg;
                        maxTarget = i;
                    }

                }
            }

            return maxTarget;
        }
    }
}
