using UnityEngine;
using System.Collections;

public class GameStatus : MonoBehaviour {

    public int health = 3;
    public int score;
    public string userName = "Player";

    static GameStatus ThisIsTheOneAndOnlyGameStatus;

    public static GameStatus GetInstance()
    {
        return ThisIsTheOneAndOnlyGameStatus;
    }
    // Use this for initialization
    void Start () {


        if (ThisIsTheOneAndOnlyGameStatus != null)
        {
          
            Destroy(this.gameObject);
            return;
        }
        ThisIsTheOneAndOnlyGameStatus = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
	
        //todo onGameEnd serialisera ThisIsTheOneAndOnlyGameStatus och skicka till databas.
	}
    public void AddScore(int insertedScore)
    {
        score += insertedScore;
    }

    public void TakeDmg(int takenDmg)
    {
        health -= takenDmg;
    }

    public void SetUserName(string newUserName)
    {
        userName = newUserName;
    }
    public int GetScore()
    {
        return score;
    }

    public int GetHealth()
    {
        return health;
    }

    public string GetUserName()
    {
        return userName;
    }

    public string SerializeGameStatus()
    {
        return JsonUtility.ToJson(ThisIsTheOneAndOnlyGameStatus);
    }
}
