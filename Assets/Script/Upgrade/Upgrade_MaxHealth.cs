using UnityEngine;

[CreateAssetMenu (fileName = "Upgrade", menuName = "Upgrade/MaxHealth")]
public class Upgrade_MaxHealth : Upgrade
{
    public int amount;
    protected override void HandleApply () {
        player.GetComponent<Health>().maxHealth += amount;
    }

    public override string GetDescription () {
        int health = player.GetComponent<Health> ().maxHealth;
        return $"Increases max health from {health} to {(health+amount)}.";
    }

}
