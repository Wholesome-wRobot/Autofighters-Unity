namespace AutoFighters
{// Battle state
    public enum BattleState
    {
        Running,
        Turn,
        Pause,
        StartFight
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

    public enum ItemId
    {
        None,
        BasicAttack,
        BasicHeal,
        GreaterThan,
        LesserThan,
        FiftyPercent,
        CurrentHealth
    }

    public enum CharacterArchetype
    {
        GenericAlly,
        GenericEnemy
    }
}