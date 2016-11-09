using UnityEngine;
using System.Collections;

public class GameInit : MonoBehaviour {

    public int GameMusicTrack = 1;

	// Use this for initialization
	void Start () {
        FlexibleMusicManager.instance.SetCurrentTrack(GameMusicTrack);
        FlexibleMusicManager.instance.Play();

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
