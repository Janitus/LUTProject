using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 1;
    public int armor = 0;

    public int CurrentHealth { get; private set; }

    private Character character;

    private void Start () {
        character = GetComponent<Character>();
        CurrentHealth = maxHealth;
    }

    public void TakeDamage (int amount, int penetration = 0) {
        if (amount <= 0) return;

        int effectiveArmor = Mathf.Max(armor - penetration, 0);
        float damageMitigation = 10f / (10f + effectiveArmor);
        int incomingDamage = (int)(amount * damageMitigation);

        if (incomingDamage <= 0) incomingDamage = 1;
        CurrentHealth -= incomingDamage;

        if (CurrentHealth > 0) return;
        character.Die ();
    }

    public void TakeHealing (int amount) {
        CurrentHealth += amount;
        if (CurrentHealth > maxHealth) CurrentHealth = maxHealth;
    }
}
