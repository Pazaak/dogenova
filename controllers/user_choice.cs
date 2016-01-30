using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dogenova.controllers
{
    class user_choice : controller
    {
        public user_choice() { }

        bool controller.isUser()
        {
            return true;
        }

        bool controller.isCon1()
        {
            return true;
        }

        phases controller.getChoice()
        {
            throw new NotImplementedException();
        }
    }
}
