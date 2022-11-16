using UnityEngine;
using UnityEngine.Events;

public class EventBridge : MonoBehaviour
{
	[SerializeField]
	private	UnityEvent	onCall;

	// ���� ���� ��ư�� ������ �� �̺�Ʈ �޼ҵ� ȣ��
	public void Call()
	{
		onCall?.Invoke();
	}
}

