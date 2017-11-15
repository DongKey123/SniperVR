using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : MonoBehaviour {

    public OculusInputManger m_Input;
    public Camera m_ScopeCamera;
    public float m_ZoomSpeed = 2f;
    public Transform m_Muzzle;
    public Transform m_LookAtTR;

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
        m_ShootAudio.Play();
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
    }

    void ZoomOut()
    {
        m_ScopeCamera.fieldOfView += Time.deltaTime * m_ZoomSpeed;
    }
}
