using System;
using Hearthstone_Deck_Tracker.Plugins;

using System.Windows.Controls;

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

        public void OnLoad()
        {
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