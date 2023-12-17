using UnityEngine;

[CreateAssetMenu (fileName = "Upgrade", menuName = "Upgrade/ProjectileAmount")]
public class Upgrade_ProjectileAmount : Upgrade
{
    public int amountOfProjectiles;
    public int amountOfSpread;

    public override void Apply ( Player player ) {
        ProjectileSpawner ps = player.transform.GetChild (0).GetComponent<ProjectileSpawner> ();
        ps.amountOfProjectiles += amountOfProjectiles;
        ps.spread += amountOfSpread;
        if (ps.spread > 360) ps.spread = 360;
    }
}
