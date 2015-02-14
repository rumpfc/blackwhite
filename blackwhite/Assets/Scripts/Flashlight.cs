using UnityEngine;
using System.Collections;

public class Flashlight : MonoBehaviour
{
    public GameObject FlashlightCamera;

    private Vector2 flashLightPos;
    private SkinnedMeshRenderer skinnedRenderer;

    void Start()
    {
        skinnedRenderer = gameObject.GetComponent<SkinnedMeshRenderer>();

        float size = (Camera.main.aspect * Camera.main.orthographicSize) / 10;

        transform.localScale = new Vector3(size, size, size);
        transform.localPosition = new Vector3(0f, -Camera.main.orthographicSize, 2f);
    }

    void Update()
    {
        if (Input.touchCount == 2)
        {
            FlashlightCamera.SetActive(true);

            Vector2 flashlightPos = ((Input.GetTouch(0).position + Input.GetTouch(1).position) / 2 / Screen.width * 100);

            skinnedRenderer.SetBlendShapeWeight(0, ((Input.touches[0].position - Input.touches[1].position).magnitude) / Screen.width * 100);
            skinnedRenderer.SetBlendShapeWeight(1, flashlightPos.x);
            skinnedRenderer.SetBlendShapeWeight(2, flashlightPos.y);
        }
        else if (Input.GetMouseButton(1))
        {
            FlashlightCamera.SetActive(true);

            skinnedRenderer.SetBlendShapeWeight(0, 50);
            skinnedRenderer.SetBlendShapeWeight(1, Input.mousePosition.x / Screen.width * 100);
            skinnedRenderer.SetBlendShapeWeight(2, Input.mousePosition.y / Screen.width * 100);
        }
        else
        {
            FlashlightCamera.SetActive(false);
            skinnedRenderer.SetBlendShapeWeight(0, 0);

        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 50, 50), Input.touches.Length.ToString());
        if (Input.touchCount == 2)
        {
            GUI.Label(new Rect(10, 70, 50, 50), Input.touches[0].position.ToString());
            GUI.Label(new Rect(10, 130, 50, 50), Input.touches[0].position.ToString());
        }
    }
}