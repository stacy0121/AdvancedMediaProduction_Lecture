using UnityEngine;
using UnityEngine.Events;

public class EventBridge : MonoBehaviour
{
	[SerializeField]
	private	UnityEvent	onCall;

	// 게임 시작 버튼을 눌렀을 때 이벤트 메소드 호출
	public void Call()
	{
		onCall?.Invoke();
	}
}

