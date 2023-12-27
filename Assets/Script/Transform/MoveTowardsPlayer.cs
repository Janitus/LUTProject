using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float rotationSpeed = 200f;
    public bool initiallyFaceAway = false;
    public Transform spriteChild;
    public bool ignoreSpriteRotation = false;

    private Transform target;
    private bool initialRotationSet = false;

    private void Start () {
        target = Player.instance.transform;
        SetInitialRotation ();
    }

    private void Update () {
        if (target == null) return;
        RotateTowards (target.position);
        transform.position += transform.up * movementSpeed * Time.deltaTime;
    }


    private void SetInitialRotation () {
        if (target == null) return;

        Vector2 directionToTarget = (target.position - transform.position).normalized;
        if (initiallyFaceAway) {
            directionToTarget = -directionToTarget;
        }

        float initialAngle = Mathf.Atan2 (directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.AngleAxis (initialAngle, Vector3.forward);
        initialRotationSet = true;
    }

    private void RotateTowards ( Vector3 targetPosition ) {
        if (!initialRotationSet) {
            SetInitialRotation ();
        }

        Vector2 directionToTarget = (targetPosition - transform.position).normalized;
        float angle = Mathf.Atan2 (directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg - 90;
        Quaternion q = Quaternion.AngleAxis (angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards (transform.rotation, q, rotationSpeed * Time.deltaTime);
    }

    private void LateUpdate () {
        if (ignoreSpriteRotation) return;
        if (spriteChild != null) {
            spriteChild.rotation = Quaternion.identity;
        }
    }
}

