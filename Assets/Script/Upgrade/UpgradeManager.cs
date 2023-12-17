using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public List<Upgrade> allUpgrades;
    public List<Upgrade> currentUpgrades;
    Player player;

    public void Start () {
        player = Player.instance;
    }

    public void AddUpgrade(Upgrade upgrade) {
        if (currentUpgrades.Contains(upgrade)) {
            upgrade.Apply (player);
            upgrade.currentLevel++;
        } else {
            currentUpgrades.Add(Instantiate(upgrade));
            upgrade.Apply (player);
            upgrade.currentLevel++;
        }
    }

    public List<Upgrade> GetRandomUpgrades ( int amount ) {
        List<Upgrade> eligibleUpgrades = new List<Upgrade> ();

        foreach (var upgrade in allUpgrades) {
            if (!currentUpgrades.Contains (upgrade) || (currentUpgrades.Contains (upgrade) && upgrade.currentLevel < upgrade.maximumLevel)) {
                eligibleUpgrades.Add (upgrade);
            }
        }

        List<Upgrade> randomUpgrades = new List<Upgrade> ();
        for (int i = 0; i < amount && eligibleUpgrades.Count > 0; i++) {
            int randomIndex = Random.Range (0, eligibleUpgrades.Count);
            randomUpgrades.Add (eligibleUpgrades[randomIndex]);
            eligibleUpgrades.RemoveAt (randomIndex);
        }

        return randomUpgrades;
    }
}
