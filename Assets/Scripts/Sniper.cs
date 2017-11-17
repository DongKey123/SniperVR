using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : MonoBehaviour {

    public float m_MinFOV = 0.001f;
    public float m_MaxFOV = 60f;

    public OculusInputManger m_Input;
    public Camera m_ScopeCamera;
    public float m_ZoomSpeed = 2f;
    public Transform m_Muzzle;
    public Transform m_LookAtTR;

    private bool IsAtkDelaying = false;
    public float m_AtkDelayTime = 2.5f;

    public int m_maxBullets = 10;
    public int m_curBullets = 10;
    public float m_ReloadTime = 5f;
    public AudioSource m_ReloadAudio;
    public bool m_ReloadAudioCk = true;
    public AudioSource m_ShootAudio;

    void OnEnable()
    {
        m_Input.Shoot += this.Shoot;
        m_Input.ZoomIn += this.ZoomIn;
        m_Input.ZoomOut += this.ZoomOut;
    }

    void OnDisable()
    {

    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.LookAt(m_LookAtTR);
        Debug.DrawRay(m_Muzzle.position, m_Muzzle.forward*1000f,Color.red);
	}

    void Shoot()
    {
        if (IsAtkDelaying)
            return;

        if (m_curBullets <= 0)
            return;
        

        IsAtkDelaying = true;
        Invoke("ChangeAtkDelay", m_AtkDelayTime);
        m_ShootAudio.Play();
        m_curBullets--;
        if(m_curBullets <= 0)
        {
            Invoke("Reload", m_AtkDelayTime);
        }
        RaycastHit hit;
        if(Physics.Raycast(m_Muzzle.position, m_Muzzle.forward,out hit))
        {
            Debug.Log(hit.transform.name);
            if(hit.transform.tag == "HitObj")
            {
                HitObject hitobj = hit.transform.GetComponent<HitObject>();
                hitobj.Hit();
            }
        }
    }

    void ZoomIn()
    {
        m_ScopeCamera.fieldOfView -= Time.deltaTime * m_ZoomSpeed;
        Mathf.Clamp(m_ScopeCamera.fieldOfView, m_MinFOV, m_MaxFOV);
    }

    void ZoomOut()
    {
        m_ScopeCamera.fieldOfView += Time.deltaTime * m_ZoomSpeed;
        Mathf.Clamp(m_ScopeCamera.fieldOfView, m_MinFOV, m_MaxFOV);
    }

    void ChangeAtkDelay()
    {
        IsAtkDelaying = false;
    }

    void Reload()
    {
        m_ReloadAudio.Play();
        Invoke("ChangeBullet", m_ReloadTime);
    }

    void ChangeBullet()
    {
        m_curBullets = m_maxBullets;
    }
}
