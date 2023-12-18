using Unity.VisualScripting.FullSerializer;
using UnityEngine;

[CreateAssetMenu (fileName = "Upgrade", menuName = "Upgrade/DashDistance")]
public class Upgrade_DashDistance : Upgrade
{
    public float distance;

    protected override void HandleApply () {
        Ability_Dash dash = player.transform.GetChild (1).GetComponent<Ability_Dash> ();
        dash.distance += distance;
    }

    public override string GetDescription () {
        Ability_Dash dash = player.transform.GetChild (1).GetComponent<Ability_Dash> ();
        return "Increases dash distance from "+ dash.distance + " to "+ (dash.distance + distance);
    }
}
