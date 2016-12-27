using UnityEngine;

public class NucleonSpawner : MonoBehaviour {

    public float timeBetweenSpawns;
    public float spawnDistance;
    public int maxSize;

    public int size;

    public Nucleon[] nucleonPrefabs;

    float timeSinceLastSpawn;

    void FixedUpdate() {
        timeSinceLastSpawn += Time.deltaTime;
        if (size < maxSize) {
            if (timeSinceLastSpawn >= timeBetweenSpawns) {
                timeSinceLastSpawn -= timeBetweenSpawns;
                SpawnNucleon();
                size++;
            }
        }

        if (Input.GetKey(KeyCode.W)) {
            //GetComponent<Rigidbody>().AddForce(transform.forward * 100f);
            transform.position = transform.position + new Vector3(0.1f, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.S)) {
            //centre.GetComponent<Rigidbody>().AddForce(centre.transform.forward * 0.1f);
            transform.position = transform.position + new Vector3(-0.1f, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.A)) {
            //centre.GetComponent<Rigidbody>().AddForce(centre.transform.forward * 0.1f);
            transform.position = transform.position + new Vector3(0f, 0f, 0.1f);
        }

        if (Input.GetKey(KeyCode.D)) {
            //centre.GetComponent<Rigidbody>().AddForce(centre.transform.forward * 0.1f);
            transform.position = transform.position + new Vector3(0f, 0f, -0.1f);
        }
    }

    void SpawnNucleon() {
        Nucleon prefab = nucleonPrefabs[Random.Range(0, nucleonPrefabs.Length)];
        Nucleon spawn = Instantiate<Nucleon>(prefab);
        //spawn.transform.localPosition = Random.onUnitSphere * spawnDistance;
        Vector3 randVector = new Vector3(Random.Range(0f, 0.2f), 0f, Random.Range(0f, 0.2f));
        spawn.transform.position = transform.position + randVector;
    }

    public void addSize(int amount) {
        size += amount;
    }

    public int getSize() {
        return size;
    }
}