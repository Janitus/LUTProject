using UnityEngine;

public class Enemy : Character
{
    private Player player;

    private void Start () {
        player = Player.instance;
    }

    private void Update () {
        if (player == null) return;

        if (castingTime > 0) {
            castingTime -= Time.deltaTime;
            Move (Vector2.zero);
            return;
        }

        MoveTowardsPlayer ();
        CheckAbilities ();
    }

    void CheckAbilities() {
        if (abilities.Length == 0) return;

        AimAtPlayer ();
        foreach (Ability ability in abilities) if (ability.status == Ability.Status.Ready) ability.Activate ();
    }

    void MoveTowardsPlayer () {
        Vector2 directionToPlayer = (player.transform.position - transform.position).normalized;
        Move (directionToPlayer);
    }

    void AimAtPlayer () => aim = (player.transform.position);

    public override void RefreshAim () => AimAtPlayer ();
}
