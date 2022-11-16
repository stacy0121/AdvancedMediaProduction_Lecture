using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WeaponStand : MonoBehaviour
{
	// 무기를 거치하면 재장전
	public void OnSocketed(SelectEnterEventArgs args)
	{
		var reloadable = args.interactableObject.transform.GetComponent<IReloadable>();
		reloadable?.StartReload();
	}

	public void OnUnsocketed(SelectExitEventArgs args)
	{
		var reloadable = args.interactableObject.transform.GetComponent<IReloadable>();
		reloadable?.StopReload();
	}
}

