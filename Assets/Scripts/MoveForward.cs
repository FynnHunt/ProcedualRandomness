using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour {

    public float movementSpeed = 0f;
    public float jumpSpeed = 2f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space)) {
            transform.Translate(Vector3.up * jumpSpeed);
        }

	}
}
