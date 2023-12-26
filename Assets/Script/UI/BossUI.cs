using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossUI : MonoBehaviour
{
    public static BossUI instance;

    public Image maxBar;
    public Image healthBar;
    public TextMeshProUGUI healthText;

    private float originalBarWidth;
    private Enemy boss;

    public void SetBoss ( Enemy enemy ) {
        boss = enemy;
        maxBar.enabled = true;
        healthBar.enabled = true;
        healthText.enabled = true;
    }

    private void Start () {
        instance = this;
        originalBarWidth = healthBar.rectTransform.sizeDelta.x;
    }

    private void Update () {
        if (boss == null) {
            healthBar.enabled = false;
            healthText.enabled = false;
            maxBar.enabled = false;
            return;
        }

        float healthPercent = (float)boss.healthSystem.CurrentHealth / boss.healthSystem.maxHealth;
        healthBar.rectTransform.sizeDelta = new Vector2 (originalBarWidth * healthPercent, healthBar.rectTransform.sizeDelta.y);
        healthText.text = $"{boss.healthSystem.CurrentHealth} / {boss.healthSystem.maxHealth} Boss Health";
    }
}
