using UnityEngine;


public class Sick : MonoBehaviour
{
    private float r=0;
    private float g=2.0f;
    private float b=0;
    private bool stageFlag=true;
    private float changingTime = 0.05f;//тайминг
    bool tagFlag;

    void D()
    {     
        if (gameObject.tag == "Sick")
        {
            if (r < 5.0f && stageFlag)
            {
                r = r + changingTime;
                gameObject.GetComponent<MeshRenderer>().material.color = new Color(r, g, b);
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
                g = g - changingTime;
                gameObject.GetComponent<MeshRenderer>().material.color = new Color(r, g, b);
            }
            else if (r > 0.0f)
            {
                r = r - changingTime;
                gameObject.GetComponent<MeshRenderer>().material.color = new Color(r, g, b);
            }
            else gameObject.tag = "Dead"; 
        }
    }
    public void ClickReciever(bool a)
    {
        if (a) tagFlag = true;
    } 

    void Start()
    {
        var rnd = new System.Random();
        var e = rnd.Next(0, SphereGenerator.listSpheres.Count);
        SphereGenerator.listSpheres[e].tag = "Sick";
    }

    void Update()
    {
        if (tagFlag && gameObject.tag != "Dead" && gameObject.tag != "Healthy")//проверка нажатия
        {
            gameObject.GetComponent<MeshRenderer>().material.color = new Color(255, 0, 255);
            gameObject.tag = "Healed";
        }
        D();
    }
}   
