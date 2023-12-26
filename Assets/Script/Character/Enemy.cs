using UnityEngine;

public class Enemy : Character
{
    private Player player;
    private bool dead = false;

    private void Start () {
        player = Player.instance;
        StageManager.instance.RegisterNewEnemy ();
    }

    protected override void Update () {
        base.Update ();
        if (player == null) return;

        MoveTowardsPlayer ();
        CheckAbilities ();
    }

    void CheckAbilities() {
        if (castingTime > 0) return;

        AimAtPlayer ();
        foreach (Ability ability in abilities) {
            if (ability.status == Ability.Status.Ready) {
                ability.Activate ();
                return;
            }
        }
    }

    void MoveTowardsPlayer () {
        Vector2 directionToPlayer = (player.transform.position - transform.position).normalized;
        Move (directionToPlayer);
    }

    void AimAtPlayer () {
        Vector2 playerPosition = player.transform.position;
        aim = (playerPosition - (Vector2)transform.position).normalized;
        SetSpriteDirection ();
    }

    public override void RefreshAim () => AimAtPlayer ();

    public override void Die () {
        if (dead) return; // Weird bug that causes this to happen multiple times.
        dead = true;
        StageManager.instance.EnemyDefeated ();
        Destroy (gameObject);
    }

#if UNITY_EDITOR
    private void OnDrawGizmos () {
        Gizmos.color = Color.red;
        Gizmos.DrawLine (transform.position, transform.position + (Vector3)aim * 2);
    }
    #endif
}
