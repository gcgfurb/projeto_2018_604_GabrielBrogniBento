using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegaLixo : MonoBehaviour {

    private Player player;

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
            player.qtdLixo += 1; 
            print(player.qtdLixo);
        }
    }
}
