using UnityEngine;

public class MoveTowardsPlayerWithoutRotation : MonoBehaviour
{
    public float movementSpeed = 5f;
    private Transform target;

    private void Start () {
        target = Player.instance.transform;
    }

    private void Update () {
        if (target == null) return;

        MoveTowardsTarget (target.position);
    }

    private void MoveTowardsTarget ( Vector3 targetPosition ) {
        float step = movementSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards (transform.position, targetPosition, step);
    }
}
