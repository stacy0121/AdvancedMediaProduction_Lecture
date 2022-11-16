using UnityEngine;
//using UnityEngine.AI;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onCreated;
    [SerializeField]
    private UnityEvent onDestroyed;

    //[SerializeField]
    //private float hueMin = 0;
    //[SerializeField]
    //private float hueMax = 1;   // H
    //[SerializeField]
    //private float saturationMin = 0.7f;
    //[SerializeField]
    //private float saturationMax = 1f;   // S
    //[SerializeField]
    //private float valueMin = 0.7f;
    //[SerializeField]
    //private float valueMax = 1;   // V
    //[SerializeField]
    //private float arrangeRange = 0.5f;
    //[SerializeField]
    //private float emissionIntensity = 5;   // 광원의 세기
    //[SerializeField]
    //private ParticleSystem environmentParticle;
    //[SerializeField]
    //private MeshRenderer holeMeshRenderer;

    //[SerializeField]
    //private ParticleSystem destroyParticle;
    //[SerializeField]
    //private AudioSource destroyAudio;
    //[SerializeField]
    //private GameObject modelGameObject;
    [SerializeField]
    private float destroyDelay = 1;
    private bool isDestroyed = false;

    //private NavMeshAgent navMeshAgent;

    //private void Awake()
    private void Start()
    {
        //navMeshAgent = GetComponent<NavMeshAgent>();

        //navMeshAgent.SetDestination(new Vector3(0, 2, 1));   // 목표 지점
        //navMeshAgent.speed *= Random.Range(0.8f, 1.5f);   // 적마다 이동 속도 다름

        //RandomColor();   // 임의의 색상 적용 = 호박마다 색상이 다름

        // Debug. 테스트용 코드
        //Invoke("Destroy", Random.Range(1, 6));   // 일정 시간(1~5초) 후 호출(알아서 죽음)

        onCreated?.Invoke();

        EnemyManager.Instance.OnSpawn(this);   // 적이 생성
    }

    //private void RandomColor()
    //{
    //    // 기본 색상이 아닌 EmissionColor를 바꾸기 때문에 material.color가 아닌 SetColor() 사용
    //    Color color = Random.ColorHSV(hueMin, hueMax, saturationMin, saturationMax, valueMin, valueMax);   // 임의의 색상 추출

    //    // 호박 주변에 생성되는 파티클의 시작 색상 설정
    //    ParticleSystem.MainModule module = environmentParticle.main;   // 기본 파티클 설정
    //    module.startColor = new ParticleSystem.MinMaxGradient(color, color * Random.Range(1 - arrangeRange, 1 + arrangeRange));
    //    // 호박 주변에 생성되는 파티클 이펙트의 Material-EmissionColor 색상
    //    environmentParticle.GetComponent<ParticleSystemRenderer>().material.SetColor("_EmissionColor", color * emissionIntensity);
    //    // 호박 얼굴에서 뚫린 부분(눈, 입 등)의 Material-EmissionColor 색상
    //    holeMeshRenderer.material.SetColor("_EmissionColor", color * emissionIntensity);

    //    // 호박이 사망할 때 생성되는 파티클의 시작 색상
    //    module = destroyParticle.main;
    //    module.startColor = new ParticleSystem.MinMaxGradient(color, color * Random.Range(1 - arrangeRange, 1 + arrangeRange));
    //    // 호박이 사망할 때 생성되는 파티클의 Material-EmissionColor 색상
    //    destroyParticle.GetComponent<ParticleSystemRenderer>().material.SetColor("_EmissionColor", color * emissionIntensity);
    //}

    public void Destroy()
    {
        if (isDestroyed) return;   // true면 메소드 탈출

        isDestroyed = true;   // 죽음

        // 죽을 때 이펙트, 오디오 재생 -> UnityEvent로 대체
        //destroyParticle.Play();
        //destroyAudio.Play();

        //environmentParticle.Stop();   // 이펙트 정지
        //navMeshAgent.enabled = false;   // 이동 정지
        //modelGameObject.SetActive(false);   // 안 보이게

        Destroy(gameObject, destroyDelay);   // 1초 뒤에 오브젝트 삭제

        onDestroyed?.Invoke();

        EnemyManager.Instance.OnDestroyed(this);   // 적 제거
    }
}
