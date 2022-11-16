using UnityEngine;
using UnityEngine.Events;

public class Hittable : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onHit;

    public void Hit()
    {
        // �ǰݵǾ��� �� �̺�Ʈ �޼ҵ� ����
        onHit?.Invoke();
    }
}
