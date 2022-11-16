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
        // LineRenderer�� index��° ��ġ�� ����
        if (target.useWorldSpace)
        {
            target.SetPosition(index, worldPosition);   // Ÿ�� ��ġ
        }
        else
        {
            Vector3 localposition = transform.InverseTransformPoint(worldPosition);
            target.SetPosition(index, localposition);
        }
    }
}
