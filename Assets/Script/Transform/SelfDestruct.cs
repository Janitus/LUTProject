using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour
{
    public float timer = 5f;

    private void Start () => StartCoroutine (DestructionCountdown ());

    private IEnumerator DestructionCountdown () {
        yield return new WaitForSeconds (timer);

        Enemy enemy = GetComponent<Enemy> ();
        if (enemy != null)
            enemy.Die ();
        else
            Destroy (gameObject);
    }
}
