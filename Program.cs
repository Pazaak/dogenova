using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Dogenova
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Random rnd = new Random();
            int[] jobFormation = new int[8];
            battler[] battlerFormation = new battler[8];

            for (int i = 0; i < 8; i++)
            {
                jobFormation[i] = rnd.Next(7);

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
            }

            alfa_beta.IAOrders(battlerFormation, 4);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new class_select());
        }
    }
}
