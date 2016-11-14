using UnityEngine;
using System.Collections;

public class GameOptions : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    #region Singleton
    private static GameOptions _instance;

    public static GameOptions instance {
        get {
            if (_instance == null) {//in case not awake yet
                _instance = FindObjectOfType<GameOptions>();
            }           
            return _instance;
        }
    }

    void Awake() {
        if (_instance != null && _instance != this) {
            Debug.LogError("Duplicate singleton " + this.gameObject + " created; destroying it now");
            Destroy(this.gameObject);
        }

        if (_instance != this) {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

    }
    #endregion

}
