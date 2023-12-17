using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthUI : MonoBehaviour
{
    public Player player;
    public Image healthBar;
    public TextMeshProUGUI healthText;

    private float originalBarWidth;

    private void Start () {
        originalBarWidth = healthBar.rectTransform.sizeDelta.x;
        player = Player.instance;
    }

    private void Update () {
        if (player == null) return;

        float healthPercent = (float)player.healthSystem.CurrentHealth / player.healthSystem.maxHealth;
        healthBar.rectTransform.sizeDelta = new Vector2 (originalBarWidth * healthPercent, healthBar.rectTransform.sizeDelta.y);
        healthText.text = $"{player.healthSystem.CurrentHealth} / {player.healthSystem.maxHealth} Health";
    }
}
