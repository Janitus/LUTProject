using Unity.VisualScripting.FullSerializer;
using UnityEngine;

[CreateAssetMenu (fileName = "Upgrade", menuName = "Upgrade/ProjectileAmount")]
public class Upgrade_ProjectileAmount : Upgrade
{
    public int amountOfProjectiles;
    public int amountOfSpread;

    protected override void HandleApply () {
        ProjectileSpawner ps = player.transform.GetChild (0).GetComponent<ProjectileSpawner> ();
        ps.amountOfProjectiles += amountOfProjectiles;
        ps.spread += amountOfSpread;
        if (ps.spread > 360) ps.spread = 360;
    }

    public override string GetDescription () {
        ProjectileSpawner ps = player.transform.GetChild (0).GetComponent<ProjectileSpawner> ();
        int amount = ps.amountOfProjectiles;
        return "Increases the amount of projectiles from "+ amount  + " to "+ (amount+2);
    }
}
