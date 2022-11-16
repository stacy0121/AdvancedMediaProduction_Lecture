using UnityEngine;
using UnityEngine.Events;

public class Hittable : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onHit;

    public void Hit()
    {
        // 피격되었을 때 이벤트 메소드 실행
        onHit?.Invoke();
    }
}
