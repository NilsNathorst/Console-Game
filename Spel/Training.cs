using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spel
{
    class Training
    {
        public static void TrainingDefault()
        {
            TextHandler.PrintHeaderText("The training grounds");
            TextHandler.PrintCenteredText("1. Hurl heavy rocks at a wall", 4);
            TextHandler.PrintCenteredText("2. Dodge arrows for an hour");
            TextHandler.PrintCenteredText("3. Eat Ambrosia: 'food of the gods'");
            TextHandler.PrintCenteredText("4. Go back to town");
            TextHandler.CenteredCursorPosition();
        }

    }
}
