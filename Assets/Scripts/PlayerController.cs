﻿using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {
    public float speed = 20f;
    public float xMin = -8.4f;
    public float xMax = 8.4f;

    public float health = 3f;

    public AudioClip loseClip;
    public AudioClip zapClip;

    public GameObject laserBoltPrefab;
    public GameObject laserBoltPrefab2;
    public float laserboltY = -3.86f;
    public float boltVelocity = 20f;
    public float boltVelocity2 = 5f;
    public float fire2Delay = 0.5f;

    public GameObject smokePrefab;

    public Sprite damage1;
    public Sprite damage2;
    public Sprite damage3;
    public GameObject damageComponent;

    float lastFire2 = 0;

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
        } else if (CrossPlatformInputManager.GetButtonDown("Fire2") && Time.time - lastFire2 > fire2Delay) {
            lastFire2 = Time.time;
            Fire2();
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
        GameObject bolt = Instantiate(laserBoltPrefab, new Vector3(transform.position.x, laserboltY), Quaternion.identity) as GameObject;
        bolt.GetComponent<Rigidbody2D>().velocity = Vector2.up * boltVelocity;
    }

    void Fire2() {
        GameObject bolt = Instantiate(laserBoltPrefab2, new Vector3(transform.position.x, laserboltY), Quaternion.identity) as GameObject;
        bolt.GetComponent<Rigidbody2D>().velocity = Vector2.up * boltVelocity2;
    }

    void Hit(float damage) {
        health -= damage;

        if (health <= 0) {
            AudioSource.PlayClipAtPoint(loseClip, Vector3.zero, 1f);
            GameObject smoke = Instantiate(smokePrefab, transform.position, Quaternion.identity) as GameObject;
            smoke.GetComponent<ParticleSystem>().startColor = new Color(0f, 0f, 1f, 0.1f);
            ScoreManager.instance.SubmitScore(ScoreDisplay.instance.score);
            LevelManager.instance.StartMainCycle(5f);
            Destroy(gameObject);
        } else {
            GetComponent<AudioSource>().clip = zapClip;
            GetComponent<AudioSource>().Play();
            if (health <= 1) {
                damageComponent.GetComponent<SpriteRenderer>().sprite = damage3;
                damageComponent.GetComponent<SpriteRenderer>().color = Color.white;
            } else if (health <= 2) {
                damageComponent.GetComponent<SpriteRenderer>().sprite = damage2;
                damageComponent.GetComponent<SpriteRenderer>().color = Color.white;
            } else if (health <= 3) {
                damageComponent.GetComponent<SpriteRenderer>().sprite = damage1;
                damageComponent.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }

}

