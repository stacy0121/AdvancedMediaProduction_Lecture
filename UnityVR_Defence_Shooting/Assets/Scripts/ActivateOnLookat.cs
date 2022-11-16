using UnityEngine;

public class ActivateOnLookat : MonoBehaviour
{
	[SerializeField]
	private	new Camera	camera;
	[SerializeField]
	private	Behaviour	target;   // Canvas - Info
	[SerializeField]
	private	float		thresholdAngle = 30;
	[SerializeField]
	private	float		thresholdDuration = 2;

	private	bool		isLooking = false;
	private	float		showingTime;

	// UI 활성, 비활성화 제어
	private void Awake()
	{
		target.enabled = false;   // 처음에 비활성
	}

	private void Update()
	{
		Vector3 dir		= target.transform.position - camera.transform.position;
		float	angle	= Vector3.Angle(camera.transform.forward, dir);   // 오브젝트 정면과 카메라에서 오브젝트를 바라보는 시점의 각도

        if ( angle <= thresholdAngle )   // 30도 이하면
		{
			if ( !isLooking )
			{
				isLooking = true;   // isLooking true
				showingTime = Time.time + thresholdDuration;   // 카운트 시작
			}
			else   // true가 된 isLooking
			{
				if ( !target.enabled && Time.time >= showingTime )   // 비활성이고 2초 이상 지나면
				{
					target.enabled = true;   // 활성화
				}
			}
		}
        else   // 30도 초과이면 UI 끄기
        {
			if ( isLooking )
			{
				isLooking = false;
				target.enabled = false;
			}
		}
	}
}

