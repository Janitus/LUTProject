using System.Collections.Generic;
using UnityEngine;

public class ProjectilePoolManager : MonoBehaviour
{
    [SerializeField] private Projectile projectilePrefab;
    private Queue<Projectile> projectiles = new Queue<Projectile> ();

    public static ProjectilePoolManager Instance { get; private set; }

    private void Awake () {
        Instance = this;
        PrewarmPool (1500);
    }

    private void PrewarmPool ( int count ) {
        for (int i = 0; i < count; i++) {
            Projectile newProjectile = Instantiate (projectilePrefab);
            newProjectile.gameObject.SetActive (false);
            projectiles.Enqueue (newProjectile);
        }
    }

    public Projectile GetProjectile () {
        if (projectiles.Count > 0) {
            Projectile projectile = projectiles.Dequeue ();
            projectile.gameObject.SetActive (true);
            return projectile;
        }

        return Instantiate (projectilePrefab);
    }

    public void ReturnProjectile ( Projectile projectile ) {
        projectile.gameObject.SetActive (false);
        projectiles.Enqueue (projectile);
    }
}
