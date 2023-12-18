using UnityEngine;

[CreateAssetMenu (fileName = "Upgrade", menuName = "Upgrade/ProjectileKnock")]
public class Upgrade_ProjectileKnock : Upgrade
{
    public float knockPower;
    protected override void HandleApply () {
        ProjectileSpawner ps = player.transform.GetChild (0).GetComponent<ProjectileSpawner> ();
        ps.knockback += knockPower;
    }

    public override string GetDescription () {
        ProjectileSpawner ps = player.transform.GetChild (0).GetComponent<ProjectileSpawner> ();
        float newKnockback = ps.knockback + knockPower;
        return $"Increases projectile knockback power from {ps.knockback} to {newKnockback}.";
    }
}
