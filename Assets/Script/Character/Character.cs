using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Health))]
public abstract class Character : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 2;
    public float damping = 5f;

    private Vector2 push;
    private Vector2 movement;
    public Vector2 aim;

    public float castingTime;
    public Health healthSystem;

    [SerializeField] protected Ability[] abilities;

    protected virtual void Awake () {
        rb = GetComponent<Rigidbody2D>();
        abilities = GetComponentsInChildren<Ability>();
        healthSystem = GetComponent<Health>();
    }

    protected void Move ( Vector2 direction ) => movement = direction * moveSpeed;

    public void Force ( Vector2 direction ) => push += direction;

    void FixedUpdate () {
        HandleMovement ();
    }

    void HandleMovement() {
        rb.velocity = movement + push;

        if (push.magnitude <= 0) return;

        push -= push.normalized * damping * Time.fixedDeltaTime;
        if (push.magnitude < damping * Time.fixedDeltaTime) {
            push = Vector2.zero;
        }
    }

    public virtual void RefreshAim () {}

    public virtual void Die() {}
}
