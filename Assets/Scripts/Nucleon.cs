using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Nucleon : MonoBehaviour {

    public float attractionForce;
    public GameObject centreObj;
    public AudioClip pop;

    Rigidbody body;

    void Awake() {
        centreObj = GameObject.Find("Spawner");
        body = GetComponent<Rigidbody>();
        gameObject.GetComponent<AudioSource>().PlayOneShot(pop);
    }

    void FixedUpdate() {
        //body.AddForce(transform.localPosition * -attractionForce);
        body.AddForce((transform.localPosition - centreObj.transform.position) * -attractionForce);

    }
}