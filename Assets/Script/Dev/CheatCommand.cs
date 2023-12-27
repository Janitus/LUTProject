using UnityEngine;

public class CheatCommand : MonoBehaviour
{
    public static CheatCommand instance;

    private void Start () => instance = this;

    #if UNITY_EDITOR
    void Update () {
        if (Input.GetKeyDown (KeyCode.P)) {
            KillAllEnemies ();
        }
    }
    #endif

    public void KillAllEnemies () {
        // Don't read this code. I am aware of what a horrible piece on a disaster this is, but the energy from pizza only gets you so far.
        GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");

        foreach (GameObject enemy in enemies) {
            Enemy enemyScript = enemy.GetComponent<Enemy> ();
            if (enemyScript != null) {
                enemyScript.Die ();
            }
            else {
                Projectile p = enemy.GetComponent <Projectile> ();
                if (p == null) Destroy (enemy);
            }
        }

        GameObject[] projectiles = GameObject.FindGameObjectsWithTag ("Projectile");

        foreach (GameObject proj in projectiles) {
            Projectile p = proj.GetComponent<Projectile> ();
            if (p == null) Destroy (proj);
        }
        
    }
}
