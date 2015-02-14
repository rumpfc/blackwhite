using UnityEngine;
using System.Collections;

public class Paralax : MonoBehaviour
{
    public float Multiplicator;
    public GameObject MainCamera;

    private Vector3 relPos;
    void Start()
    {
        relPos = transform.position - MainCamera.transform.position;
    }

    void Update()
    {
        transform.position = new Vector3((MainCamera.transform.position.x + relPos.x) * Multiplicator, (MainCamera.transform.position.y + relPos.y) * Multiplicator, transform.position.z);
    }
}