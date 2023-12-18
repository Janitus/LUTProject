using UnityEngine;

[CreateAssetMenu (fileName = "Upgrade", menuName = "Upgrade/MoveSpeed")]
public class Upgrade_MoveSpeed : Upgrade
{
    public int amount;
    protected override void HandleApply () {
        player.moveSpeed += amount;
    }

    public override string GetDescription () {
        return $"Increases movement speed from {player.moveSpeed} to {player.moveSpeed+amount}.";
    }

}
