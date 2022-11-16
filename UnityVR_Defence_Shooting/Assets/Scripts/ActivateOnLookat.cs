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

	// UI Ȱ��, ��Ȱ��ȭ ����
	private void Awake()
	{
		target.enabled = false;   // ó���� ��Ȱ��
	}

	private void Update()
	{
		Vector3 dir		= target.transform.position - camera.transform.position;
		float	angle	= Vector3.Angle(camera.transform.forward, dir);   // ������Ʈ ����� ī�޶󿡼� ������Ʈ�� �ٶ󺸴� ������ ����

        if ( angle <= thresholdAngle )   // 30�� ���ϸ�
		{
			if ( !isLooking )
			{
				isLooking = true;   // isLooking true
				showingTime = Time.time + thresholdDuration;   // ī��Ʈ ����
			}
			else   // true�� �� isLooking
			{
				if ( !target.enabled && Time.time >= showingTime )   // ��Ȱ���̰� 2�� �̻� ������
				{
					target.enabled = true;   // Ȱ��ȭ
				}
			}
		}
        else   // 30�� �ʰ��̸� UI ����
        {
			if ( isLooking )
			{
				isLooking = false;
				target.enabled = false;
			}
		}
	}
}

