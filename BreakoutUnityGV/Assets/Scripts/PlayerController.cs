using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    static Vector3 bottomLeft;
    static Vector3 topRight;
    static Rect cameraRect;
    public bool OtherSide;
    public Vector2 direction = new Vector2();
    public Vector2 keyDirection;
    public bool IsKeyDown
    {
        get
        {
            if (keyDirection.sqrMagnitude == 0) return false;
            return true;
        }
    }

    public PlayerController()
    {

    }

    void Awake()
    {
        keyDirection = new Vector2();
    }

    // Use this for initialization
    void Start()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(Vector3.zero);
        topRight = Camera.main.ScreenToWorldPoint(new Vector3(
            Camera.main.pixelWidth, Camera.main.pixelHeight));

        cameraRect = new Rect(
            bottomLeft.x,
            bottomLeft.y,
            topRight.x - bottomLeft.x,
            topRight.y - bottomLeft.y);
    }

    // Update is called once per frame
    void Update()
    {

        //direction.x = direction.y = 0;
        keyDirection.x = keyDirection.y = 0;

        //For other player's controller
        if (OtherSide == true)
        {
            if (Input.GetKey("d") && (this.gameObject.transform.position.x < ((topRight.x + bottomLeft.x) - 1.1)))
            {
                keyDirection.x += 1;
            }
            if (Input.GetKey("a") && (this.gameObject.transform.position.x > (bottomLeft.x + 1)))
            {
                keyDirection.x += -1;
            }
        }
        //Main player's controller
        else
        {
            if (Input.GetKey("right") && (this.gameObject.transform.position.x < (topRight.x - 1)))
            {
                keyDirection.x += 1;
            }
            if (Input.GetKey("left") && (this.gameObject.transform.position.x > ((topRight.x + bottomLeft.x) + 1.1)))
            {
                keyDirection.x += -1;
            }
        }

        /*if (Input.GetKey("up"))
        {
            keyDirection.y += 1;
        }
        if (Input.GetKey("down"))
        {
            keyDirection.y += -1;
        }*/

        direction += keyDirection;
        direction.Normalize();


    }
}
