using UnityEngine;
using System.Collections;

public class MapCreator : MonoBehaviour {
    public Mesh mesh;
    public Material material;

    public float childScale;

    public int maxDepth;
    private int depth;

    private static int lastIndex = 0;

    private static Vector3[] childDirections = {
        //Vector3.up,
        Vector3.right,
        Vector3.left,
        Vector3.forward,
        Vector3.back
    };

    // Use this for initialization
    void Start() {
        MeshFilter filter = gameObject.AddComponent<MeshFilter>();
        filter.mesh = mesh;
        MeshRenderer renderer = gameObject.AddComponent<MeshRenderer>();
        renderer.material = material;
        GetComponent<MeshRenderer>().material.color =
            Color.Lerp(Color.white, Color.yellow, (float)depth / maxDepth);
        BoxCollider collider = gameObject.AddComponent<BoxCollider>();
        if (depth < maxDepth) {
            StartCoroutine(CreateChildren());
        }
    }

    private IEnumerator CreateChildren() {
        /*
        for (int i = 0; i < childDirections.Length; i++) {
            yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
            new GameObject("Fractal Child").AddComponent<Fractal>().Initialize(this, i);
        }
        */
        //yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
        yield return new WaitForSeconds(Random.Range(0.01f, 0.05f));
        int rand = Random.Range(0, childDirections.Length);
        if (rand == lastIndex) {
            if (rand == 0) {
                rand++;
            } else if (rand == childDirections.Length-1) {
                rand--;
            } else {
                rand++;
            }
        }
        Debug.Log(rand);
        new GameObject("Fractal Child").AddComponent<MapCreator>().Initialize(this, rand);
        lastIndex = rand;
    }

    private void Initialize(MapCreator parent, int childIndex) {
        mesh = parent.mesh;
        material = parent.material;
        maxDepth = parent.maxDepth;
        depth = parent.depth + 1;
        childScale = parent.childScale;
        transform.parent = parent.transform;
        transform.localScale = Vector3.one * childScale;
        transform.localPosition = childDirections[childIndex] * (0.5f + 0.5f * childScale);
    }

    // Update is called once per frame
    void Update() {

    }
}
