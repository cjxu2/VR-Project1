using UnityEngine;
using UnityEngine.UIElements;

public class Spin : MonoBehaviour
{
    private float speed = 20;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.down, Time.deltaTime * speed);
    }
}
