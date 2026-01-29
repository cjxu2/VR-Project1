using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controls : MonoBehaviour
{
    public InputActionReference quitButton;
    
    public GameObject player;
    private bool isOutside = false;

    public GameObject light_obj;
    private Light light_component;
    private List<Color> colors = new List<Color>(){Color.white, Color.blue, Color.red};
    private int curr = 0;
    private float delay = 0.5F;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Quit
        quitButton.action.Enable();
        quitButton.action.performed += (ctx) =>
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        };

        // Light
        light_component = light_obj.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) // Quit
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }

        if (delay < 0 && Input.GetKey(KeyCode.T)) // Teleport
        {
            if (isOutside)
            {
                player.transform.position = new Vector3(0,0.5F,0);
                isOutside = false;
            }
            else
            {
                player.transform.position = new Vector3(50,8,0);
                isOutside = true;
            }
            delay = 1;
        }
        else if (delay < 0 && Input.GetKey(KeyCode.P)) // Light switch
        {
            light_component.color = colors[(curr += 1) % colors.Count];
            delay = 1;
        }
        else
        {
            delay -= Time.deltaTime;
        }
    }
}
