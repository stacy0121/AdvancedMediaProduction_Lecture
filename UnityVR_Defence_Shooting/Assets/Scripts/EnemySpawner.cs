using System.Collections;
using UnityEditor;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;   // "Jack o lantern"
    [SerializeField]
    private bool isPlayOnStart = true;   // ������ �������ڸ��� ���� ������ ������?
    [SerializeField]
    private float startFactor = 1;   // �� ���� ���� �⺻��
    [SerializeField]
    private float additiveFactor = 0.1f;   // �� ���� ���ڿ� �� �� �������� ��
    [SerializeField]
    private float delayPerSpawnGroup = 3;   // �� ���� �ֱ�

    private void Awake()
    {
        if (isPlayOnStart)   // true - �ٷ� ����
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
            yield return new WaitForSeconds(delayPerSpawnGroup);   // 3�� ���
            yield return StartCoroutine(SpawnEnemy(factor));

            factor += additiveFactor;   // 0.1f++
        }
    }

    private IEnumerator SpawnEnemy(float factor)
    {
        float spawnCount = Random.Range(factor, factor * 2);

        for(int i=0;i<spawnCount; i++)
        {
            Instantiate(enemyPrefab, transform.position, transform.rotation, transform);   // �� ����

            if (Random.value < 0.2f)
            {
                yield return new WaitForSeconds(Random.Range(0.01f, 0.02f));
            }
        }
    }
}
