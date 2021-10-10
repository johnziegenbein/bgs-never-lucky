using System;
using Hearthstone_Deck_Tracker.API;

namespace bgs_never_lucky
{
    public struct CombatResult
    {
        public int Turn;
        public int Damage;
        public CombatWinner CombatWinner;

        public CombatResult(int turn, int damage, CombatWinner winner)
        {
            Turn = turn;
            Damage = damage;
            CombatWinner = winner;
        }
    }

    public enum CombatWinner
    {
        Hero,
        Tie,
        Opponent
    }

    public static class CombatWinnerPrinter
    {
        public static string ToString(CombatWinner combatWinner)
        {
            switch (combatWinner)
            {
                case CombatWinner.Hero:
                    return "Hero";
                case CombatWinner.Tie:
                    return "Tie";
                case CombatWinner.Opponent:
                    return "Opponent";
                default:
                    throw new ArgumentOutOfRangeException(nameof(combatWinner), combatWinner, null);
            }
        }
    }
    
}