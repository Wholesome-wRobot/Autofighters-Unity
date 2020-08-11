// Battle state
public enum BattleState
{
    Running,
    Turn,
    Pause
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
    Pause,
    Battle
}

// Animation Triggers
public enum AnimationTrigger
{
    Attack,
    TakeDamage
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
