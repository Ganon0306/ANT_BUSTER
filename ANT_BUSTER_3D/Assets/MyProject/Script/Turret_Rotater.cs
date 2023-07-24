using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Rotater : MonoBehaviour
{
    public float rotationSpeed = 80f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    public void Run(Transform other)
    {
        other.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}
