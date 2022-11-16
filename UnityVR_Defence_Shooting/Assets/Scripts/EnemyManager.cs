using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyManager : MonoBehaviour
{
	// ���� ����, ������ ���� �̺�Ʈ�� ȣ��
	private	static	EnemyManager	instance;
	public	static	EnemyManager	Instance
	{
		get
		{
			if ( instance == null )
				instance = GameObject.FindObjectOfType<EnemyManager>();

			return instance;
		}
	}

	[SerializeField]
	private	UnityEvent<Enemy>	onSpawn;
	[SerializeField]
	private	UnityEvent<Enemy>	onDestroy;

	private	List<Enemy>			enemyList = new List<Enemy>();

	private void Awake()
	{
		instance = this;
	}

	public void OnSpawn(Enemy enemy)
	{
		enemyList.Add(enemy);

		onSpawn?.Invoke(enemy);   // spawnCount ++
    }

	public void OnDestroyed(Enemy enemy)
	{
		if ( enemyList.Remove(enemy) )
		{
			onDestroy?.Invoke(enemy);   // killCount ++
        }
	}

	public void DestroyAll()
	{
		while ( enemyList.Count > 0 )
		{
			enemyList[0]?.Destroy();
		}
	}
}

