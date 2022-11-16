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
        // ȣ�� �ֺ��� �����Ǵ� ��ƼŬ�� ���� ���� ����
        ParticleSystem.MainModule module = target.main;   // �⺻ ��ƼŬ ����
        module.startColor = new ParticleSystem.MinMaxGradient(color, color * Random.Range(1 - arrangeRange, 1 + arrangeRange));
    }
}
