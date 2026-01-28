using UnityEngine;
using UnityEngine.UIElements;

public class Spin : MonoBehaviour
{
    Transform trans;
    public float speed = 20;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        trans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        trans.Rotate(Vector3.down, Time.deltaTime * speed);
    }
}
