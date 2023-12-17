using UnityEngine;

[CreateAssetMenu (fileName = "Upgrade", menuName = "Upgrade/ProjectileAttackSpeed")]
public class Upgrade_ProjectileAttackSpeed : Upgrade
{
    public float attackSpeedBonus = 0.05f;
    public override void Apply ( Player player ) {
        Ability_Projectile ps = player.transform.GetChild (0).GetComponent<Ability_Projectile> ();
        ps.cooldownDuration *= (1f - 0.05f);
    }
}
