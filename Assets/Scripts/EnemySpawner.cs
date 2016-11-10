using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
    public GameObject[] enemyPrefabs;

    // Use this for initialization
    void Start() {
        SpawnFormation();
       
    }

    // Update is called once per frame
    void Update() {

    }

    void SpawnFormation() {
        int which = 0;
        bool second = true;
        foreach (Transform child in transform) {
            SpawnEnemy(child, which);
            if (second) {
                second = false;
                which++;
            } else {
                second = true;
            }
        }
    }

    GameObject SpawnEnemy(Transform parent, int which) {
        GameObject enemy = Instantiate(enemyPrefabs[which], new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        enemy.transform.SetParent(parent, false);

        return enemy;
    }
}
