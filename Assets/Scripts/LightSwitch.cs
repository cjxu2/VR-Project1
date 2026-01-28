using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor.AssetImporters;
using UnityEngine;
using UnityEngine.Rendering;

public class LightSwitch : MonoBehaviour
{
    public Light light_component;
    private List<Color> colors = new List<Color>(){Color.white, Color.blue, Color.red};
    private int curr = 0;
    private float delay = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        light_component = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (delay < 0 && Input.GetKey(KeyCode.P))
        {
            light_component.color = colors[(curr += 1) % colors.Count];
            delay = 1;
            Debug.Log(curr % colors.Count);
        }
        else
        {
            delay -= Time.deltaTime;
        }
    }
}
