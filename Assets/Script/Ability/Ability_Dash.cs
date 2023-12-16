using UnityEngine;
using System.Collections;

public class Ability_Dash : Ability
{
    [Header("Dash")]
    public float distance;
    public float duration;
    public bool stopAtDestination = false;

    protected override void HandleActivation () => StartCoroutine (Dash ());

    private IEnumerator Dash () {
        Vector2 aimDirection = character.aim.normalized;
        float aimDistance = character.aim.magnitude;

        Vector2 dashVector = aimDirection * distance;
        if (stopAtDestination) {
            float dashDistance = Mathf.Min (aimDistance, distance);
            dashVector = aimDirection * dashDistance;
        }

        float actualDuration = stopAtDestination ? duration * (dashVector.magnitude / distance) : duration;
        Vector2 velocityPerFrame = dashVector / actualDuration;

        float elapsedTime = 0;

        while (elapsedTime < actualDuration) {
            character.transform.position += (Vector3)velocityPerFrame * Time.deltaTime;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}