using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour
{
    public Vector2 Direction;
    public float Speed;

    public GameObject Paddle;
    public GameObject OtherPaddle;
    public GameObject LostButton;
    private bool PlayerRespawn = true;
    private bool CanRespawn = true;
    private Vector3 BallRespawn;

    private Rigidbody2D rb2D;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        Util.GetComponentIfNull<SpriteRenderer>(this, ref spriteRenderer); 
        rb2D = GetComponent<Rigidbody2D>();//Check for null?
    }

    // Use this for initialization
    void Start()
    {
        BallRespawn = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        RespawnOrLose();
    }

    private void RespawnOrLose()
    {
        if (this.gameObject.transform.position.y < (Paddle.transform.position.y - .8) && PlayerRespawn == true)
        {
            ScoreManager.Lives -= 1;
            PlayerRespawn = false;
            if (CanRespawn == true)
            {
                this.gameObject.transform.position = new Vector3(OtherPaddle.transform.position.x, BallRespawn.y, 0);
                CanRespawn = false;
                PlayerRespawn = true;
            }
            else
            {
                this.gameObject.transform.position = new Vector3(Paddle.transform.position.x, BallRespawn.y, 0);
                CanRespawn = true;
                PlayerRespawn = true;
            }

            if (ScoreManager.Lives <= 0)
            {
                LostButton.SetActive(true);
                this.gameObject.SetActive(false);
            }
        }
    }

    /// <summary>
    /// FixedUpdate uses physics
    /// </summary>
    void FixedUpdate()
    {
        if (rb2D != null)
        {
            //Keep on screen
            this.rb2D.position = Util.BounceOffWalls(this.transform.position,
                spriteRenderer.bounds.size.x - 1,
                spriteRenderer.bounds.size.y - 1, ref this.Direction);
        }

        rb2D.MovePosition(rb2D.position + Direction * Speed * Time.fixedDeltaTime);
    }

    /// <summary>
    /// Adds a bit of randomness to the ball bounce collision
    /// </summary>
    public void UpdateBallCollisionRandomFuness()
    {
        /// 
        /// Adds a bit of entropy to bounce nothing should be perfect
        /// 
        /// 
        this.Direction.y *= GetReflectEntropy();
    }


    private float GetReflectEntropy()
    {
        return -1 + ((Random.Range(0, 3) - 1) * 0.1f); //return -.9, -1 or -1.1
    }

    public void RelfectY()
    {
        this.Direction.y *= -1;
    }

    public void RelfectX()
    {
        this.Direction.x *= -1;
    }


}
