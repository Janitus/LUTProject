using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ProjectileSpawner))]
public class Ability_Projectile : Ability
{
    [Header("Spawner")]
    ProjectileSpawner ps;
    private void Awake () => ps = GetComponent<ProjectileSpawner>();
    
    protected override void HandleActivation () => ps.SpawnProjectiles ();
}
