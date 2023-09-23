using UnityEngine;
using System.Reflection;
using System;
using UnityModManagerNet;
using HarmonyLib;
using System.Text.RegularExpressions;

namespace _MOD_NAME_;
{
	// Unity Mod Manage Wiki: https://wiki.nexusmods.com/index.php/Category:Unity_Mod_Manager
#if DEBUG
    [EnableReloading]
#endif
    public class Main
    {
        public static bool enabled;
        public static int disableCount = 0;
        public static UnityModManager.ModEntry mod;
        private static Harmony harmony;

    #if SETTINGS_ON
        public static Settings settings;
    #endif

        public static bool Load(UnityModManager.ModEntry modEntry)
        {
            try
            {
                harmony = new Harmony(modEntry.Info.Id);
                harmony.PatchAll(Assembly.GetExecutingAssembly());

                mod = modEntry;
                modEntry.OnToggle = OnToggle;
    #if DEBUG
                modEntry.OnUnload = Unload;
    #endif
    #if SETTINGS_ON
            settings = Settings.Load<Settings>(modEntry);
            modEntry.OnGUI = OnGUI;
            modEntry.OnSaveGUI = OnSaveGUI;
    #endif

                // Other plugin startup logic

                return true;
            }
            catch (Exception ex)
            {
                modEntry.Logger.LogException($"Failed to load {modEntry.Info.DisplayName}:", ex);
                harmony?.UnpatchAll(modEntry.Info.Id);
                return false;
            }
            Directory.Move()
        }

        static bool OnToggle(UnityModManager.ModEntry modEntry, bool value)
        {
            enabled = value;
            modEntry.Logger.Log(Application.loadedLevelName);

            return true;
        }
    #if DEBUG
        static bool Unload(UnityModManager.ModEntry modEntry)
        {
            harmony.UnpatchAll();

            return true;
        }
    #endif

    #if SETTINGS_ON
        static void OnGUI(UnityModManager.ModEntry modEntry)
        {
            settings.Draw(modEntry);
        }

        static void OnSaveGUI(UnityModManager.ModEntry modEntry)
        {
            settings.Save(modEntry);
        }
    #endif
    }
}
