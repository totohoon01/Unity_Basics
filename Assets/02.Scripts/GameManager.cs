using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //동적으로 몬스터 생성
    private float respawnTime = 3.0f;
    public GameObject monsterPrefab;

    private Transform[] points; //(a)
    public bool isGameOver;

    //싱글턴 패턴
    private static GameManager instance = null;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }


    void Start()
    {
        monsterPrefab = Resources.Load<GameObject>("monster");
        points = GameObject.Find("SpawnPointsGroup").GetComponentsInChildren<Transform>();
        StartCoroutine(GenerateMonster()); //(a)
    }

    IEnumerator GenerateMonster() //(a)
    {
        yield return new WaitForSeconds(2.0f);
        while (!isGameOver)
        {
            //위치 랜덤하게 뽑아서 생성
            int idx = Random.Range(1, points.Length);
            Quaternion rot = Quaternion.LookRotation(Vector3.zero);
            GameObject monster = Instantiate<GameObject>(monsterPrefab, points[idx].position, rot);
            monster.name = "Monster";
            yield return new WaitForSeconds(respawnTime);
        }
    }
}
