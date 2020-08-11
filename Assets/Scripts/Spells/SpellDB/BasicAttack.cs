using System.Collections.Generic;

public static class BasicAttack : Spell
{
    public BasicAttack()
    {
        Id = SpellID.BasicAttack;
        DisplayName = "Basic Attack";
        Damage = 50;
        DefaultTargetFaction = TargetFaction.Opposite;
    }

    public override void Use(List<Character> listTargets, Character user)
    {

    }
}
