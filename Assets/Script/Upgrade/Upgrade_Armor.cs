using UnityEngine;

[CreateAssetMenu (fileName = "Upgrade", menuName = "Upgrade/Armor")]
public class Upgrade_Armor : Upgrade
{
    public int amount;
    protected override void HandleApply () {
        player.GetComponent<Health>().armor += amount;
    }

    public override string GetDescription () {
        int armor = player.GetComponent<Health> ().armor;
        return $"Increases armor from {armor} to {(armor+amount)}.";
    }

}
