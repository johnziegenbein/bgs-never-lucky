using System;
using Hearthstone_Deck_Tracker.Plugins;

using System.Windows.Controls;
using Hearthstone_Deck_Tracker.API;

namespace bgs_never_lucky
{
    public class Plugin : IPlugin
    {
        public string Name => "Never Lucky";
        public string Description => Name + "is a plugin for displaying your unluckiness in BGs.";
        public string ButtonText => "Never Lucky";
        public string Author => "JohnZ";
        public Version Version => new Version(0, 0, 1);
        protected MenuItem MainMenuItem { get; set; }

        public MenuItem MenuItem => MainMenuItem;
        
        private readonly HdtEventManager _eventManager = new HdtEventManager();

        public void OnLoad()
        {
            GameEvents.OnEntityWillTakeDamage.Add(preDamageInfo => _eventManager.OnEntityWillTakeDamage(preDamageInfo));
            GameEvents.OnGameStart.Add(() => _eventManager.OnGameStart());
            GameEvents.OnGameEnd.Add(() => _eventManager.OnGameEnd());
            GameEvents.OnTurnStart.Add(player => _eventManager.OnTurnStart());
            
            MainMenuItem = new MenuItem()
            {
                Header = Name
            };
            MainMenuItem.Click += (sender, args) => { };
        }

        public void OnUnload()
        {

        }

        public void OnButtonPress()
        {

        }

        public void OnUpdate()
        {

        }
    }
}