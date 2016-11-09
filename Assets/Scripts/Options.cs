using UnityEngine;
using System.Collections;

public class Options : MonoBehaviour {


    public void Submit() {
        Debug.Log("Button " + name + " pressed");
        if (LevelManager.instance) {
            LevelManager.instance.OptionsMenu();
        } else {
            Debug.LogWarning("Missing singleton: LevelManager");
        }
    }

}
