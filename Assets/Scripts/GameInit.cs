using UnityEngine;
using System.Collections;

public class GameInit : MonoBehaviour {

    public int gameMusicTrack = 1;

    // Use this for initialization
    void Start() {
        if (FlexibleMusicManager.instance) {
            FlexibleMusicManager.instance.SetCurrentTrack(gameMusicTrack);
            FlexibleMusicManager.instance.Play();
        }else {
            Debug.LogWarning("Missing singleton: FlexibleMusicManager");
        }
        ScoreDisplay.instance.score = 0;
    }

    // Update is called once per frame
    void Update() {

    }
}
