using System;
using BepInEx.Configuration;
using UnityEngine;
using Vapok.Common.Abstractions;
using Vapok.Common.Managers.Configuration;
using Vapok.Common.Shared;

namespace ConsoleBuddy.Configuration
{
    public class ConfigRegistry : ConfigSyncBase
    {
        //Configuration Entry Privates
        
        public static Waiting Waiter;

        public ConfigRegistry(IPluginInfo mod, bool enableLockedConfigs = false): base(mod, enableLockedConfigs)
        {
            //Waiting For Startup
            Waiter = new Waiting();

            InitializeConfigurationSettings();
        }

        public sealed override void InitializeConfigurationSettings()
        {
            if (_config == null)
                return;
            
            //User Configs
        }
    }
    
    public class Waiting
    {
        public void ConfigurationComplete(bool configDone)
        {
            if (configDone)
                StatusChanged?.Invoke(this, EventArgs.Empty);
        }
        public event EventHandler StatusChanged;            
    }

}