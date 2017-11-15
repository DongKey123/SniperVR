using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitObject : MonoBehaviour {

    

    void Awake()
    {
        this.transform.tag = "HitObj";
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void Hit()
    {
        Debug.Log("Hit Object");
    }

}
