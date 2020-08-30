using UnityEditor.PackageManager;
using UnityEngine;

namespace AutoFighters
{
    static class Consts
    {
        // Controller Names
        public static string MainControllerName { get => "MainController"; }
        public static string BattleControllerName { get => "BattleController"; }

        // Scenes
        public static string BattleSceneName { get => "BattleScene"; }
        public static string MainMenuSceneName { get => "MainMenuScene"; }

        // Folders
        public static string PersistentDataPath { get => Application.persistentDataPath; }

        // Game parameters
        public static int NbOfSpellsPerCharacter { get => 4; }
        public static int MaxNumberOfAllies { get => 4; }
        public static int MaxNumberOfEnemies { get => 4; }
    }

    static class ColorConsts
    {
        public static Color32 White { get => new Color32(255, 255, 255, 255); }
        public static Color32 SlotColorOnHover { get => new Color32(200, 200, 255, 255); }
        public static Color SlotColorRed { get => new Color32(255, 0, 0, 200); }
        public static Color32 TransparentOnDrag { get => new Color32(255, 255, 255, 170); }
    }
}