using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSphere : MonoBehaviour
{
    public LayerMask GroundLayer;
    public bool isDead;
    public GameObject earth;

    private RaycastHit hitForward;

    private void Start()
    {
        earth = GameObject.FindGameObjectWithTag("Earth");
    }


    void Update()
    {
        if (!isDead)
        {
            Alive();
        }
        else
        {
            Dead();
        }
    }

    private void Alive()
    {
        //此处射线检测要排除掉自身，检测到的应该是围绕旋转的中心球
        if (Physics.Raycast(transform.position, -transform.up, out hitForward, 100, GroundLayer))
        {
            //开启此处会使旋转过渡会平滑点
            //transform.rotation = Quaternion.Lerp (transform.rotation , Quaternion.LookRotation (Vector3.Cross (transform.right , hitForward.normal) , hitForward.normal) , Time.deltaTime * 10);
            transform.rotation = Quaternion.LookRotation(Vector3.Cross(transform.right, hitForward.normal), hitForward.normal);
        }
        //gravity
        GetComponent<Rigidbody>().AddForce(-transform.up * 10);
    }

    private void Dead()
    {
        //gravity
        GetComponent<Rigidbody>().AddForce((earth.transform.position-transform.position).normalized * 10);
    }
}
