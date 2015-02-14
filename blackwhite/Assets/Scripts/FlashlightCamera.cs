using UnityEngine;
using System.Collections;

public class FlashlightCamera : MonoBehaviour
{
    public GameObject flashlight;

    private Vector2 flashLightPos;
    private SkinnedMeshRenderer renderer;

    void Start()
    {
        renderer = gameObject.GetComponent<SkinnedMeshRenderer>();

        float size = (Camera.main.aspect * Camera.main.orthographicSize) / 10;

        transform.localScale = new Vector3(size, size, size);
        transform.localPosition = new Vector3(0f, -Camera.main.orthographicSize, 2f);
    }

    void Update()
    {
        if (Input.touchCount == 2)
        {
            //flashLightPos = Camera.main.ScreenToWorldPoint((Input.touches[0].position + Input.touches[1].position) / 2);

            //showFlashlight(flashLightPos, Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.touches[0].position), Camera.main.ScreenToWorldPoint(Input.touches[1].position)) / 2f);
            //showFlashlight(flashLightPos, 1f);
        }
        if (Input.GetMouseButton(1))
        {
            renderer.SetBlendShapeWeight(0, 50);
            renderer.SetBlendShapeWeight(1, Input.mousePosition.x / Screen.width * 100);
            renderer.SetBlendShapeWeight(2, (Input.mousePosition.y / Screen.height / Camera.main.aspect)* 100);

            //flashLightPos = Camera.main.ScreenToWorldPoint((Input.mousePosition));

            //showFlashlight(flashLightPos, 1f);
        }
        else
        {
            //flashlight.SetActive(false);
        }
    }
    
}