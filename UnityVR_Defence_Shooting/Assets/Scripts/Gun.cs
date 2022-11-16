using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class Gun : MonoBehaviour
{
	[SerializeField]
	private	UnityEvent	onGrab;
	[SerializeField]
	private	UnityEvent	onRelease;

	// DirectInteractor만 Grab, Release 하도록 제어  --> Event 실행
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

