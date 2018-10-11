using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkStart : NetworkBehaviour {

    [SerializeField] ToggleEvent onToggleShared;
    [SerializeField] ToggleEvent onToggleLocal;
    [SerializeField] ToggleEvent onToggleRemote;

    GameObject mainCamera;

    // Use this for initialization
    void Start () {
        mainCamera = Camera.main.gameObject;

        habilitarJogador();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void habilitarJogador()
    {
        if (isLocalPlayer)
            mainCamera.SetActive(false);

        onToggleShared.Invoke(true);

        if (isLocalPlayer)
            onToggleLocal.Invoke(true);
        else
            onToggleRemote.Invoke(true);
    }

    void deshabilitarJogador()
    {
        if (isLocalPlayer)
            mainCamera.SetActive(true);

        onToggleShared.Invoke(false);

        if (isLocalPlayer)
            onToggleLocal.Invoke(false);
        else
            onToggleRemote.Invoke(false);
    }
}
