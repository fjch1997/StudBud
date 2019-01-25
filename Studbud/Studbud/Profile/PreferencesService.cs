using System;
using System.Collections.Generic;
using System.Text;

namespace Studbud.Profile
{
    /// <summary>
    /// Saving and retriving all preferences data in our settings page.
    /// </summary>
    public class PreferencesService : IPreferencesService
    {
        public PreferencesService()
        {
            Load();
        }

        public Preferences Preferences { get; set; }

        public void Load()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Data model for all preferences. 
    /// </summary>
    public class Preferences
    {
    }

    public interface IPreferencesService
    {
        /// <summary>
        /// The current object that is holding the preferences data.
        /// </summary>
        Preferences Preferences { get; }
        /// <summary>
        /// Load preferences data to local storage (not synced with the cloud. that is done in <see cref="DataSynchronizationService"/>.
        /// </summary>
        void Load();
        /// <summary>
        /// Save preferences data to local storage (not synced with the cloud. that is done in <see cref="DataSynchronizationService"/>.
        /// </summary>
        void Save();
    }
}
