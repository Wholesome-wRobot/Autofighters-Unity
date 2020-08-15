using UnityEngine;

namespace AutoFighters
{
    static class Consts
    {
        public static string MainControllerName { get => "MainController"; }
        public static string BattleControllerName { get => "BattleController"; }
        public static string BattleSceneName { get => "BattleSceneName"; }

        // Folders
        public static string PersistentDataPath { get => Application.persistentDataPath; }
    }
}