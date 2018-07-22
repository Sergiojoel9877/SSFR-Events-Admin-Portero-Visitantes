// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace SSFR_Events.Helpers
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

        public static string UserName
        {
            get
            {
                return AppSettings.GetValueOrDefault("Username", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Username", value);
            }
        }

        public static string Token
        {
            get
            {
                return AppSettings.GetValueOrDefault("Token", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Token", value);
            }
        }

        public static string Password
        {
            get
            {
                return AppSettings.GetValueOrDefault("Password", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Password", value);
            }
        }

        public static string Role
        {
            get
            {
                return AppSettings.GetValueOrDefault("Role", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Role", value);
            }
        }

        public static string EventType
        {
            get => AppSettings.GetValueOrDefault("EventType", "");

            set => AppSettings.AddOrUpdateValue("EventType", value);
        }

        public static string GuestUserName
        {
            get => AppSettings.GetValueOrDefault("GuestUserName", "");

            set => AppSettings.AddOrUpdateValue("GuestUserName", value);
        }

        public static string Path
        {
            get => AppSettings.GetValueOrDefault("Path", "");

            set => AppSettings.AddOrUpdateValue("Path", value);
        }
    }
}