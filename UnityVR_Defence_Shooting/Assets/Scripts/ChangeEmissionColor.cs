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
        // 호박 얼굴에서 뚫린 부분(눈, 입 등)의 Material-EmissionColor 색상
        target.material.SetColor("_EmissionColor", color * intensity);
    }
}
