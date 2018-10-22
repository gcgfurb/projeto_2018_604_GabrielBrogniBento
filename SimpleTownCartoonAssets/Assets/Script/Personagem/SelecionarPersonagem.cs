using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SelecionarPersonagem : NetworkLobbyManager {

    //subclass for sending network messages
    public class NetworkMessage : MessageBase
    {
        public int chosenClass;
    }

    int personagem = 1;

    public GameObject Pedestre;
    public GameObject Caminhao;

    public NetworkStartPosition spawnPedestre;
    public NetworkStartPosition spawnCaminhao;

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId, NetworkReader extraMessageReader)
    {
        NetworkMessage message = extraMessageReader.ReadMessage<NetworkMessage>();
        int selectedClass = message.chosenClass;
        Debug.Log("server add with message " + selectedClass);

        if (selectedClass == 1)
        {
            GameObject player = Instantiate(Pedestre, spawnPedestre.transform);
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }

        if (selectedClass == 2)
        {
            GameObject player = Instantiate(Caminhao, spawnCaminhao.transform);
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        }
    }

    public override void OnClientConnect(NetworkConnection conn)
    {
        NetworkMessage test = new NetworkMessage();
        test.chosenClass = personagem;

        ClientScene.AddPlayer(conn, 0, test);
    }


    public override void OnClientSceneChanged(NetworkConnection conn)
    {
        //base.OnClientSceneChanged(conn);
    }

    public void SelecionaPedestre()
    {
        personagem = 1;
        print("Pedestre");
    }

    public void SelecionaCaminhao()
    {
        personagem = 2;
        print("Caminhao");
    }
}
