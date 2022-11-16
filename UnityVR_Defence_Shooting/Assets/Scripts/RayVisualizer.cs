using System.Collections;
using UnityEngine;

public class RayVisualizer : MonoBehaviour
{
    // 광선 시각화
    [Header("Ray")]
    [SerializeField]
    private LineRenderer ray;
    [SerializeField]
    private LayerMask hitRayMask;   // 충돌한 레이어
    [SerializeField]
    private float distance = 100;   // 사거리

    [Header("Reticle Point")]   // 빨간 점
    [SerializeField]
    private GameObject reticlePoint;
    [SerializeField]
    private bool showReticle = true;   // 보이는지 여부

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
            if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, distance, hitRayMask))   // 충돌한 레이어가 있으면 hitInfo 변수에 저장 및 true 반환
            {
                ray.SetPosition(1, transform.InverseTransformPoint(hitInfo.point));   // 타겟 위치
                ray.enabled = true;

                reticlePoint.transform.position = hitInfo.point;
                reticlePoint.SetActive(showReticle);
            }
            else   
            {
                // 광선, 빨간 점 비활성화
                ray.enabled = false;
                reticlePoint.SetActive(false);
            }

            yield return null;
        }
    }
}
