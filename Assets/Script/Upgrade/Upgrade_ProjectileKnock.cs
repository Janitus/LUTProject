using UnityEngine;

[CreateAssetMenu (fileName = "Upgrade", menuName = "Upgrade/ProjectileKnock")]
public class Upgrade_ProjectileKnock : Upgrade
{
    public int knockPower;
    public override void Apply ( Player player ) {
        ProjectileSpawner ps = player.transform.GetChild (0).GetComponent<ProjectileSpawner> ();
        ps.knockback += knockPower;
    }
}
