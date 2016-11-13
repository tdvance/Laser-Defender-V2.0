using UnityEngine;
using System.Collections;

public class Bolt : MonoBehaviour {
    public float damage = 1f;

	// Use this for initialization
	void Start () {
        GetComponent<AudioSource>().volume = OptionsMenu.sfxVolume;
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(transform.position.y > 5 || transform.position.y < -5) {
            Destroy(gameObject);
        }
	}
}
