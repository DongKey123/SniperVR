using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHitCol : HitObject {

    Boss boss;

	// Use this for initialization
	void Start () {
        boss = this.GetComponentInParent<Boss>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Hit(Vector3 hitPosition, float distance)
    {
        base.Hit(hitPosition, distance);

        Debug.Log("Sibal");

        //Collider 중지
        this.GetComponent<Collider>().enabled = false;


        boss.Hit();
        this.gameObject.SetActive(false);
    }
}
