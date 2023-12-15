using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 1;
    public int armor = 0;
    
    private int health = 1;
    private Character character;

    private void Start () {
        character = GetComponent<Character>();
        health = maxHealth;
    }

    public void TakeDamage (int amount, int penetration) {
        int effectiveArmor = Mathf.Max(armor - penetration, 0);
        float damageMitigation = 10f / (10f + effectiveArmor);
        int incomingDamage = (int)(amount * damageMitigation);

        if (incomingDamage <= 0) return;
        health -= incomingDamage;

        if (health > 0) return;
        character.Die ();
    }

    public void TakeHealing (int amount) {
        health += amount;
        if (health > maxHealth) health = maxHealth;
    }
}
