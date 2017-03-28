using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fondo : MonoBehaviour {
    private Vector3 limiteIzq = new Vector3(4.2f,1,-100);
    private Vector3 limiteDcha = new Vector3(49.3f,1,-100);

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (this.transform.position.x < 4.2f)
        {
            this.transform.position = limiteIzq;
        }else if(this.transform.position.x > 49.3f)
        {
            this.transform.position = limiteDcha;
        }
    }
}
