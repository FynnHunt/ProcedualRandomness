using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIScript : MonoBehaviour {

    public GameObject player;
    public Text weightText;

    private NucleonSpawner spawner;
	// Use this for initialization
	void Start () {
        spawner = player.GetComponent<NucleonSpawner>();
	}
	
	// Update is called once per frame
	void Update () {
        weightText.text = ("Weight: " + spawner.getSize());
	}
}
