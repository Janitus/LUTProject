using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [Header ("Projectile")]
    [SerializeField] private Transform projectile;

    [Header("Shape")]
    [ColorUsage (true, true)]
    public Color color;
    public float radius = 0.2f;
    public AnimationCurve sizeOverLifetime;

    [Header ("Mobility")]
    public float maxSpeed = 4f;
    public AnimationCurve accelerationOverLifetime;
    public float lifetime = 2f;

    [Header ("Emission")]
    public int amountOfCasts = 1;
    public float delayBetweenCasts;
    public int amountOfProjectiles = 1;
    public float spread = 0f;
    public float inaccuracy = 0f;
    public bool refreshAimBetweenCasts = false;

    [Header ("Impact")]
    public int damage;
    public int penetration;
    public float knockback;
    public int pierceAmount;

    private Character character;

    private void Start () => character = GetComponentInParent<Character> ();

    public void SpawnProjectiles () => StartCoroutine (SpawnRoutine ());
    
    private IEnumerator SpawnRoutine () {
        for (int cast = 0; cast < amountOfCasts; cast++) {
            if (refreshAimBetweenCasts) character.RefreshAim ();
            Spawn ();
            yield return new WaitForSeconds (delayBetweenCasts);
        }
    }
    private void Spawn () {
        Vector2 directionToPlayer = (character.aim - (Vector2)transform.position).normalized;
        float angleStep = amountOfProjectiles > 1 ? spread / (amountOfProjectiles - 1) : 0;

        for (int i = 0; i < amountOfProjectiles; i++) {
            float projectileAngle = -spread / 2 + angleStep * i;
            Vector2 projectileDirection = Quaternion.Euler (0, 0, projectileAngle) * directionToPlayer;

            Projectile p = ProjectilePoolManager.Instance.GetProjectile ();
            p.ownerTag = transform.root.tag;
            p.Initialize (maxSpeed, lifetime, damage, penetration, knockback, pierceAmount, color, radius, sizeOverLifetime, accelerationOverLifetime, projectileDirection);
            p.transform.position = transform.position;
            p.transform.rotation = Quaternion.Euler (0, 0, projectileAngle);
        }
    }
}
