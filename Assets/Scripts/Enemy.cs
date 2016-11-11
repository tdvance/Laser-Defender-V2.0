using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public float health = 2f;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "FriendlyFire") {
            Hit(collider.gameObject.GetComponent<Bolt>().damage);
            Destroy(collider.gameObject);
        }
    }

    void Hit(float damage) {
        health -= damage;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}
