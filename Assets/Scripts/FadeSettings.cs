using UnityEngine;
using System.Collections;

public class FadeSettings : MonoBehaviour {

    public Texture2D fadeOutTexture; //Texturen som kommer att visas. Typ loading screen eller svart.
    public float fadeSpeed = 0.8f;  //Fade hastighet

    private int drawDepth = -10000;  //Draw order. Lägst nummer ritas sist (dvs ovanpå).
    private float alpha = 1.0f;     //Texturens alfa värde, mellan 0 - 1. 
    private int fadeDirection = -1; //Avgör om scenen fadar in eller ut. fade in= -1. Fade out = 1;


    void OnGUI()
    {
        //fade out/in the alpha value using a direction, a speed and Time.deltatime to convert the operation to seconds.
        alpha += fadeDirection * fadeSpeed * Time.deltaTime;

        //force (clamp) the value to be between 0 & 1. För att GUI.color använder alfa värden mellan 0 och 1.
        alpha = Mathf.Clamp01(alpha);

        //Set color of GUI (vår textur). All color values remain the same & the alpha is set to the alpha variable.
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);       //set the alpha value.
        GUI.depth = drawDepth;                                                  //make the black texture render on top(drawn last).
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);   //Draw the texture to fit the entire screen area.

    }

    //sets fadeDirection to the direction parameter making the scene fade in if -1 and out if 1.
    public float BeginFade(int direction)
    {
        fadeDirection = direction;
        return (1 / fadeSpeed);                 //return the fadespeed variable so it's easy to time the Application.LoadLevel();
    }

    //OnLevelWasLoaded is called when a level is loaded. It takes loaded level index (int) as a parameter so you can limit the fade in to certain scenes.
    void OnLevelWasLoaded()
    {
        //Alpha =1;     //use this if the alpha is not set to 1 by default.
        BeginFade(-1);  //Call the fade in function. 
    }
}
