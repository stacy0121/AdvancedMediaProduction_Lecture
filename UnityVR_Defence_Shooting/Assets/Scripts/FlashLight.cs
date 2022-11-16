using System.Collections;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField]
    private float duration = 0.05f;
    private Light target;

    private void Awake()
    {
        target = GetComponent<Light>();
    }
    public void Call()
    {
        StopAllCoroutines();
        StartCoroutine("Process");
    }
    private IEnumerator Process()
    {
        // ���� ��� Ȱ��-��Ȱ��ȭ
        target.enabled = true;
        yield return new WaitForSeconds(duration);   // 0.05�ʸ���
        target.enabled = false;
    }
}
