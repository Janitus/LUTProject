using UnityEngine;

[CreateAssetMenu (fileName = "Upgrade", menuName = "Upgrade/ProjectilePenetration")]
public class Upgrade_ProjectilePenetration : Upgrade
{
    public int penPower;
    protected override void HandleApply () {
        ProjectileSpawner ps = player.transform.GetChild (0).GetComponent<ProjectileSpawner> ();
        ps.penetration += penPower;
    }

    public override string GetDescription () {
        ProjectileSpawner ps = player.transform.GetChild (0).GetComponent<ProjectileSpawner> ();
        int newPenetration = ps.penetration + penPower;
        return $"Increases projectile penetration power from {ps.penetration} to {newPenetration}.";
    }

}
