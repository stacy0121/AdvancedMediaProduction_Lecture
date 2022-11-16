using UnityEngine;

public class ChangeVFXColor : MonoBehaviour
{
    [SerializeField]
    private float arrangeRange = 0.5f;
    private ParticleSystem target;

    private void Awake()
    {
        target = GetComponent<ParticleSystem>();
    }

    public void Call(Color color)
    {
        // 호박 주변에 생성되는 파티클의 시작 색상 설정
        ParticleSystem.MainModule module = target.main;   // 기본 파티클 설정
        module.startColor = new ParticleSystem.MinMaxGradient(color, color * Random.Range(1 - arrangeRange, 1 + arrangeRange));
    }
}
