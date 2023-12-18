using UnityEngine;

[CreateAssetMenu (fileName = "Upgrade", menuName = "Upgrade/ProjectileSpeed")]
public class Upgrade_ProjectileSpeed : Upgrade
{
    public int speed;
    protected override void HandleApply () {
        ProjectileSpawner ps = player.transform.GetChild (0).GetComponent<ProjectileSpawner> ();
        ps.maxSpeed += speed;
    }

    public override string GetDescription () {
        ProjectileSpawner ps = player.transform.GetChild (0).GetComponent<ProjectileSpawner> ();
        float newSpeed = ps.maxSpeed + speed;
        return $"Increases projectile speed from {ps.maxSpeed} to {newSpeed}.";
    }

}
