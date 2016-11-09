using UnityEngine;
using System.Collections;

public class Quit : MonoBehaviour {


   public void Submit() {
        Debug.Log("Button " + name + " pressed");
        if (LevelManager.instance) {
            LevelManager.instance.Quit();
        } else {
            Debug.LogWarning("Missing singleton: LevelManager");
        }
    }

}
