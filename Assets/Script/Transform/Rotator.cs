using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Vector3 rotationAxis = Vector3.up;
    public float rotationSpeed = 90f;

    void Update () {
        transform.Rotate (rotationAxis, rotationSpeed * Time.deltaTime);
    }
}
