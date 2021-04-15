using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    //Transform Component
    private Transform tr;
    private float moveSpeed = 5.0f;
    private float turnSpeed;

    //Animation Componet
    private Animation anim;

    //Varialbes
    private float h;
    private float v;
    private float r;

    //Player HP comp
    private float initHp = 100.0f;
    private float curHp = 100.0f;

    //Player Die Event
    public delegate void PlayerDieHandler();
    public static event PlayerDieHandler OnPlayerDie;

    IEnumerator Start()
    {
        turnSpeed = 0.0f;
        tr = GetComponent<Transform>();
        anim = GetComponent<Animation>();
        anim.Play("Idle");

        yield return new WaitForSeconds(0.2f);
        turnSpeed = 80.0f;
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

    void OnTriggerEnter(Collider coll)
    {
        if (curHp > 0.0f && coll.CompareTag("PUNCH"))
        {
            curHp -= 10.0f;
            if (curHp <= 0.0f)
            {
                //플레이어가 죽었을때 발생하는 이벤트()
                OnPlayerDie();
            }
        }
    }
}
