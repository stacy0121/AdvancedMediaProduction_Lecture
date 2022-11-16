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
		// Core 위치를 목표지점으로 설정
		target.SetDestination(Core.Instance.transform.position);
	}
}

