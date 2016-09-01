using UnityEngine;
using System.Collections;
using System.IO;


public class SerializeGameStatus : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            StartCoroutine(GameStatusSenderController.PostScores(GameStatus.GetInstance().GetUserName(), GameStatus.GetInstance().GetScore()));
           
        }
    }
}
