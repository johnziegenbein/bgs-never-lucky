using System;
using Hearthstone_Deck_Tracker.Controls.Overlay;

namespace bgs_never_lucky
{
    public struct Simulation
    {
        public string WinRate;
        public string PlayerLethalRate;
        public string AverageDmgGiven;
        public string TieRate;
        public string LossRate;
        public string OpponentLethalRate;
        public string AverageDmgTaken;

        public Simulation(BobsBuddyPanel bobsBuddyPanel)
        {
            WinRate = bobsBuddyPanel.WinRateDisplay;
            PlayerLethalRate = bobsBuddyPanel.PlayerLethalDisplay;
            TieRate = bobsBuddyPanel.TieRateDisplay;
            LossRate = bobsBuddyPanel.LossRateDisplay;
            OpponentLethalRate = bobsBuddyPanel.OpponentLethalDisplay;
            AverageDmgGiven = bobsBuddyPanel.AverageDamageGivenDisplay;
            AverageDmgTaken = bobsBuddyPanel.AverageDamageTakenDisplay;
        }

        public override string ToString()
        {
            return $"WinRate:{WinRate}, TieRate{TieRate}, LossRate:{LossRate}, " +
                   $"AverageDmgGiven:{AverageDmgGiven}, AverageDmgTaken:{AverageDmgTaken}, " +
                   $"PlayerLethalRate:{PlayerLethalRate}, OpponentLethalRate:{OpponentLethalRate}";
        }
    }
}