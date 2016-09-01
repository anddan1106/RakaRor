using UnityEngine;
using System.Collections;

public class GameStatusSenderController : MonoBehaviour {

    private static string secretKey = "mySecretKey"; // Edit this value and make sure it's the same as the one stored on the server
    public static string addScoreURL = "http://www.lordj.se/addscore.php?"; //be sure to add a ? to your url
    public static string highscoreURL = "http://lordj.se/display.php";

    //static GameStatusSenderController ThisIsTheOneAndOnlyGameStatusSenderController;

   //static public GameStatusSenderController getInstance()
   // {
   //     return ThisIsTheOneAndOnlyGameStatusSenderController;
   // }
    void Start()
    {
        //if (ThisIsTheOneAndOnlyGameStatusSenderController != null)
        //{

        //    Destroy(this.gameObject);
        //    return;
        //}
        //ThisIsTheOneAndOnlyGameStatusSenderController = this;
        //GameObject.DontDestroyOnLoad(this.gameObject);
       // StartCoroutine(GetScores());
    }

    // remember to use StartCoroutine when calling this function!
   public static IEnumerator PostScores(string userName, int score)
    {
        Debug.Log(userName + " and " + score + " : posting");

        //This connects to a server side php script that will add the name and score to a MySQL DB.
        // Supply it with a string representing the players name and the players score.

        string hash = Md5Sum(userName + score + secretKey);

        string post_url = addScoreURL + "name=" + WWW.EscapeURL(userName) + "&score=" + score + "&hash=" + hash;

        Debug.Log(post_url);
        // Post the URL to the site and create a download object to get the result.
        WWW hs_post = new WWW(post_url);
        yield return hs_post; // Wait until the download is done

        if (hs_post.error != null)
        {
            print("There was an error posting the high score: " + hs_post.error);
        }
    }

    private static string Md5Sum(string strToEncrypt)
    {
        System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
        byte[] bytes = ue.GetBytes(strToEncrypt);

        // encrypt bytes
        System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] hashBytes = md5.ComputeHash(bytes);

        // Convert the encrypted bytes back to a string (base 16)
        string hashString = "";

        for (int i = 0; i < hashBytes.Length; i++)
        {
            hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
        }

        return hashString.PadLeft(32, '0');
    }


    // Get the scores from the MySQL DB to display in a GUIText.
    // remember to use StartCoroutine when calling this function!
    IEnumerator GetScores()
    {
        gameObject.GetComponent<GUIText>().text = "Loading Scores";
        WWW hs_get = new WWW(highscoreURL);
        yield return hs_get;

        if (hs_get.error != null)
        {
            print("There was an error getting the high score: " + hs_get.error);
        }
        else
        {
            gameObject.GetComponent<GUIText>().text = hs_get.text; // this is a GUIText that will display the scores in game.
        }
    }
}
