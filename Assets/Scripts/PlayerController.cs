﻿using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {
    public float speed = 20f;
    public float xMin = -8.4f;
    public float xMax = 8.4f;

    public float health = 3f;
    public GameObject laserBoltPrefab;
    public float laserboltY = -3.86f;
    public float boltVelocity = 20f;


    // Use this for initialization
    void Start() {
        float multiplier = (float)Screen.width / (float)Screen.height * 9f / 16f;
        xMax *= multiplier;
        xMin *= multiplier;
        Vector3 s = GetComponent<SpriteRenderer>().transform.localScale;
        GetComponent<SpriteRenderer>().transform.localScale = new Vector3(s.x * multiplier, s.y, s.z);
    }

    // Update is called once per frame
    void Update() {
        float dx = GetMovementInput();
        MoveShipBy(dx);
        if (CrossPlatformInputManager.GetButtonDown("Fire1")
            || CrossPlatformInputManager.GetButtonDown("Jump")) {
            Fire();
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "EnemyFire") {
            Hit(collider.gameObject.GetComponent<Bolt>().damage);
            Destroy(collider.gameObject);//TODO spawn something?
        }
    }


    float GetMovementInput() {
        return CrossPlatformInputManager.GetAxis("Horizontal") * speed;
    }

    void MoveShipBy(float dx) {
        transform.Translate(Vector3.right * dx * Time.deltaTime);
        if (transform.position.x < xMin) {
            transform.position = new Vector2(xMin, transform.position.y);
        } else if (transform.position.x > xMax) {
            transform.position = new Vector2(xMax, transform.position.y);
        }
    }

    void Fire() {
        //TODO alt-fire, combo fire
        GameObject bolt = Instantiate(laserBoltPrefab, new Vector3(transform.position.x, laserboltY), Quaternion.identity) as GameObject;
        bolt.GetComponent<Rigidbody2D>().velocity = Vector2.up * boltVelocity;
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

}

