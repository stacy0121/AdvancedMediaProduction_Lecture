using UnityEngine;

public class ChangeEmissionColor : MonoBehaviour
{
    [SerializeField]
    private float intensity = 5;
    private Renderer target;

    private void Awake()
    {
        target = GetComponent<Renderer>();
    }

    public void Call(Color color)
    {
        // ȣ�� �󱼿��� �ո� �κ�(��, �� ��)�� Material-EmissionColor ����
        target.material.SetColor("_EmissionColor", color * intensity);
    }
}
