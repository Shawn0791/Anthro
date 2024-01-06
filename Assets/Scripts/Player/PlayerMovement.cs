using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public LayerMask GroundLayer;
    public float speed;
    public GameObject shape;
    public float jumpForce;
    public GameObject PlanetCentre;

    private Rigidbody rb;
    private Animator anim;
    private bool isGround;
    private RaycastHit hitForward;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        ForceMovement();
        Jump();


        //此处射线检测要排除掉自身，检测到的应该是围绕旋转的中心球
        if (Physics.Raycast(transform.position, -transform.up, out hitForward, 100, GroundLayer))
        {
            //开启此处会使旋转过渡会平滑点
            //transform.rotation = Quaternion.Lerp (transform.rotation , Quaternion.LookRotation (Vector3.Cross (transform.right , hitForward.normal) , hitForward.normal) , Time.deltaTime * 10);
            transform.rotation = Quaternion.LookRotation(Vector3.Cross(transform.right, hitForward.normal), hitForward.normal);
        }
        //gravity
        //rb.AddForce(-transform.up * 10);
        rb.AddForce((PlanetCentre.transform.position - transform.position).normalized * 10f);
    }

    private void ForceMovement()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (h == 0 && v == 0)
        {
            //anim.SetBool("isMoving", false);
            rb.velocity = new Vector3(0, Vector3.Dot(new Vector3(0, rb.velocity.y, 0), transform.up), 0); // dot product
        }
        else
        {
            rb.AddForce((transform.right * h + transform.forward * v).normalized * speed);
            FacingForward();
        }
    }

    private void FacingForward()
    {
        //PlayerBody.forward = new Vector3(velocityX, 0, velocityZ).normalized;
        //shape.transform.forward = new Vector3();
        //shape.transform.up = hitForward.normal;
    }

    private void Jump()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, -transform.up, out hitInfo, 1, GroundLayer))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(transform.up * jumpForce);
            }
        }
    }
}
