using UnityEngine;

[RequireComponent (typeof (SpriteRenderer))]
[RequireComponent (typeof (Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    private float maxSpeed;
    private float lifetime;
    private int damage;
    private int penetration;
    private float knockback;
    private int pierceAmount;
    private float radius;
    private AnimationCurve sizeOverLifetime;
    private AnimationCurve accelerationOverLifetime;
    private Vector2 targetDirection;
    private float currentLifetime;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private MaterialPropertyBlock mpb;

    public string ownerTag;
    private bool initialized = false;

    private void Awake () {
        rb = GetComponent<Rigidbody2D> ();
        sr = GetComponent<SpriteRenderer> ();
        mpb = new MaterialPropertyBlock ();
    }

    public void Initialize (    float maxSpeed,
                                float lifetime,
                                int damage,
                                int penetration,
                                float knockback,
                                int pierceAmount,
                                Color color,
                                float radius,
                                AnimationCurve sizeOverLifetime,
                                AnimationCurve accelerationOverLifetime,
                                Vector2 targetDirection ) {
        this.maxSpeed = maxSpeed;
        this.lifetime = lifetime;
        this.damage = damage;
        this.penetration = penetration;
        this.knockback = knockback;
        this.pierceAmount = pierceAmount;
        mpb.SetColor ("_Glow", color);
        sr.SetPropertyBlock (mpb);
        this.radius = radius;
        this.sizeOverLifetime = sizeOverLifetime;
        this.accelerationOverLifetime = accelerationOverLifetime;
        this.targetDirection = targetDirection;

        currentLifetime = lifetime;
        initialized = true;
        gameObject.SetActive (true);
    }

    private void Update () {
        if (!initialized) return;

        currentLifetime -= Time.deltaTime;
        if (currentLifetime <= 0) {
            ProjectilePoolManager.Instance.ReturnProjectile (this);
            return;
        }

        float lifePercent = Mathf.Clamp01(1 - (currentLifetime / lifetime));
        HandleVelocity(lifePercent);
        HandleSize (lifePercent);
    }

    private void HandleVelocity ( float lifeTime ) {
        float currentSpeed = maxSpeed * accelerationOverLifetime.Evaluate (lifeTime);
        rb.velocity = targetDirection * currentSpeed;
        HandleSize (lifeTime);
    }

    private void HandleSize ( float lifeTime ) {
        float scale = radius * sizeOverLifetime.Evaluate (lifeTime);
        transform.localScale = new Vector3 (scale, scale, scale);
    }

    private void OnCollisionEnter2D ( Collision2D collision ) {
        if (collision.gameObject.CompareTag (ownerTag)) return;

        Character character = collision.gameObject.GetComponent<Character> ();
        if (character == null) return;

        character.healthSystem.TakeDamage (damage, penetration);
        character.Force (targetDirection * knockback);

        CheckPenetrationExpiry ();
    }

    private void CheckPenetrationExpiry() {
        if (penetration == 0) return; // Penetration 0 indicates it never expires
        penetration -= 1;
        if (penetration > 0) return;

        gameObject.tag = "Projectile";
        ProjectilePoolManager.Instance.ReturnProjectile (this);
    }

}
