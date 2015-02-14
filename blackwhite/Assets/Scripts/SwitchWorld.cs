using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SwitchWorld : MonoBehaviour
{

    private static Color32 WHITE = new Color32(255, 255, 255, 255);
    private static Color32 BLACK = new Color32(144, 164, 174, 255);

    public GameObject PlayerWhite;
    public GameObject PlayerBlack;

    public GameObject ColliderLeft;
    public GameObject ColliderRight;

    public SpriteRenderer RendereWhite;
    public SpriteRenderer RendereBlack;

    public Camera MainCamera;
    public Camera FlashlightCamera;

    public GameObject Panel;

    public PlayerMovement playerMovement;

    public MoveObject moveObject;

    public bool canSwitch = true;

    public float minSwipeDistY;
    private Vector2 startPos;
    private Vector2 endPos;

    public bool whiteWorld = true;

    void LateUpdate()
    {
        if (canSwitch)
        {
            if (Input.GetMouseButtonDown(0))
            {
                startPos = Input.mousePosition;
            }

            if (Input.GetMouseButtonUp(0))
            {
                endPos = Input.mousePosition;
                Debug.Log(startPos.y - endPos.y > minSwipeDistY);

                if (startPos.y - endPos.y > Screen.height / 2)
                {
                    if (Mathf.Sign(startPos.y) - Mathf.Sign(endPos.y) / Mathf.Sign(startPos.x) - Mathf.Sign(endPos.x) < 1)
                    {
                        StartCoroutine(changeWorld());

                        GetComponent<Animator>().SetBool("Walking", false);
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(changeWorld());
            }
        }
    }

    IEnumerator changeWorld()
    {
        canSwitch = false;

        Panel.GetComponent<Animator>().SetTrigger("ChangeWorldTrigger");

        yield return new WaitForSeconds(0.5f);

        if (MainCamera.cullingMask == (1 << 9 | 1 << 0))
        {
            MainCamera.cullingMask = 1 << 8 | 1 << 0;
            FlashlightCamera.cullingMask = 1 << 9 | 1 << 10;
            ColliderLeft.layer = 8;
            ColliderRight.layer = 8;

            PlayerWhite.GetComponent<Collider2D>().enabled = true;
            PlayerBlack.GetComponent<Collider2D>().enabled = false;

            RendereBlack.color = new Color(1, 1, 1, 0);
            RendereWhite.color = new Color(1, 1, 1, 1);

            MainCamera.backgroundColor = WHITE;
            FlashlightCamera.backgroundColor = BLACK;

            whiteWorld = true;

            foreach (GameObject g in GameObject.FindGameObjectsWithTag("Dynamic"))
            {
                g.layer = 8;
            }
            if (moveObject.Moving)
            {
                moveObject.ReleaseObject();
            }

            foreach (GameObject g in GameObject.FindGameObjectsWithTag("Button"))
            {
                g.GetComponent<ButtonScript>().OnTriggerExit2D(new Collider2D());
                g.GetComponent<OpenDoor>().OnTriggerExit2D(new Collider2D());
                g.GetComponent<Animator>().Play("buttonUnpressed");
            }
        }
        else
        {
            MainCamera.cullingMask = 1 << 9 | 1 << 0;
            FlashlightCamera.cullingMask = 1 << 8 | 1 << 10;

            ColliderLeft.layer = 9;
            ColliderRight.layer = 9;

            PlayerWhite.GetComponent<Collider2D>().enabled = false;
            PlayerBlack.GetComponent<Collider2D>().enabled = true;

            RendereBlack.color = new Color(1, 1, 1, 1);
            RendereWhite.color = new Color(1, 1, 1, 0);

            MainCamera.backgroundColor = BLACK;
            FlashlightCamera.backgroundColor = WHITE;

            whiteWorld = false;

            foreach (GameObject g in GameObject.FindGameObjectsWithTag("Dynamic"))
            {
                g.layer = 9;
            }
        }

        yield return new WaitForSeconds(0.5f);

        if (Panel.GetComponent<Image>().color.r != 1f)
        {
            Panel.GetComponent<Image>().color = new Color32(WHITE.r, WHITE.g, WHITE.b, 0);
        }
        else
        {
            Panel.GetComponent<Image>().color = new Color32(BLACK.r, BLACK.g, BLACK.b, 0);
        }

        canSwitch = true;
    }
}