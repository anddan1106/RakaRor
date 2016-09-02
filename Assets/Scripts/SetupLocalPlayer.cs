using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System;

public class SetupLocalPlayer : NetworkBehaviour
{

    [SyncVar]
    public int score;
    [SyncVar]
    public string playerName = "Player";
    public int spawns;
    public bool scoringPlayer;

    void OnGUI()
    {
        if (isLocalPlayer)
        {
            playerName = GUI.TextField(new Rect(0, Screen.height - 40, 50, 30), playerName);
            if (GUI.Button(new Rect(130, Screen.height - 40, 80, 30), "Apply"))
            {
                //ChangeName(playerName);
                CmdChangeName(playerName);
                Debug.Log("New nme : " + playerName);

            }

        }
    }

    [Command]
    private void CmdChangeName(string newName)
    {
        playerName = newName;
        Debug.Log(playerName + score);
    }


    private void ChangeName(string newName)
    {
        playerName = newName;
        Debug.Log(playerName + score);
    }

    // Use this for initialization
    void Start()
    {
        spawns = 3;
        score = 0;

        if (isLocalPlayer)
        {
            GetComponent<PlayerMobility>().enabled = true;
            GetComponent<PlayerShooting>().enabled = true;
            scoringPlayer = true;
            //GetComponent<PlayerStats>().enabled = true;
            //GetComponent<PlayerStats>().scoringPlayer = true;
            //GetComponent<DamageHandler>().enabled = true;
        }

    }
    [ClientRpc]
    public void RpcAddScore(int scoreToAdd)
    {
        score += scoreToAdd;
    }

    //[Command]
    //public void CmdAddScore(int scoreToAdd)
    //{
    //    score += scoreToAdd;
    //}
    public bool SpawnsLeft()
    {
        return --spawns >= 0;
    }
    public void SendScoreToDb()
    {
        StartCoroutine(GameStatusSenderController.PostScores(playerName, score));
    }


}
