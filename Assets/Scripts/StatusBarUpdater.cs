using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class StatusBarUpdater : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = GameStatus.GetInstance().GetUserName() +":  " +"Score:" + GameStatus.GetInstance().GetScore() + "  Lives:" + GameStatus.GetInstance().GetHealth();
    }
}
