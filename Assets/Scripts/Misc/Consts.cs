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
    }
}