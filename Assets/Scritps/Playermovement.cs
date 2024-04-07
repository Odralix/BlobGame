using UnityEngine;

public class Playermovement : MonoBehaviour
{

    [SerializeField]
    private float playerSpeed = 1000.0f;

    [SerializeField]
    private float jumpForce = 1.5f;

    [SerializeField]
    private Rigidbody playerBody;

    private Vector3 playerMovementInput;

    public float groundOffset = 3f;

    [SerializeField]
    Transform footPosition;

    [SerializeField]
    bool isGrounded;

    [SerializeField]
    int timesJumped = 0;

    //[SerializeField]
    //float MaxUpwardsForce = ;

    LayerMask mask;

    int playerLayer = 8;
    int pickupableLayer = 9;

    bool OnGround()
    {
        //RaycastHit closestValidHit = new RaycastHit();
        //RaycastHit[] hits = Physics.RaycastAll(footPosition.position, 100f, layers);
        //foreach (RaycastHit hit in hits)
        //{
        //    if (hit.transform.IsChildOf(tranform) && (closestValidHit.collider == null || closestValidHit.distance > hit.distance))
        //    {
        //        closestValidHit = hit;
        //    }
        //}

        return Physics.Raycast(footPosition.position, -Vector3.up, 0.5f, ~mask);
    }

    void Start()
    {
        mask = (1 << playerLayer);
        mask |= (1 << pickupableLayer);
    }

    [SerializeField]
    float jumpCooldown = 0;

    void Update()
    {
        isGrounded = OnGround();
        MovePlayer();


        if (jumpCooldown > 0)
        {
            jumpCooldown -= Time.deltaTime;
        }


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && jumpCooldown <= 0f)
        {
            playerBody.AddForce(Vector3.up * jumpForce * Time.deltaTime, ForceMode.Impulse);
            jumpCooldown = 1;
        }
    }

    void MovePlayer()
    {
        playerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        Vector3 moveVector = transform.TransformDirection(playerMovementInput) * Time.deltaTime * playerSpeed;

        playerBody.velocity = new Vector3(moveVector.x, playerBody.velocity.y, moveVector.z);

    }
}
