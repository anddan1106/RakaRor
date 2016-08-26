using UnityEngine;
using System.Collections;

public class WalkingSound : MonoBehaviour
{


    //public AudioClip walkSound;
    //public AudioClip strafeSound;
    public AudioClip[] sounds;
    public GameObject AudioSource;
    private AudioSource walkingSource;

    // Use this for initialization
    void Start()
    {
        walkingSource = AudioSource.GetComponent<AudioSource>();
        walkingSource.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {

        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");

        if (horizontal != 0 && vertical == 0)
        {
            if (!walkingSource.isPlaying)
                walkingSource.PlayOneShot(sounds[1]);
        }
        else if (vertical != 0)
        {
            if (!walkingSource.isPlaying)
                walkingSource.PlayOneShot(sounds[0]);
        }
    }
}
