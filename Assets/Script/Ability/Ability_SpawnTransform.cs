using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability_SpawnTransform : Ability
{
    [Header ("Transform")]
    public Transform summonedGameObject;
    public float distance = 0f;
    [Min (1)] public int amount = 1;
    public bool targetPlayer = false;

    protected override void HandleActivation () {
        for(int i = 0; i < amount; i++) {
            float randomAngle = Random.Range (0, 360) * Mathf.Deg2Rad;
            Vector2 spawnDirection = new Vector2 (Mathf.Cos (randomAngle), Mathf.Sin (randomAngle));
            Vector2 spawnPosition;
            if (targetPlayer) spawnPosition = (Vector2)Player.instance.transform.position + spawnDirection * distance;
            else spawnPosition = (Vector2)character.transform.position + spawnDirection * distance;
            Instantiate (summonedGameObject, spawnPosition, Quaternion.identity);
        }
    }
}
