using UnityEngine;

namespace AutoFighters
{
    static class Consts
    {
        public static string MainControllerName { get { return "MainController"; } private set { } }
        public static string BattleControllerName { get { return "BattleController"; } private set { } }
        public static string BattleSceneName { get { return "BattleSceneName"; } private set { } }

        // Folders
        public static string CharacterFolder { get { return "/char"; } private set { } }
        public static string SpellsFolder { get { return "/sp"; } private set { } }
        public static string ApplicationFolder { get { return Application.persistentDataPath; } private set { } }

    }
}