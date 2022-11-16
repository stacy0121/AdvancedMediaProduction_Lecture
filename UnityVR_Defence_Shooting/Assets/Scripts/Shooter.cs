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
            // ź�� ���� ���� ������ ����/�����ϵ���
            if (magazine.Use())   // ���� ź���� 1���� ũ�ų� ������
            {
                Shoot();   // hit effect ����
            }
            else
            {
                onShootFail?.Invoke();
            }
            
            yield return new WaitForSeconds(shootDelay);   // 0.1�ʸ���
        }
    }

    private void Shoot()
    {
        // ���� ����/���п� ���� ������ ����
        if (Physics.Raycast(shootPoint.position, shootPoint.forward, out RaycastHit hitInfo, maxDistance, hittableMask))
        {
            Instantiate(hitEffectPrefab,hitInfo.point, Quaternion.identity);   // ���� ������ ������ hit effect ���� 

            // ������ �ε��� ������Ʈ�� Hittable ������Ʈ�� ������ ���� �� Hit() ȣ�� --> Enemy.Destroy
            Hittable hitObejct = hitInfo.transform.GetComponent<Hittable>();
            hitObejct?.Hit();

            onShootSuccess?.Invoke(hitInfo.point);   // �޼ҵ� ȣ��
        }
        else
        {
            Vector3 hitPoint = shootPoint.position + shootPoint.forward * maxDistance;
            onShootSuccess?.Invoke(hitPoint);
        }
    }
}
