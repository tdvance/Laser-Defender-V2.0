using UnityEngine;
using System.Collections;

public class Options : MonoBehaviour {


    public void Submit() {
        Debug.Log("Button " + name + " pressed");
        LevelManager.instance.OptionsMenu();
    }

}
