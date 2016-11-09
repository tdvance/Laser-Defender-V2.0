using UnityEngine;
using System.Collections;

public class Quit : MonoBehaviour {


   public void Submit() {
        Debug.Log("Button " + name + " pressed");
        LevelManager.instance.Quit();
    }

}
