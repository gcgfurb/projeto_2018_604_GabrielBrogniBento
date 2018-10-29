using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LataLixo : NetworkBehaviour {

    public static float qtdLixo;

    public GameObject Lixo;

    [SerializeField] ToggleEvent desativaMash;

    // Use this for initialization
    void Start () {
        desativaMash.Invoke(true);
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("player"))
        {
            RpcDesativaMesh();
        }
    }

    [ClientRpc]
    void RpcDesativaMesh()
    {
        Lixo.SetActive(false);
        qtdLixo++;
        print(qtdLixo);
    }
}
