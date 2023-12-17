using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    Player player;
    public static EnemyManager instance;

    private void Start () {
        player = Player.instance;
        instance = this;
    }

    public void SpawnEnemy() {

    }
}
