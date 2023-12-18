using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager instance;
    public Transform upgradeCardPrefab;
    public Transform upgradeSectionUI;

    public List<Upgrade> allUpgrades;
    public List<Upgrade> currentUpgrades;

    private float cardWidth = 130f;
    private float spacing = 10f;

    public void Start () {
        instance = this;
    }

    private void AddUpgrade(Upgrade upgrade) {
        if (currentUpgrades.Contains(upgrade)) {
            upgrade.Apply ();
        } else {
            currentUpgrades.Add(Instantiate(upgrade));
            upgrade.Apply ();
        }
    }

    public List<Upgrade> GetRandomUpgrades ( int amount ) {
        List<Upgrade> eligibleUpgrades = new List<Upgrade> ();

        foreach (var upgrade in allUpgrades) {
            if (!currentUpgrades.Contains (upgrade) || (currentUpgrades.Contains (upgrade) && upgrade.currentLevel < upgrade.maximumLevel)) {
                upgrade.Initialize ();
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

    public void DisplayUpgrades ( int numberOfUpgrades ) {
        List<Upgrade> upgradesToDisplay = GetRandomUpgrades (numberOfUpgrades);

        float totalWidth = (cardWidth * upgradesToDisplay.Count) + (spacing * (upgradesToDisplay.Count - 1));
        float startX = -totalWidth / 2 + cardWidth / 2;

        for (int i = 0; i < upgradesToDisplay.Count; i++) {
            Transform cardObject = Instantiate (upgradeCardPrefab, upgradeSectionUI);
            UpgradeCard card = cardObject.GetComponent<UpgradeCard> ();

            card.SetUpgrade (upgradesToDisplay[i], upgradesToDisplay[i].icon, upgradesToDisplay[i].GetDescription ());

            float cardPosX = startX + (cardWidth + spacing) * i;
            cardObject.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (cardPosX, 0);
        }
    }


    public void SelectUpgrade ( Upgrade upgrade ) {
        AddUpgrade (upgrade);
        foreach (Transform child in upgradeSectionUI)
            Destroy (child.gameObject);
        StageManager.instance.StartStage ();
    }
}
