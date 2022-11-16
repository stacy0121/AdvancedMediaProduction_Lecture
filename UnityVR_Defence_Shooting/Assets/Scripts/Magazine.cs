using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Magazine : MonoBehaviour, IReloadable    // IReloadable 인터페이스 상속
{
    [SerializeField]
    private float chargingTime = 2;
    [SerializeField]
    private int maxAmmo = 20;
    private int currentAmmo;

    [SerializeField]
    private UnityEvent onReloadStart;
    [SerializeField]
    private UnityEvent onReloadEnd;
    [SerializeField]
    private UnityEvent<int> onAmmoChanged;
    [SerializeField]
    private UnityEvent<float> onChargeChanged;

    // 무기(총)의 탄약을 관리
    private int CurrentAmmo
    {
        get => currentAmmo;
        set
        {
            if (value < 0) currentAmmo = 0;
            else if (value > maxAmmo) currentAmmo = maxAmmo;
            else currentAmmo = value;

            onAmmoChanged?.Invoke(currentAmmo);
            onChargeChanged?.Invoke((float)currentAmmo / maxAmmo);
        }
    }

    private void Start()
    {
        CurrentAmmo = maxAmmo;
    }

    public bool Use(int amount = 1)
    {
        if (CurrentAmmo >= amount)   // 현재 탄약이 1보다 크거나 같으면
        {
            CurrentAmmo -= amount;   // 탄약이 줄어듦
            return true;
        }
        else
        {
            return false;
        }
    }

    //[ContextMenu("Reload")]   // StartReload 호출
    public void StartReload()
    {
        if (CurrentAmmo == maxAmmo) return;

        StopAllCoroutines();
        StartCoroutine("ReloadProcess");
    }

    public void StopReload()
    {
        StopAllCoroutines();
    }

    private IEnumerator ReloadProcess()
    {
        onReloadStart?.Invoke();

        float beginTime = Time.time;
        int beginAmmo = currentAmmo;
        float enoughPercent = 1 - ((float)currentAmmo / maxAmmo);
        float enoughChargingTime = chargingTime * enoughPercent;

        while (true)
        {
            float t = (Time.time - beginTime) / enoughChargingTime;

            if (t >= 1) break;

            CurrentAmmo = (int)Mathf.Lerp(beginAmmo, maxAmmo, t);
            yield return null;
        }

        CurrentAmmo = maxAmmo;
        onReloadEnd?.Invoke();
    }
}
