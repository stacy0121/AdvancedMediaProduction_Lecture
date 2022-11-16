using System.Collections;
using UnityEngine;

public class RayVisualizer : MonoBehaviour
{
    // ���� �ð�ȭ
    [Header("Ray")]
    [SerializeField]
    private LineRenderer ray;
    [SerializeField]
    private LayerMask hitRayMask;   // �浹�� ���̾�
    [SerializeField]
    private float distance = 100;   // ��Ÿ�

    [Header("Reticle Point")]   // ���� ��
    [SerializeField]
    private GameObject reticlePoint;
    [SerializeField]
    private bool showReticle = true;   // ���̴��� ����

    private void Awake()
    {
        Off();
    }
    public void On()
    {
        StopAllCoroutines();
        StartCoroutine("Process");
    }
    public void Off()
    {
        StopAllCoroutines();

        ray.enabled = false;
        reticlePoint.SetActive(false);
    }
    private IEnumerator Process()
    {
        while (true)
        {
            if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, distance, hitRayMask))   // �浹�� ���̾ ������ hitInfo ������ ���� �� true ��ȯ
            {
                ray.SetPosition(1, transform.InverseTransformPoint(hitInfo.point));   // Ÿ�� ��ġ
                ray.enabled = true;

                reticlePoint.transform.position = hitInfo.point;
                reticlePoint.SetActive(showReticle);
            }
            else   
            {
                // ����, ���� �� ��Ȱ��ȭ
                ray.enabled = false;
                reticlePoint.SetActive(false);
            }

            yield return null;
        }
    }
}
