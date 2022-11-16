using UnityEngine;
using UnityEngine.AI;

public class ChangeAgentDestinationToCore : MonoBehaviour
{
	private	NavMeshAgent target;

	private void Awake()
	{
		target = GetComponent<NavMeshAgent>();
	}

	public void Call()
	{
		// Core ��ġ�� ��ǥ�������� ����
		target.SetDestination(Core.Instance.transform.position);
	}
}

