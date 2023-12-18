using UnityEngine;
using UnityEngine.UI;
using TMPro; // Make sure you have TextMeshPro in your project

public class UpgradeCard : MonoBehaviour
{
    public Image iconImage;
    public TextMeshProUGUI descriptionText;
    private Upgrade associatedUpgrade;
    public void SetUpgrade ( Upgrade upgrade, Sprite icon, string description ) {
        associatedUpgrade = upgrade;
        iconImage.sprite = icon;
        descriptionText.text = description;
    }

    public void OnCardClicked () {
        UpgradeManager.instance.SelectUpgrade (associatedUpgrade);
    }
}
