using System.Reflection;
using Hearthstone_Deck_Tracker.API;
using Hearthstone_Deck_Tracker.Controls.Overlay;
using Hearthstone_Deck_Tracker.Utility.BoardDamage;
using Hearthstone_Deck_Tracker.Utility.Logging;
using Core = Hearthstone_Deck_Tracker.Core;

namespace bgs_never_lucky
{
    public class HdtEventManager
    {
        private int HeroEntity = 0;
        private CombatResult _combatResult = new CombatResult(1, 0, CombatWinner.Tie);
        
        public void OnGameStart()
        {
            Log.Info("Never lucky: OnGameStart called");
            if(!Core.Game.IsBattlegroundsMatch) return;
        }

        public void OnGameEnd()
        {
            Log.Error("Never lucky: OnGameEnd called");
            if(!Core.Game.IsBattlegroundsMatch) return;
        }
        
        public void OnEntityWillTakeDamage(PredamageInfo preDamageInfo)
        {
            Log.Info("Never lucky: OnEntityWillTakeDamage called");
            if(!Core.Game.IsBattlegroundsMatch) return;
            if(!EntityHelper.IsHero(preDamageInfo.Entity)) return;

            HeroEntity = EntityHelper.GetHeroEntity(true).Id;

            _combatResult = new CombatResult(Core.Game.GetTurnNumber(),
                preDamageInfo.Value,
                GetCombatWinner(preDamageInfo) 
            );
            
            Log.Info($"Never lucky: PreDamageInfo: value:{preDamageInfo.Value}, entityId:{preDamageInfo.Entity.Id}");
        }

        /**
         * The entity is the damage taker so the entity is the loser.
         */
        private CombatWinner GetCombatWinner(PredamageInfo preDamageInfo)
        {
            return preDamageInfo.Entity.Id == HeroEntity ? CombatWinner.Opponent : CombatWinner.Hero;
        }

        public void OnTurnStart()
        {
            Log.Info("Never lucky: OnTurnStart called");
            if(!Core.Game.IsBattlegroundsMatch) return;
            var turnNumber = Core.Game.GetTurnNumber();
            if(turnNumber == 1) return;
            
            HeroEntity = EntityHelper.GetHeroEntity(true).Id;

            var bobsBuddyPanel = (BobsBuddyPanel) GetInstanceField(Core.Overlay, "BobsBuddyDisplay");
            var turnSimulation = new Simulation(bobsBuddyPanel);

            HandleDrawCombatResult(turnNumber);
            
            Log.Info($"Never lucky: Turn simulation: {turnSimulation.ToString()}");
            Log.Info($"Never lucky: Turn actual result: " +
                     $"{_combatResult.Damage} {CombatWinnerPrinter.ToString(_combatResult.CombatWinner)}");
        }

        /**
         * Since draw combat result will not deal any damage, and hence not create a new combat result,
         * we need to check the turn number of the last combat and assign a tie if it is outdated 
         */
        private void HandleDrawCombatResult(int turnNumber)
        {
            if (turnNumber - 1 != _combatResult.Turn)
            {
                _combatResult = new CombatResult(turnNumber, 0, CombatWinner.Tie);
            }
        }

        private static object GetInstanceField<T>(T instance, string fieldName)
        {                
            BindingFlags bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;
            FieldInfo field = typeof(T).GetField(fieldName, bindFlags);
            return field.GetValue(instance);
        }
    }
}