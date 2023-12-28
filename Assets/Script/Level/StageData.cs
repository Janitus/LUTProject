using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Stage", menuName = "Stage")]
public class StageData : ScriptableObject
{
    public int enemyCapacity = 50;
    public List<EnemySpawnData> enemiesToSpawn;
    public AudioClip music;

    [System.Serializable]
    public class EnemySpawnData
    {
        public List<Transform> enemyPrefabs;
        public int spawnAmount;
    }
}
