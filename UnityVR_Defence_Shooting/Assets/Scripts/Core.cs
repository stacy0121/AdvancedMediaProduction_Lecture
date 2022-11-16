using UnityEngine;
using UnityEngine.Events;

public class Core : MonoBehaviour
{
	[SerializeField]
	private	int	maxHP = 10;
	private	int	currentHP;

	[SerializeField]
	private	UnityEvent<string>	onHPChanged;
	[SerializeField]
	private	UnityEvent			onHit;
	[SerializeField]
	private	UnityEvent			onDestroy;

	private static Core	instance;
	public	static Core Instance
	{
		get
		{
			if ( instance == null )
				instance = GameObject.FindObjectOfType<Core>();

			return instance;
		}
	}

	private void Awake()
	{
		instance = this;
	}

	private void OnEnable()
	{
		currentHP = maxHP;

		UpdateUI();
	}

	private void OnTriggerEnter(Collider other)   // ��(other)�� ������
	{
		Enemy enemy = other.GetComponent<Enemy>();
		if ( enemy != null )
		{
			onHit?.Invoke();
			DecreaseHP(1);   // ü�� 1 ����
			enemy.Destroy();
		}
	}

	private void DecreaseHP(int amount)
	{
		if ( currentHP <= 0 ) return;

		currentHP -= amount;

		if ( currentHP <= 0 )   // ü�� 0 ���� �Ǹ�
		{
			currentHP = 0;
			onDestroy?.Invoke();
		}

		UpdateUI();
	}

	private void UpdateUI()
	{
		onHPChanged?.Invoke($"HP : {currentHP}");
	}
}

