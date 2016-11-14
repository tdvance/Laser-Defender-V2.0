using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public float health = 2f;

    public AudioClip loseClip;
    public AudioClip zapClip;

    public GameObject enemyBoltPrefab;
    public float boltVelocity = 20f;
    public float firingRate = 0.5f;

    public GameObject smokePrefab;


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

        ScoreDisplay.instance.score += (int)(10 * damage);

        if (health <= 0) {
            ScoreDisplay.instance.score += 30;
            AudioSource.PlayClipAtPoint(loseClip, Vector3.zero, GameOptions.instance.sfxVolume);
            GameObject smoke = Instantiate(smokePrefab, transform.position, Quaternion.identity) as GameObject;
            smoke.GetComponent<ParticleSystem>().startColor = new Color(0f, 1f, 0f, 0.1f);
            Destroy(smoke, 5f);
            Destroy(gameObject);
        } else {
            GetComponent<AudioSource>().volume = GameOptions.instance.sfxVolume * .25f;
            GetComponent<AudioSource>().clip = zapClip;
            GetComponent<AudioSource>().Play();
            //TODO show damage
        }
    }

    void Fire() {
        GameObject bolt = Instantiate(enemyBoltPrefab, new Vector3(transform.position.x, transform.position.y - 0.5f), Quaternion.identity) as GameObject;
        bolt.GetComponent<Rigidbody2D>().velocity = Vector2.down * boltVelocity;
    }
}
