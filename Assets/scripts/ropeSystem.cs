using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ropeSystem : MonoBehaviour
{
    // 1
    public GameObject ropeHingeAnchor;
    public DistanceJoint2D ropeJoint;
    public Transform crosshair;
    public SpriteRenderer crosshairSprite;
    
    private bool ropeAttached;
    private Vector2 playerPosition;
    private Rigidbody2D ropeHingeAnchorRb;
    private SpriteRenderer ropeHingeAnchorSprite;
    public LineRenderer ropeRenderer;
    public LayerMask ropeLayerMask;
    private float ropeMaxCastDistance = 20f;
    private List<Vector2> ropePositions = new List<Vector2>();
    private bool distanceSet;
    public Animator animator;
    private float climb;
    public DistanceJoint2D distanceJoint2D;
    public AudioClip ropeSound;
    
    //private void Start()
    //{

    //}
    void Start()
    {
        // 2
        distanceJoint2D.enabled = true;
        ropeMaxCastDistance = 7f;
        ropeJoint.enabled = false;
        playerPosition = transform.position;
        ropeHingeAnchorRb = ropeHingeAnchor.GetComponent<Rigidbody2D>();
        ropeHingeAnchorSprite = ropeHingeAnchor.GetComponent<SpriteRenderer>();
        ropeAttached = false;
        climb = 0f;
    }

    void Update()
    {
        // 3
        var worldMousePosition =
            Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
        var facingDirection = worldMousePosition - transform.position;
        var aimAngle = Mathf.Atan2(facingDirection.y, facingDirection.x);
        if (aimAngle < 0f)
        {
            aimAngle = Mathf.PI * 2 + aimAngle;
        }

        // 4
        var aimDirection = Quaternion.Euler(0, 0, aimAngle * Mathf.Rad2Deg) * Vector2.right;
        // 5
        playerPosition = transform.position;

        // 6
        if (!ropeAttached)
        {
            SetCrosshairPosition(aimAngle);
        }
        else
        {
            crosshairSprite.enabled = false;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //climb += 0.5f;
            ropeJoint.distance -= 0.1f;
            //Debug.Log(climb);
        }
        //Climbing();
        HandleInput(aimDirection);
        UpdateRopePositions();
        

    }
    
    private void SetCrosshairPosition(float aimAngle)
    {
        if (!crosshairSprite.enabled)
        {
            crosshairSprite.enabled = true;
        }

        var x = transform.position.x + 5f * Mathf.Cos(aimAngle);
        var y = transform.position.y + 5f * Mathf.Sin(aimAngle);

        var crossHairPosition = new Vector3(x, y, 0);
        crosshair.transform.position = crossHairPosition;
    }
    // 1
    //private void Climbing()
    //{
        
    //}
    private void HandleInput(Vector2 aimDirection)
    {
        if (Input.GetMouseButton(0))
        {
            // 2
            if (ropeAttached) return;
            ropeRenderer.enabled = true;
            
            var hit = Physics2D.Raycast(playerPosition, aimDirection, ropeMaxCastDistance, ropeLayerMask);
            // 3
            
            if (hit.collider != null)
            {
                ropeAttached = true;
                GetComponent<AudioSource>().PlayOneShot(ropeSound);
                if (!ropePositions.Contains(hit.point))
                {
                    // 4
                    // Jump slightly to distance the player a little from the ground after grappling to something.
                    //transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 2f), ForceMode2D.Impulse);
                    ropePositions.Add(hit.point);
                    ropeJoint.distance = Vector2.Distance(playerPosition, hit.point);
                    ropeJoint.enabled = true;
                    ropeHingeAnchorSprite.enabled = true;
                }

            }
            // 5
            else
            {
                ropeRenderer.enabled = false;
                ropeAttached = false;
                ropeJoint.enabled = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && ropeAttached)
        {
            Vector3 theScale = transform.localScale;
            transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(JumpForceX(), 45f), ForceMode2D.Impulse);
            ResetRope();
        }
    }
    private float JumpForceY()
    {
        //float maximum = 45f;
        float default_x = crosshair.transform.position.x;
        Debug.Log(ropeHingeAnchor.transform.position.y + 10 / Mathf.Abs(ropeHingeAnchor.transform.position.x - default_x));
        return gameObject.transform.position.y+10/Mathf.Abs(ropeHingeAnchor.transform.position.x - default_x);

    }
    private float JumpForceX()
    {
        float return_value = 0f;
        Vector3 theScale = transform.localScale;
        if (theScale.x >= 0)
        {
            return_value = 10f;
        }
        else if (theScale.x >= 0)
        {
            return_value = -10f;
        }
        return return_value;
    }

    // 6
    private void ResetRope()
    {
        ropeJoint.enabled = false;
        ropeAttached = false;
        //playerMovement.isSwinging = false;
        ropeRenderer.positionCount = 2;
        ropeRenderer.SetPosition(0, transform.position);
        ropeRenderer.SetPosition(1, transform.position);
        ropePositions.Clear();
        ropeHingeAnchorSprite.enabled = false;
    }
    private void UpdateRopePositions()
    {
        // 1
        if (!ropeAttached)
        {
            return;
        }
        // 2
        ropeRenderer.positionCount = ropePositions.Count + 1;

        //3
        for (var i = ropeRenderer.positionCount - 1; i >= 0; i--)
        {
            
            if (i != ropeRenderer.positionCount - 1) // if not the Last point of line renderer
            {
                ropeRenderer.SetPosition(i, ropePositions[i]);

                // 4
                if (i == ropePositions.Count - 1 || ropePositions.Count == 1)
                {
                    var ropePosition = ropePositions[ropePositions.Count - 1];
                    if (ropePositions.Count == 1)
                    {
                        ropeHingeAnchorRb.transform.position = ropePosition;
                        if (!distanceSet)
                        {

                            ropeJoint.distance = Vector2.Distance(transform.position, ropePosition);
                            ropeJoint.distance = ropeJoint.distance;
                            distanceSet = true;
                        }
                    }
                    else
                    {
                        ropeHingeAnchorRb.transform.position = ropePosition;
                        if (!distanceSet)
                        {
                            ropeJoint.distance = Vector2.Distance(transform.position, ropePosition);
                            distanceSet = true;
                        }
                    }
                }
                // 5
                else if (i - 1 == ropePositions.IndexOf(ropePositions.Last()))
                {
                    var ropePosition = ropePositions.Last();
                    ropeHingeAnchorRb.transform.position = ropePosition;
                    if (!distanceSet)
                    {
                        ropeJoint.distance = Vector2.Distance(transform.position, ropePosition) - climb;
                        distanceSet = true;
                    }
                }
            }
            else
            {
           
             
                // 6
                ropeRenderer.SetPosition(i, new Vector2(transform.position.x, transform.position.y));
            }
        }
    }
}
