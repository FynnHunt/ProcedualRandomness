﻿using UnityEngine;
using System.Collections;

public class Fractal : MonoBehaviour {
    public Mesh mesh;
    public Material material;

    public float childScale;

    public int maxDepth;
    private int depth;

    private static Vector3[] childDirections = {
        Vector3.up,
        Vector3.right,
        Vector3.left,
        Vector3.forward,
        Vector3.back
    };

    private static Quaternion[] childOrientations = {
        Quaternion.identity,
        Quaternion.Euler(0f, 0f, -90f),
        Quaternion.Euler(0f, 0f, 90f),
        Quaternion.Euler(90f, 0f, 0f),
        Quaternion.Euler(-90f, 0f, 0f)
    };

	// Use this for initialization
	void Start () {
        MeshFilter filter = gameObject.AddComponent<MeshFilter>();
        filter.mesh = mesh;
        MeshRenderer renderer = gameObject.AddComponent<MeshRenderer>();
        renderer.material = material;
        GetComponent<MeshRenderer>().material.color =
            Color.Lerp(Color.white, Color.yellow, (float)depth / maxDepth);
        if (depth < maxDepth) {
            StartCoroutine(CreateChildren());
        }
	}

    private IEnumerator CreateChildren() {
        for (int i = 0; i < childDirections.Length; i++) {
            yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
            new GameObject("Fractal Child").AddComponent<Fractal>().Initialize(this, i);
        }

    }

    private void Initialize(Fractal parent, int childIndex) {
        mesh = parent.mesh;
        material = parent.material;
        maxDepth = parent.maxDepth;
        depth = parent.depth + 1;
        childScale = parent.childScale;
        transform.parent = parent.transform;
        transform.localScale = Vector3.one * childScale;
        transform.localPosition = childDirections[childIndex] * (0.5f + 0.5f * childScale);
        transform.localRotation = childOrientations[childIndex];
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
