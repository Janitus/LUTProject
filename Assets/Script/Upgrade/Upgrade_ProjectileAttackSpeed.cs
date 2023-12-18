using UnityEngine;

[CreateAssetMenu (fileName = "Upgrade", menuName = "Upgrade/ProjectileAttackSpeed")]
public class Upgrade_ProjectileAttackSpeed : Upgrade
{
    public float attackSpeedBonus = 0.05f;
    protected override void HandleApply () {
        Ability_Projectile ps = player.transform.GetChild (0).GetComponent<Ability_Projectile> ();
        ps.cooldownDuration *= (1f - 0.05f);
    }

    public override string GetDescription () {
        Ability_Projectile ap = player.transform.GetChild (0).GetComponent<Ability_Projectile> ();
        float newCooldown = ap.cooldownDuration * (1f - attackSpeedBonus);
        return $"Reduces projectile attack cooldown from {ap.cooldownDuration:F2}s to {newCooldown:F2}s.";
    }
}
