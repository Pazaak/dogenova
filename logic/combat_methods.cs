using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dogenova
{
    static class Constants
    {
        public const int STATHP = 0;
        public const int STATPA = 1;
        public const int STATPD = 2;
        public const int STATMA = 3;
        public const int STATMD = 4;
        public const int STATSP = 5;
        public const int STATEV = 6;
        public const int STATCR = 7;

        public const int F_ATTACK = 0;
        public const int F_DEFEND = 1;
    }
    class combat_methods
    {

        public static void SimulateCombat(phases orders, battler[] battlers)
        {
            
            foreach (List<int> ord in orders.pre_combat)
            {
                if (ord.Count > 0)
                    switch (ord[0])
                    {
                        case Constants.F_ATTACK:
                            damageOT(battlers[ord[1]], battlers[ord[2]]);
                            checkDeath(battlers[ord[1]]);
                            checkDeath(battlers[ord[2]]);
                            break;
                        case Constants.F_DEFEND:
                            battlers[ord[1]].defending = true;
                            break;
                    }
            }

            foreach (List<int> ord in orders.combat)
            {
                if (ord.Count > 0)
                    switch (ord[0])
                    {
                        case Constants.F_ATTACK:
                            damageOT(battlers[ord[1]], battlers[ord[2]]);
                            checkDeath(battlers[ord[1]]);
                            checkDeath(battlers[ord[2]]);
                            break;
                    }
            }

            foreach (List<int> ord in orders.pre_combat)
            {
                if (ord.Count > 0)
                    switch (ord[0])
                    {
                        case Constants.F_ATTACK:
                            damageOT(battlers[ord[1]], battlers[ord[2]]);
                            checkDeath(battlers[ord[1]]);
                            checkDeath(battlers[ord[2]]);
                            break;
                        case Constants.F_DEFEND:
                            battlers[ord[1]].defending = false;
                            break;
                    }
            }

        }
        public static int damageOT(battler source, battler target)
        {
            if (!target.dead && !source.dead)
            {
                double damage;
                if (source.pa > source.ma || ( source.pa == source.ma && target.pd < target.md ))
                {
                    damage = Math.Max(0.8, source.pa / target.pd) * source.pa;
                    damage *= target.defending ? 0.5 : 1;
                }
                else
                {
                    damage = Math.Max(0.8, source.ma / target.md) * source.ma;
                    damage *= target.defending ? 0.5 : 1;
                }
                target.hp -= (int)damage * 2;

                target.hp = (target.hp < 0) ? 0 : target.hp;

                return (int)damage * 2;
            }

            return -1;
        }

        public static void checkDeath(battler target)
        {
            if (target.hp == 0)
                target.dead = true;
        }

        public static void boostSingle(battler target, double value, int stat, bool sum)
        {
            switch (stat)
            {
                case Constants.STATHP:
                    target.hp = sum ? (int)(target.hp + value) : (int)(target.hp * value);
                    break;
                case Constants.STATPA:
                    target.pa = sum ? (int)(target.pa + value) : (int)(target.pa * value);
                    break;
                case Constants.STATPD:
                    target.pd = sum ? (int)(target.pd + value) : (int)(target.pd * value);
                    break;
                case Constants.STATMA:
                    target.ma = sum ? (int)(target.ma + value) : (int)(target.ma * value);
                    break;
                case Constants.STATMD:
                    target.md = sum ? (int)(target.md + value) : (int)(target.md * value);
                    break;
                case Constants.STATSP:
                    target.sp = sum ? (int)(target.sp + value) : (int)(target.sp * value);
                    break;
                case Constants.STATEV:
                    target.ev = sum ? (int)(target.ev + value) : (int)(target.ev * value);
                    break;
                case Constants.STATCR:
                    target.cr = sum ? (int)(target.cr + value) : (int)(target.cr * value);
                    break;
            }
        }

        public static int[] combatSpeed(int[] speedStats)
        {
            int temp;
            bool end = false;
            int[] speedTiers = new int[8];

            for (int i = 0; i < 8; i++)
                speedTiers[i] = i;
            // Tol bubble sort
            while (!end)
            {
                end = true;
                for (int i = 0; i < 7; i++)
                {
                    if (speedStats[i] < speedStats[i + 1])
                    {
                        temp = speedStats[i];
                        speedStats[i] = speedStats[i + 1];
                        speedStats[i + 1] = temp;

                        temp = speedTiers[i];
                        speedTiers[i] = speedTiers[i + 1];
                        speedTiers[i + 1] = temp;

                        end = false;
                    }

                    Random rng = new Random();
                    if (speedStats[i] == speedStats[i + 1] && rng.Next(1)==0)
                    {
                        temp = speedStats[i];
                        speedStats[i] = speedStats[i + 1];
                        speedStats[i + 1] = temp;

                        temp = speedTiers[i];
                        speedTiers[i] = speedTiers[i + 1];
                        speedTiers[i + 1] = temp;
                    }

                }
            }

            int[] neoSpeedTiers = new int[8];
            for (int i = 0; i < 8; i++)
            {
                neoSpeedTiers[speedTiers[i]] = i;
            }

            return neoSpeedTiers;
        }

        public static void aAttack(battler source, battler target, TextBox tb)
        {
            int dmg = combat_methods.damageOT(source, target);
            if (tb != null)
                tb.AppendText(source.ToString() + " does " + dmg + "p to " + target.ToString() + Environment.NewLine);
        }

        public static void aDefend(battler target, bool begin, TextBox tb)
        {
            target.defending = begin;
            if (begin && tb != null)
                tb.AppendText(target.ToString() + " defends" + Environment.NewLine);
        }

        public static void EMPTY() { }
    }
}
