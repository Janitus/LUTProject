using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public enum Status { Ready, Cooldown }
    public Status status;

    public float cooldownDuration = 1f;
    public float castDuration = 1f;
    public bool activateAtEnd = false;

    private float cooldown = 0f;
    protected Character character;

    private void Start () {
        character = GetComponentInParent<Character>();
        if (character == null) this.enabled = false;
    }

    public void Activate() {
        if (status != Status.Ready) return;

        status = Status.Cooldown;
        cooldown = cooldownDuration;
        character.castingTime = castDuration;

        if (activateAtEnd)
            StartCoroutine (ActivationDelay ());
        else
            HandleActivation ();
    }
    private IEnumerator ActivationDelay () {
        yield return new WaitForSeconds (castDuration);
        HandleActivation ();
    }

    protected virtual void HandleActivation() {}

    void Update()
    {
        if (cooldown > 0f) {
            cooldown -= Time.deltaTime;
        } else {
            if (status == Status.Ready) return;
            status = Status.Ready;
        }
    }
}
