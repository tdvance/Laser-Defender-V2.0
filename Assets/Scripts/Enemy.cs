using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public float health = 2f;
    public GameObject enemyBoltPrefab;
    public float boltVelocity = 20f;
    public float firingRate = 0.5f;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Random.value < firingRate * Time.deltaTime) {//TODO increase with skill level or fewer ships
            Fire();
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "FriendlyFire") {
            Hit(collider.gameObject.GetComponent<Bolt>().damage);
            Destroy(collider.gameObject);//TODO spawn something?
        }
    }

    void Hit(float damage) {
        health -= damage;
        if (health <= 0) {
            Destroy(gameObject);
            //TODO Spawn smoke
        } else {
            //TODO show damage
        }
    }

    void Fire() {
        //TODO alt-fire, combo fire
        GameObject bolt = Instantiate(enemyBoltPrefab, new Vector3(transform.position.x, transform.position.y - 0.5f), Quaternion.identity) as GameObject;
        bolt.GetComponent<Rigidbody2D>().velocity = Vector2.down * boltVelocity;
    }
}
