using UnityEngine;

[CreateAssetMenu (fileName = "Upgrade", menuName = "Upgrade/ProjectilePierce")]
public class Upgrade_ProjectilePierce : Upgrade
{
    public int piercePower;
    protected override void HandleApply () {
        ProjectileSpawner ps = player.transform.GetChild (0).GetComponent<ProjectileSpawner> ();
        ps.pierceAmount += piercePower;
    }

    public override string GetDescription () {
        ProjectileSpawner ps = player.transform.GetChild (0).GetComponent<ProjectileSpawner> ();
        int newPenetration = ps.pierceAmount + piercePower;
        return $"Increases projectile penetration power from {ps.pierceAmount} to {newPenetration}.";
    }

}
