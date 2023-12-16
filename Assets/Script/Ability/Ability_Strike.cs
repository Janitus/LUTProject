using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability_Strike : Ability
{
    public int damage;
    public int knockback;
    public int penetration;

    protected override void HandleActivation () {
        Player player = Player.instance;
        if (player == null) return;

        player.healthSystem.TakeDamage (damage, penetration);
        Vector2 knockbackDirection = (player.transform.position - character.transform.position).normalized;
        player.Force (knockbackDirection * knockback);
        
    }
}
