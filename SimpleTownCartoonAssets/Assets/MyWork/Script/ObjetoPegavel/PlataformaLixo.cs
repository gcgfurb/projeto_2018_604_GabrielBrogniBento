using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaLixo : MonoBehaviour {

    public static float qtdLatao = 3;

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
            print(qtdLatao);
            LixoCaminhao.qtd += qtdLatao;
            qtdLatao = 0;
            print(qtdLatao);
            print(LixoCaminhao.qtd);
        }
    }
}
