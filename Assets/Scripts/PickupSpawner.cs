using UnityEngine;
using System.Collections;

public class PickupSpawner : MonoBehaviour {

    public GameObject pickup;
    public int amount;

    private int size = 0;
    private bool finished = false;

	// Use this for initialization
	void Start () {
	}

    void FixedUpdate() {
        if (!finished) {
            if (size < amount) {
                float randHor = Random.Range(0f, 10f);
                float randVert = Random.Range(0f, 20f);
                Vector3 randVector = new Vector3(randHor, randVert, randHor);
                Instantiate(pickup, transform.position + randVector, transform.rotation);
                size++;
            } else {
                finished = true;
                Destroy(gameObject);
            }
        }
    }
}
