using UnityEngine;

namespace TD.Enemies {
    public class Spawner : MonoBehaviour {
        [Header("Settings")]
        [SerializeField] private int enemyCount = 10;
        
        
        [Header("Fixed Delay")]
        [SerializeField] private float delayBtwSpawns;

        private float spawnTimer;
        private int enemiesSpawned;

        private ObjectPooling pooling;
        private void Start() {
            pooling = GetComponent<ObjectPooling>();
        }

        private void Update() {
            spawnTimer -= Time.deltaTime;
            if (!(spawnTimer < 0)) return;
            spawnTimer = delayBtwSpawns;
            if (enemiesSpawned >= enemyCount) return;
            enemiesSpawned++;
            SpawnEnemy();
        }

        private void SpawnEnemy() {
            var newInstance = pooling.GetInstanceFromPool();
            newInstance.SetActive(true);
        }
    }
}