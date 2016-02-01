using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dogenova.controllers
{
    class alfabeta_choice : controller
    {
        private bool user;
        private bool con1;

        public alfabeta_choice(bool cont)
        {
            user = false;
            con1 = cont;
        }

        public bool isUser()
        {
            return user;
        }

        public bool isCon1()
        {
            return con1;
        }

        public phases getChoice(battler[] battlers, int[] tiers)
        {
            return alfa_beta.AIOrders(battlers, tiers, con1, 2);
        }
    }
}
