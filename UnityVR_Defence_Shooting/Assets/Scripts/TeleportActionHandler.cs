using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class TeleportActionHandler : MonoBehaviour
{
	[SerializeField]
	private	InputActionReference	inputActionRef;   // XRI LeftHand Locomotion/Teleport mode active
	[SerializeField]
	private	UnityEvent				onShow;
	[SerializeField]
	private	UnityEvent				onHide;

	// 광선 활성, 비활성화 제어
	private void OnEnable()
	{
		inputActionRef.action.performed	+= OnPerformed;
		inputActionRef.action.canceled	+= OnCanceled;
	}

	private void OnDisable()
	{
		inputActionRef.action.performed	-= OnPerformed;
		inputActionRef.action.canceled	-= OnCanceled;
	}

	public void OnPerformed(InputAction.CallbackContext obj)
	{
		StartCoroutine(DelayCall(onShow));
	}

	public void OnCanceled(InputAction.CallbackContext obj)
	{
		StartCoroutine(DelayCall(onHide));
	}

	private IEnumerator DelayCall(UnityEvent e)
	{
		yield return null;

		e?.Invoke();
	}
}

