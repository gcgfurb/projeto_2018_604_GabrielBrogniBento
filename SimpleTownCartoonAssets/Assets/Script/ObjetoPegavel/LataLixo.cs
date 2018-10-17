using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LataLixo : MonoBehaviour {

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
            Lixo.SetActive(false);
            qtdLixo++;
            print(qtdLixo);
        }
    }
}
