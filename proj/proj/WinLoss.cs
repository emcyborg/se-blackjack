﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blackjack {
    /// <summary>
    /// Contains all possible states of the game after a turn
    /// </summary>
    public enum WinLoss {
        NoWin,
        Dealer,
        Player,
        Push
    }
}
