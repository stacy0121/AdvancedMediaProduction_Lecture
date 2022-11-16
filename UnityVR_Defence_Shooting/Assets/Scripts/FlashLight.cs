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
        // 빛을 잠깐 활성-비활성화
        target.enabled = true;
        yield return new WaitForSeconds(duration);   // 0.05초마다
        target.enabled = false;
    }
}
