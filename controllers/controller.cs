using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dogenova.controllers
{
    interface controller
    {
        bool isUser();
        bool isCon1();
        phases getChoice(battler[] a, int[] b);
    }
}
