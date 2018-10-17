using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LataoLixo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("player"))
        {
            PlataformaLixo.qtdLatao += LataLixo.qtdLixo;
            LataLixo.qtdLixo = 0;
            print(PlataformaLixo.qtdLatao);
        }
    }
}
