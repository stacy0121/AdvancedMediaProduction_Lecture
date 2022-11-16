using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class Gun : MonoBehaviour
{
	[SerializeField]
	private	UnityEvent	onGrab;
	[SerializeField]
	private	UnityEvent	onRelease;

	// DirectInteractor�� Grab, Release �ϵ��� ����  --> Event ����
	public void Grab(SelectEnterEventArgs args)
	{
		var interactor = args.interactorObject;

		if ( interactor is XRDirectInteractor )
		{
			onGrab?.Invoke();
		}
	}

	public void Release(SelectExitEventArgs args)
	{
		var interactor = args.interactorObject;

		if ( interactor is XRDirectInteractor )
		{
			onRelease?.Invoke();
		}
	}
}

