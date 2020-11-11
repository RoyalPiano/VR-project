using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;

public class Sick : MonoBehaviour
{
    public Material[] materials;
    public Material material;
    private bool flag = false;
    private double timeStep = 2.0;
    private DateTime sickSturtTime;
    private float r=0;
    private float g=2.0f;
    private float b=0;
    private bool stageFlag=true;

    void D()
    {     
        if (gameObject.tag == "Sick")
        {
            if (r < 5.0f && stageFlag)
            {
                r = r + 0.001f;
                gameObject.GetComponent<MeshRenderer>().material.color = new Color(r, g, b);
                Debug.Log(gameObject.GetComponent<MeshRenderer>().material.color.r);
            }
            else if (g > 0.0f)
            {
                float distanceBetweenSpheres = 10f;
                var sickCenters = gameObject.transform.position;
                Collider[] neighbors = Physics.OverlapSphere(sickCenters, distanceBetweenSpheres);
                foreach (var neighbor in neighbors)
                {
                    if (neighbor.gameObject.tag == "Healthy")
                    {
                        neighbor.gameObject.tag = "Sick";
                    }
                }
                stageFlag = false;
                g = g - 0.001f;
                gameObject.GetComponent<MeshRenderer>().material.color = new Color(r, g, b);
                Debug.Log(gameObject.GetComponent<MeshRenderer>().material.color.g);
            }
            else if (r > 0.0f)
            {
                r = r - 0.05f;
                gameObject.GetComponent<MeshRenderer>().material.color = new Color(r, g, b);
                Debug.Log(gameObject.GetComponent<MeshRenderer>().material.color.r);
            }
            else gameObject.tag = "Dead"; 
        }
    }

    void Start()
    {
        var rnd = new System.Random();
        var e = rnd.Next(0, SphereGenerator.listSpheres.Count);
        SphereGenerator.listSpheres[e].tag = "Sick";
    }

    void Update()
    {
        D();
    }
}  
