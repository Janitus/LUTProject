using UnityEngine;
using System.Collections;

public class AutoFire : MonoBehaviour
{
    public float fireRate = 2f;
    private float nextFireTime = 0f;
    private ProjectileSpawner projectileSpawner;

    void Start () => projectileSpawner = GetComponent<ProjectileSpawner> ();

    void Update () {
        if (Time.time >= nextFireTime && projectileSpawner != null) {
            projectileSpawner.SpawnProjectiles ();
            nextFireTime = Time.time + fireRate;
        }
    }
}
