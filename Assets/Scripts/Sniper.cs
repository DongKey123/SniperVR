using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sniper : MonoBehaviour
{
    public float m_MinFOV = 0.001f;
    public float m_MaxFOV = 60f;

    public OculusInputManger m_Input;
    public Camera m_ScopeCamera;
    public float m_ZoomSpeed = 2f;
    public Transform m_Muzzle;
    public Transform m_LookAtTR;

    public float m_ReboundPower = 2f;

    private bool IsAtkDelaying = false;
    public float m_AtkDelayTime = 2.5f;

    public int m_maxBullets = 10;
    public int m_curBullets = 10;
    public float m_ReloadTime = 5f;
    public AudioSource m_ReloadAudio;
    public bool m_ReloadAudioCk = true;
    public AudioSource m_ShootAudio;

	[SerializeField]
	private ParticleSystem _nuzzleParticle;

	[SerializeField]
	private Text _bulletAmountText;

	private bool active = true;

    void OnEnable()
    {
        m_Input.Shoot += this.Shoot;
        m_Input.Reload += this.Reload;
        m_Input.ZoomIn += this.ZoomIn;
        m_Input.ZoomOut += this.ZoomOut;
    }

    void OnDisable()
    {
		active = false;
		StopAllCoroutines();
		CancelInvoke();
    }

	// Use this for initialization
	void Start () {
		_bulletAmountText.text = m_curBullets.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.LookAt(m_LookAtTR);
        Debug.DrawRay(m_Muzzle.position, m_Muzzle.forward*1000f,Color.red);
	}

    void Shoot()
    {
		if ( !active )
			return;

        if (IsAtkDelaying)
            return;

        if (m_curBullets <= 0)
            return;
        

        m_Input.hapticsController.Vibrate(VibrationForce.Hard, OVRTouch.Left);
        m_Input.hapticsController.Vibrate(VibrationForce.Hard, OVRTouch.Right);

        IsAtkDelaying = true;
        Invoke("ChangeAtkDelay", m_AtkDelayTime);
        m_ShootAudio.Play();
        m_curBullets--;
		_bulletAmountText.text = m_curBullets.ToString();
		_bulletAmountText.color = GetBulletColor();

		if (m_curBullets <= 0)
        {
            Invoke("Reload", m_AtkDelayTime);
        }

		_nuzzleParticle.Clear();
		_nuzzleParticle.Play();

		RaycastHit hit;
		StartCoroutine(ReBound());
        if (Physics.Raycast(m_Muzzle.position, m_Muzzle.forward,out hit))
        {
            Debug.Log(hit.transform.name);
			if ( hit.transform.tag == "HitObj" )
			{
				HitObject hitobj = hit.transform.GetComponent<HitObject>();
				Debug.Log( hitobj );
				hitobj.Hit( hit.point, Vector3.Distance( hitobj.transform.position, this.transform.position ) );
			}
			else
			{
				//지형지물 이펙트 처리
				ImpactParticleManager.Instance.PlayParticle( hit.point, m_Muzzle.forward * -1, hit.collider.gameObject.layer );
			}
        }
    }

    void ZoomIn()
    {
        m_ScopeCamera.fieldOfView *= 0.5f;
        m_ScopeCamera.fieldOfView = Mathf.Clamp(m_ScopeCamera.fieldOfView, m_MinFOV, m_MaxFOV);
    }

    void ZoomOut()
    {
        m_ScopeCamera.fieldOfView *= 2f;
        m_ScopeCamera.fieldOfView = Mathf.Clamp(m_ScopeCamera.fieldOfView, m_MinFOV, m_MaxFOV);
    }

    void ChangeAtkDelay()
    {
        IsAtkDelaying = false;
    }

    void Reload()
    {
        IsAtkDelaying = true;
        m_ReloadAudio.Play();
        Invoke("ChangeBullet", m_ReloadTime);
    }

    void ChangeBullet()
    {
        IsAtkDelaying = false;
        m_curBullets = m_maxBullets;
		_bulletAmountText.text = m_curBullets.ToString();
		_bulletAmountText.color = GetBulletColor();
	}

    IEnumerator ReBound()
    {
        float time = 0;
        Vector3 origin = this.transform.position;
        //while(true)
        //{
        //    time += Time.deltaTime;
        //    this.transform.position += -this.transform.forward * m_ReboundPower * Time.deltaTime;
        //    if(time > 0.5f)
        //    {
        //        time = 0;
        //        break;
        //    }
        //    yield return null;
        //}
        this.transform.position += -this.transform.forward * m_ReboundPower;

        while (true)
        {
            time += Time.deltaTime;
            this.transform.position += this.transform.forward * m_ReboundPower * Time.deltaTime;
            if (time > 0.5f)
            {
                time = 0;
                this.transform.position = origin;
                break;
            }
            yield return null;
        }
    }

	Color GetBulletColor()
	{
		Color ret = Color.white;
		float ratio = m_curBullets / (float)m_maxBullets;
		if ( ratio <= 0.3f )
		{
			ret = Color.red;
		}
		else if ( ratio <= 0.6f )
		{
			ret = Color.yellow;
		}

		return ret;
	}
}
