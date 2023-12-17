using UnityEngine;

[CreateAssetMenu (fileName = "Upgrade", menuName = "Upgrade/ProjectileSpeed")]
public class Upgrade_ProjectileSpeed : Upgrade
{
    public int speed;
    public override void Apply ( Player player ) {
        ProjectileSpawner ps = player.transform.GetChild (0).GetComponent<ProjectileSpawner> ();
        ps.maxSpeed += speed;
    }
}
