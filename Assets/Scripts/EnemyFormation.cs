using UnityEngine;
using System.Collections;

public class EnemyFormation : MonoBehaviour {
    public GameObject[] enemyPrefabs;
    public float width = 11;
    public float height = 5;
    public float xMin = -9f;
    public float xMax = 9f;
    public float speed = 5f;

    float dx = 1f;

    // Use this for initialization
    void Start() {
        SpawnFormation();
    }

    // Update is called once per frame
    void Update() {
        MoveFormation();
    }

    void MoveFormation() {
        transform.Translate(Vector3.right * dx * Time.deltaTime * speed);
        if (transform.position.x - width/2f < xMin) {
            transform.position = new Vector2(xMin + width/2f, transform.position.y);
            dx = 1f;
        } else if (transform.position.x + width/2f > xMax) {
            transform.position = new Vector2(xMax - width / 2f, transform.position.y);
            dx = -1f;
        }
    }

    void OnDrawGizmos() {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
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
