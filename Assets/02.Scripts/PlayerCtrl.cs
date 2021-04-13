using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    //Transform Component
    private Transform tr;
    private float moveSpeed = 5.0f;
    private float turnSpeed = 20.0f;

    //Animation Componet
    private Animation anim;

    //Varialbes
    private float h;
    private float v;
    private float r;

    void Start()
    {
        tr = GetComponent<Transform>();
        anim = GetComponent<Animation>();
        anim.Play("Idle");
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        r = Input.GetAxis("Mouse X");

        MovePlayer();
        RotatePlayer();
        PlayAnim();
    }
    void MovePlayer()
    {
        Vector3 moveDir = Vector3.forward * v + Vector3.right * h;
        tr.Translate(moveDir.normalized * moveSpeed * Time.deltaTime);
    }
    void RotatePlayer()
    {
        Vector3 rotateDir = Vector3.up * Time.deltaTime * r * turnSpeed;
        tr.Rotate(rotateDir);
    }
    void PlayAnim()
    {
        if (v >= 0.1f)
        {
            anim.CrossFade("RunF", 0.25f);
        }
        else if (v <= -0.1f)
        {
            anim.CrossFade("RunB", 0.25f);
        }
        else if (h >= 0.1f)
        {
            anim.CrossFade("RunL", 0.25f);
        }
        else if (h <= -0.1f)
        {
            anim.CrossFade("RunR", 0.25f);
        }
        else
        {
            anim.CrossFade("Idle", 0.25f);
        }

        if (Input.GetAxis("Fire1") > 0)
        {
            anim.CrossFade("IdleFireSMG", 0.25f);
        }
    }
}
