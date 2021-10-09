using Hearthstone_Deck_Tracker.Utility.Logging;

namespace bgs_never_lucky
{
    public class HdtEventManager
    {
        public void OnGameStart()
        {
            Log.Info("Never lucky: OnGameStart called");
        }

        public void OnGameEnd()
        {
            Log.Error("Never lucky: OnGameEnd called");
        }

        public void OnTurnStart()
        {
            Log.Info("Never lucky: OnTurnStart called");
        }
    }
}