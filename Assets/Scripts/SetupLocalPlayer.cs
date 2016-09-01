using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System;

public class SetupLocalPlayer : NetworkBehaviour {

    [SyncVar]
    string playerName = "Playername";

    void OnGUI()
    {
        playerName = GUI.TextField(new Rect(0, Screen.height - 40, 50, 30), playerName);
        if (GUI.Button(new Rect(130,Screen.height-40,80,30),"Apply"))
        {
            CmdChangeName(playerName);
        }
    }

    [Command]
    private void CmdChangeName(string newName)
    {
        playerName = newName;
    }

    // Use this for initialization
    void Start () {

        if (isLocalPlayer)
        {
            GetComponent<PlayerMobility>().enabled = true;
            GetComponent<PlayerShooting>().enabled = true;
           // GetComponent<DamageHandler>().enabled = true;
        }

    }
    void Update()
    {
        if (isLocalPlayer)
        {
            GameStatus.GetInstance().SetUserName(playerName);
        }
    }

	
}
