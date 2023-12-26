using UnityEngine;

public class CheatCommand : MonoBehaviour
{
    void Update () {
        if (Input.GetKeyDown (KeyCode.P)) {
            KillAllEnemies ();
        }
    }

    void KillAllEnemies () {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");

        foreach (GameObject enemy in enemies) {
            Enemy enemyScript = enemy.GetComponent<Enemy> ();
            if (enemyScript != null) {
                enemyScript.Die ();
            }
            else {
                Destroy (enemy);
            }
        }

        GameObject[] projectiles = GameObject.FindGameObjectsWithTag ("Projectile");

        foreach (GameObject proj in projectiles) Destroy (proj);
    }
}
