using UnityEngine;

public class ChangeLinePosition : MonoBehaviour
{
    [SerializeField]
    private int index;
    private LineRenderer target;
    private void Awake()
    {
        target = GetComponent<LineRenderer>();
    }
    public void Call(Vector3 worldPosition)
    {
        // LineRenderer의 index번째 위치를 설정
        if (target.useWorldSpace)
        {
            target.SetPosition(index, worldPosition);   // 타겟 위치
        }
        else
        {
            Vector3 localposition = transform.InverseTransformPoint(worldPosition);
            target.SetPosition(index, localposition);
        }
    }
}
