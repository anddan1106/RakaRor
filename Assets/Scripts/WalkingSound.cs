using UnityEngine;
using System.Collections;

public class WalkingSound : MonoBehaviour
{


    //public AudioClip walkSound;
    //public AudioClip strafeSound;
    public AudioClip[] sounds;
    private AudioSource walkingSoundSource;

    // Use this for initialization
    void Start()
    {
        walkingSoundSource = GetComponent<AudioSource>();
        walkingSoundSource.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");

        if (!walkingSoundSource.isPlaying)
        {
            if (GetComponent<Rigidbody2D>().velocity.magnitude >= 0.2)
                if (horizontal != 0 && vertical == 0)
                    walkingSoundSource.PlayOneShot(sounds[1]);
                else if (vertical != 0)
                    walkingSoundSource.PlayOneShot(sounds[0]);
        }

    }
}

