using UnityEngine;
using System.Collections;

public class Resume : MonoBehaviour {


   public void Submit() {
        Debug.Log("Button " + name + " pressed");
        LevelManager.instance.ReturnFromOptions();
    }

}
