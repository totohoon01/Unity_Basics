using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    void Awake()
    {
        //Start보다 먼저 1회
    }
    void OnEnable()
    {
        //활성화될때 마다!
    }
    void Start()
    {
        //Awake 이후 1회 실행
        Debug.Log("Hello");
    }

    void Update()
    {
        // 매 프레임마다 호출되는 함수
        // 화면 렌더링 주기
    }
    void FixedUpdate()
    {
        // 정확한 시간 간격 마다 호출
        // 물리엔지의 계산주기
    }

    void LateUpdate()
    {
        // '모든 스크립트'의 Update가 실행된 이후에 호출
    }
}
