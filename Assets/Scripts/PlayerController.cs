using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {
    public float speed = 20f;
    public float xMin = -8.4f;
    public float xMax = 8.4f;



    // Use this for initialization
    void Start() {
        float multiplier = (float)Screen.width / (float)Screen.height * 9f / 16f;
        xMax *= multiplier;
        xMin *= multiplier;
        Vector3 s = GetComponent<SpriteRenderer>().transform.localScale;
        GetComponent<SpriteRenderer>().transform.localScale = new Vector3(s.x * multiplier, s.y, s.z);
    }

    // Update is called once per frame
        void Update() {
        float dx = GetInput();
        MoveShipBy(dx);
    }

    float GetInput() {
        return CrossPlatformInputManager.GetAxis("Horizontal") * speed;
    }

    void MoveShipBy(float dx) {
        transform.Translate(Vector3.right * dx * Time.deltaTime);
        if (transform.position.x < xMin) {
            transform.position = new Vector2(xMin, transform.position.y);
        } else if (transform.position.x > xMax) {
            transform.position = new Vector2(xMax, transform.position.y);
        }
    }
}

