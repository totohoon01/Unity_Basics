using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //동적으로 몬스터 생성
    private float respawnTime = 3.0f;
    public GameObject monsterPrefab;
    public bool isGameOver;
    private Transform[] points; //(a)

    //몬스터 풀링 //(b)
    public List<GameObject> monsterPool = new List<GameObject>();
    public int maxPool = 10;

    //싱글턴 패턴 -> 클래스를 정적으로 만듬. public 요소를 다른 스크립트에서 사용가능.
    public static GameManager instance = null;
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
        // StartCoroutine(GenerateMonster()); //(a)

        //오브젝트 풀링
        CreatePool();
        StartCoroutine(GetMonsterFromPool());
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

    void CreatePool() //(b)
    {
        //몬스터를 생성해서 풀에 넣는다.
        for (int i = 0; i <= maxPool; i++)
        {
            GameObject monster = Instantiate<GameObject>(monsterPrefab);
            monster.name = $"Monster_{i:000}";
            monster.SetActive(false);
            monsterPool.Add(monster);
        }
    }
    IEnumerator GetMonsterFromPool()
    {
        //풀에서 몬스터를 가져온다.
        while (!isGameOver)
        {
            yield return new WaitForSeconds(respawnTime);
            foreach (var monster in monsterPool)
            {
                //몬스터가 비활성화 되어있으면,
                if (!monster.activeSelf)
                {
                    monster.SetActive(true);
                    int idx = Random.Range(1, monsterPool.Count);
                    monster.transform.position = points[idx].position;
                    monster.transform.LookAt(Vector3.zero);
                    break;
                }
            }
        }
    }
}
