using UnityEngine;

[CreateAssetMenu (fileName = "Upgrade", menuName = "Upgrade/ProjectilePenetration")]
public class Upgrade_ProjectilePenetration : Upgrade
{
    public int penPower;
    public override void Apply ( Player player ) {
        ProjectileSpawner ps = player.transform.GetChild (0).GetComponent<ProjectileSpawner> ();
        ps.penetration += penPower;
    }
}
