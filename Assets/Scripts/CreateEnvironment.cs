using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnvironment : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Removes the "Sphere" object from the scene itself

        GameObject sphere = GameObject.Find("Sphere");
        Renderer sphereRenderer = sphere.GetComponent<Renderer>();
        if (sphereRenderer == null)
        {
            sphereRenderer = sphere.AddComponent<Renderer>();
            // For some reason, the sphere's initial renderer sometimes isn't recognised.
        }
        sphereRenderer.enabled = false;

        // Calls Position, Rotation, then Scale

        // Bus bus = new Bus(new MyVector(0, 0, 0), new MyVector(0, 0, 0), new MyVector(1, 1, 1));
        
        ProbabilityMachine probabilityMachine = new ProbabilityMachine(new MyVector(0, 0, 0), new MyVector(0, 0, 0), new MyVector(1, 1, 1));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
