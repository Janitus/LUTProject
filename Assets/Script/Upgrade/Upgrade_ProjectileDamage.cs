using UnityEngine;

[CreateAssetMenu (fileName = "Upgrade", menuName = "Upgrade/ProjectileDamage")]
public class Upgrade_ProjectileDamage : Upgrade
{
    public int damage;
    public override void Apply ( Player player ) {
        ProjectileSpawner ps = player.transform.GetChild (0).GetComponent<ProjectileSpawner> ();
        ps.damage += damage;
    }
}
