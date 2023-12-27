using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GlobalLight : MonoBehaviour
{
    public static Light2D instance;
    void Start()
    {
        instance = this.GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
