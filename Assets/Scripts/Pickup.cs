using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Pickup : MonoBehaviour {

    public float attractionForce;
    public GameObject centreObj;
    public AudioClip pop;

    public bool pickedUp = false;

    Rigidbody body;

    void Awake() {
        centreObj = GameObject.Find("Spawner");
        body = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        if (pickedUp) {
            body.AddForce((transform.localPosition - centreObj.transform.position) * -attractionForce);
        }
    }

    void OnTriggerEnter(Collider col) {
        if (!pickedUp) {
            if (col.transform.tag == "Nucleon") {
                pickedUp = true;
                gameObject.GetComponent<AudioSource>().PlayOneShot(pop);
                centreObj.GetComponent<NucleonSpawner>().addSize(1);
            }
        }
    }
}