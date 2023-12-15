using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ProjectileSpawner))]
public class Ability_Projectile : Ability
{
    ProjectileSpawner spawner;
    private void Awake () => spawner = GetComponent<ProjectileSpawner>();
    
    protected override void HandleActivation () => spawner.SpawnProjectiles ();
}
