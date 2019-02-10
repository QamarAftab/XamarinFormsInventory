
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;

namespace Helper.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string SettingsKey = "settings_key";
        private static readonly string SettingsDefault = string.Empty;
        private static string UserAccessTokenKey
        {
            get
            {
                return "iSkoolUserAccessToken";
            }
        }

        private static string UserSelectEvent
        {
            get
            {
                return "UserSelectEvent";
            }
        }

        #endregion

        public static string UserAccessToken
        {
            get
            {
                return AppSettings.GetValueOrDefault(UserAccessTokenKey, "");
            }
            set
            {
                AppSettings.AddOrUpdateValue(UserAccessTokenKey, value);
            }
        }

        public static string GeneralSettings
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsKey, value);
            }
        }

        private static string UserKey
        {
            get
            {
                return AppSettings.GetValueOrDefault("UserKey", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("UserKey", value);
            }
        }

        private static string SelectEvent
        {
            get
            {
                return AppSettings.GetValueOrDefault("SelectEvent", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("SelectEvent", value);
            }
        }

        public static long GetSelectEvent
        {
            get
            {
                return Convert.ToInt64(CommonHelper.CheckIsNullAndReplace(Settings.SelectEvent, "0"));
            }
            set
            {
                Settings.SelectEvent = Newtonsoft.Json.JsonConvert.SerializeObject(value);
            }
        }

        public static void DynamicSave(string key, string value)
        {
            AppSettings.AddOrUpdateValue(key, value);
        }

        public static string GetDynamicValue(string key)
        {
            return AppSettings.GetValueOrDefault(key, "");
        }

        public static void Logout()
        {
            AppSettings.Remove("UserKey");
        }
    }
}