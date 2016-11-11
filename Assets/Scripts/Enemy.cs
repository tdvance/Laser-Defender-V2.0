using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter2D(Collider2D collider) {
        Debug.Log("Hit!");

        if (collider.tag == "FriendlyFire") {
            Destroy(gameObject);
            Destroy(collider.gameObject);
        }
    }
}
