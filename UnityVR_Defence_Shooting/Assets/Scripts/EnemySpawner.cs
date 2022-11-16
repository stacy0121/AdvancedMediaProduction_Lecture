using System.Collections;
using UnityEditor;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;   // "Jack o lantern"
    [SerializeField]
    private bool isPlayOnStart = true;   // 게임을 시작하자마자 적을 생성할 것인지?
    [SerializeField]
    private float startFactor = 1;   // 적 생성 숫자 기본값
    [SerializeField]
    private float additiveFactor = 0.1f;   // 적 생성 숫자에 매 턴 더해지는 값
    [SerializeField]
    private float delayPerSpawnGroup = 3;   // 적 생성 주기

    private void Awake()
    {
        if (isPlayOnStart)   // true - 바로 시작
        {
            Play();
        }
    }

    public void Play()
    {
        StartCoroutine("SpawnProcess");
    }

    public void Stop()
    {
        StopAllCoroutines();
    }

    private IEnumerator SpawnProcess()
    {
        float factor = startFactor;   // 1

        while (true)
        {
            yield return new WaitForSeconds(delayPerSpawnGroup);   // 3초 대기
            yield return StartCoroutine(SpawnEnemy(factor));

            factor += additiveFactor;   // 0.1f++
        }
    }

    private IEnumerator SpawnEnemy(float factor)
    {
        float spawnCount = Random.Range(factor, factor * 2);

        for(int i=0;i<spawnCount; i++)
        {
            Instantiate(enemyPrefab, transform.position, transform.rotation, transform);   // 적 생성

            if (Random.value < 0.2f)
            {
                yield return new WaitForSeconds(Random.Range(0.01f, 0.02f));
            }
        }
    }
}
