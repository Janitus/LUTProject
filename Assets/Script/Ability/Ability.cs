using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public enum Status { Ready, Cooldown }
    public Status status;

    public float cooldownDuration = 1f;
    public float castDuration = 1f; // The time the ability locks the character in place
    public float activationDelay = 1f; // The activation timer after the casting was started
    public List<Condition> conditions = new List<Condition> ();

    private float cooldown = 0f;
    protected Character character;

    private void Start () {
        character = GetComponentInParent<Character>();
        if (character == null) this.enabled = false;
    }

    public bool Activate() {
        if (status != Status.Ready || !ConditionsMet ()) return false;

        status = Status.Cooldown;
        cooldown = cooldownDuration;
        character.castingTime = castDuration;

        StartCoroutine (ActivationDelay ());
        return true;
    }

    private bool ConditionsMet () {
        foreach (var condition in conditions)
            if (!condition.IsMet (character)) return false;
        return true;
    }

    private IEnumerator ActivationDelay () {
        yield return new WaitForSeconds (activationDelay);
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

    #if UNITY_EDITOR
    private void OnValidate () {
        if (activationDelay > castDuration) activationDelay = castDuration;
        if (activationDelay < 0f) activationDelay = 0f;
    }
    #endif
}
