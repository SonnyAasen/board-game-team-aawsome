﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Gameengine
{
    class Dice
    {
        public static int RollDice()
        {
            int result = 0;
            Random random = new Random();
            result = random.Next(1, 7);
            return result;
        }   
    }
}