using UnityEngine;
using System.Collections;

public class Play : MonoBehaviour {


   public void Submit() {
        Debug.Log("Button " + name + " pressed");
        LevelManager.instance.StartGame();
    }

}
