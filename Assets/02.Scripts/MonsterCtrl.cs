using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterCtrl : MonoBehaviour
{
    public enum STATE { IDLE, TRACE, ATTACK, DIE };
    public STATE state = STATE.IDLE;

    private Transform playerTr;
    private Transform monsterTr;
    private Animator anim;
    private NavMeshAgent agent;

    private bool isDie;
    private float traceDist = 10.0f;
    private float attactDist = 2.0f;
    private float hp = 100.0f;

    private readonly int hashTrace = Animator.StringToHash("isTrace"); //isTrace라는 이름을 가진 해쉬의 ID를 가져옴
    private readonly int hashAttack = Animator.StringToHash("isAttack"); //매번 이름으로 찾는 것에 비해 속도가 빠르다.
    private readonly int hashHit = Animator.StringToHash("Hit");
    private readonly int hashDie = Animator.StringToHash("isDie");

    void Start()
    {
        monsterTr = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        playerTr = GameObject.FindGameObjectWithTag("PLAYER")?.GetComponent<Transform>();

        //코루틴함수
        StartCoroutine(CheckState());
        StartCoroutine(MonsterAction());
    }

    IEnumerator CheckState()
    {
        while (!isDie)
        {
            if (state == STATE.DIE)
            {
                yield break; //코루틴 정지
            }

            //거리에 따른 스테이트 변경
            float dist = Vector3.Distance(monsterTr.position, playerTr.position);
            if (dist <= attactDist)
            {
                state = STATE.ATTACK;
            }
            else if (dist <= traceDist)
            {
                state = STATE.TRACE;
            }
            else
            {
                state = STATE.IDLE;
            }
            yield return new WaitForSeconds(0.5f);
        }

    }
    IEnumerator MonsterAction()
    {
        while (!isDie)
        {
            //스테이트에 따라서 액션 변경
            switch (state)
            {
                case STATE.IDLE:
                    agent.isStopped = true;
                    anim.SetBool(hashTrace, false);
                    break;

                case STATE.TRACE:
                    agent.isStopped = false;
                    agent.SetDestination(playerTr.position);
                    anim.SetBool(hashTrace, true); //불 셋
                    anim.SetBool(hashAttack, false);
                    break;

                case STATE.ATTACK:
                    anim.SetBool(hashAttack, true);
                    break;

                case STATE.DIE:
                    anim.SetTrigger("isDie");
                    isDie = true;
                    GetComponent<CapsuleCollider>().enabled = false; //캡슐 컬라이더 비활성화
                    break;
            }
            yield return new WaitForSeconds(0.3f);
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("BULLET"))
        {
            anim.SetTrigger("Hit"); //트리거 실행
            hp -= 20.0f;
            Destroy(coll.gameObject);
            if (hp <= 0.0f)
            {
                state = STATE.DIE;
            }
        }
    }
}
