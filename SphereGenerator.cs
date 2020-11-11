using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereGenerator : MonoBehaviour
{
    public GameObject ourSphere;
    private bool flag = false;
    public static List<GameObject> listSpheres = new List<GameObject>();

    void SpherePrefabGeneration()
    {
        float sphereRadius = ourSphere.GetComponent<SphereCollider>().radius;
        int iterationsCount = 500;
        int clusterSize = 10;
        float distanceBetweenSpheres = 4f;
        int counter = 0;
        for (int i = 0; i < iterationsCount; i++)
        {
            var prefabCenters = UnityEngine.Random.insideUnitSphere * clusterSize;
            Collider[] neighbors = Physics.OverlapSphere(prefabCenters, distanceBetweenSpheres + 2 * sphereRadius);
            if (neighbors.Length == 0)
            {
                counter++;
                var clone = Instantiate(ourSphere, prefabCenters, Quaternion.identity);
                clone.transform.name = "Sphere" + counter;
                listSpheres.Add(clone);
            }
        }
        
    }

    void Start()
    {
        SpherePrefabGeneration();
    }

    void Update()
    {
        
    }
}
