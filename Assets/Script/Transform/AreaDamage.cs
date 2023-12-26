using UnityEngine;
using System.Collections;

public class AreaDamage : MonoBehaviour
{
    public int damage = 1;
    public int penetration = 0;
    public float interval = 1f;

    private float nextDamageTime = 0f;
    private string compareTag = "";

    private void Start () {
        if (transform.tag == "Enemy") {
            compareTag = "Player";
            return;
        }
        else if (transform.tag == "Player") {
            compareTag = "Enemy";
            return;
        }

        print ("Effect has no proper tag! Removing self!");
        Destroy(transform.gameObject);
    }

    private void OnTriggerStay2D ( Collider2D other ) {
        if (Time.time >= nextDamageTime) {
            if (other.CompareTag (compareTag)) {
                Health health = other.GetComponent<Health> ();
                if (health == null) return;

                health.TakeDamage (damage, penetration);
            }

            nextDamageTime = Time.time + 1f / interval;
        }
    }
}
