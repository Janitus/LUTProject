using System.Collections.Generic;
using UnityEngine;

public class ProjectilePoolManager : MonoBehaviour
{
    [SerializeField] private Projectile projectilePrefab;
    private Queue<Projectile> projectiles = new Queue<Projectile> ();

    public static ProjectilePoolManager Instance { get; private set; }

    private void Awake () => Instance = this;

    public Projectile GetProjectile () {
        if (projectiles.Count > 0) {
            Projectile projectile = projectiles.Dequeue ();
            return projectile;
        }

        return Instantiate (projectilePrefab);
    }

    public void ReturnProjectile ( Projectile projectile ) {
        projectile.gameObject.SetActive (false);
        projectiles.Enqueue (projectile);
    }
}
