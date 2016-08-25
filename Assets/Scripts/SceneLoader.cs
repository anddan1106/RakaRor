using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public string sceneName;

    void OnTriggerEnter2D()
    {
        StartCoroutine(ChangeLevel());
    }

    IEnumerator ChangeLevel()
    {
        float fadeSpeed = GameObject.Find("sceneChange").GetComponent<FadeSettings>().BeginFade(1);
        yield return new WaitForSeconds(fadeSpeed);
        SceneManager.LoadScene(sceneName);


    }
}
