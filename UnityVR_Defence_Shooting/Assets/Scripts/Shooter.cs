using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    private LayerMask hittableMask;
    [SerializeField]
    private GameObject hitEffectPrefab;
    [SerializeField]
    private Transform shootPoint;
    [SerializeField]
    private float shootDelay = 0.1f;
    [SerializeField]
    private float maxDistance = 100;
    [SerializeField]
    private UnityEvent<Vector3> onShootSuccess;
    [SerializeField]
    private UnityEvent onShootFail;

    private Magazine magazine;

    private void Awake()
    {
        magazine = GetComponent<Magazine>();
    }

    private void Start()
    {
        Stop();
    }
    public void Play()
    {
        StopAllCoroutines();
        StartCoroutine("Process");
    }
    public void Stop()
    {
        StopAllCoroutines();
    }
    private IEnumerator Process()
    {
        while (true)
        {
            // 탄약 수에 따라 공격이 성공/실패하도록
            if (magazine.Use())   // 현재 탄약이 1보다 크거나 같으면
            {
                Shoot();   // hit effect 제어
            }
            else
            {
                onShootFail?.Invoke();
            }
            
            yield return new WaitForSeconds(shootDelay);   // 0.1초마다
        }
    }

    private void Shoot()
    {
        // 공격 성공/실패에 따라 공격을 제어
        if (Physics.Raycast(shootPoint.position, shootPoint.forward, out RaycastHit hitInfo, maxDistance, hittableMask))
        {
            Instantiate(hitEffectPrefab,hitInfo.point, Quaternion.identity);   // 공격 성공할 때마다 hit effect 생성 

            // 광선에 부딪힌 오브젝트가 Hittable 컴포넌트를 가지고 있을 때 Hit() 호출 --> Enemy.Destroy
            Hittable hitObejct = hitInfo.transform.GetComponent<Hittable>();
            hitObejct?.Hit();

            onShootSuccess?.Invoke(hitInfo.point);   // 메소드 호출
        }
        else
        {
            Vector3 hitPoint = shootPoint.position + shootPoint.forward * maxDistance;
            onShootSuccess?.Invoke(hitPoint);
        }
    }
}
