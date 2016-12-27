using UnityEngine;
using System.Collections;

public class WeightDoor : MonoBehaviour {

    public GameObject player;
    public int weight;

    private NucleonSpawner spawner;

	// Use this for initialization
	void Start () {
        spawner = player.GetComponent<NucleonSpawner>();
        //Fix line below
        gameObject.GetComponent<Rigidbody>().mass = 1000000000;
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnCollisionEnter(Collision col) {
        if ((col.transform.tag == "Nucleon") || (col.transform.tag == "Pickup")) {
            int size = spawner.getSize();
            if (size >= weight) {
                //Fix here
                gameObject.GetComponent<Rigidbody>().mass = 20000;
            }
        }
    }
}
