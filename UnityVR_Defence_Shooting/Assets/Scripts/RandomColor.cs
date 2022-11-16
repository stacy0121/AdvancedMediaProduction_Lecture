using UnityEngine;
using UnityEngine.Events;

public class RandomColor : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<Color> onCreated;
    [SerializeField]
    private float hueMin = 0;
    [SerializeField]
    private float hueMax = 1;   // H
    [SerializeField]
    private float saturationMin = 0.7f;
    [SerializeField]
    private float saturationMax = 1f;   // S
    [SerializeField]
    private float valueMin = 0.7f;
    [SerializeField]
    private float valueMax = 1;   // V

    public void Call()
    {
        Color color = Random.ColorHSV(hueMin, hueMax, saturationMin, saturationMax, valueMin, valueMax);   // 임의의 색상 추출
        onCreated.Invoke(color);
    }
}
