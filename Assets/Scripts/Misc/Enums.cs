namespace AutoFighters
{// Battle state
    public enum BattleState
    {
        Running,
        Turn,
        Pause,
        StartFight
    }

    // Character state
    public enum CharState
    {
        Idle,
        StartTurn,
        SelectTarget,
        UseSpell,
        ApplySpellEffect,
        TakeDamage,
        ReceiveHeal,
        Endturn
    }

    // Game state
    public enum GameState
    {
        MainMenu,
        Town,
        Battle
    }

    // Animation Triggers
    public enum AnimationTrigger
    {
        None,
        Attack,
        TakeDamage,
        Die
    }

    // Characters factions
    public enum Faction
    {
        None,
        Ally,
        Enemy
    }

    // Spell target factions
    public enum TargetFaction
    {
        Any,
        Same,
        Opposite
    }

    public enum Job
    {
        None,
        Priest,
        Warrior
    }

    public enum ActiveMenu
    {
        None,
        Inventory
    }
}