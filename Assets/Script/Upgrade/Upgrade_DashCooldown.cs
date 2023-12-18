using Unity.VisualScripting.FullSerializer;
using UnityEngine;

[CreateAssetMenu (fileName = "Upgrade", menuName = "Upgrade/DashCooldown")]
public class Upgrade_DashCooldown : Upgrade
{
    public float reducedCooldown;

    protected override void HandleApply () {
        Ability_Dash dash = player.transform.GetChild (1).GetComponent<Ability_Dash> ();
        dash.cooldownDuration -= reducedCooldown;
    }

    public override string GetDescription () {
        Ability_Dash dash = player.transform.GetChild (1).GetComponent<Ability_Dash> ();
        return "Reduces dash cooldown from "+ dash.cooldownDuration + " to "+ (dash.cooldownDuration - reducedCooldown);
    }
}
