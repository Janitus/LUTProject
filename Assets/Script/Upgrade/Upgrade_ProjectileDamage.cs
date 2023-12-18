using UnityEngine;

[CreateAssetMenu (fileName = "Upgrade", menuName = "Upgrade/ProjectileDamage")]
public class Upgrade_ProjectileDamage : Upgrade
{
    public int damage;
    protected override void HandleApply () {
        ProjectileSpawner ps = player.transform.GetChild (0).GetComponent<ProjectileSpawner> ();
        ps.damage += damage;
    }

    public override string GetDescription () {
        ProjectileSpawner ps = player.transform.GetChild (0).GetComponent<ProjectileSpawner> ();
        int newDamage = ps.damage + damage;
        return $"Increases projectile damage from {ps.damage} to {newDamage}.";
    }
}
