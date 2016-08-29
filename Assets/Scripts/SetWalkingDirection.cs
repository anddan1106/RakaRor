using UnityEngine;
using System.Collections;

public class SetWalkingDirection : MonoBehaviour
{

    private Animator animator;


    // Use this for initialization
    void Start()
    {
        animator = this.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");
        if(GetComponent<Rigidbody2D>().velocity.magnitude < 0.2)
            animator.SetInteger("Direction", 0);

        else if (horizontal != 0 && vertical == 0)
        {
            animator.SetInteger("Direction", 2);
        }
        else if (vertical != 0)
        {
            animator.SetInteger("Direction", 1);
        }
        else
        {
            animator.SetInteger("Direction", 0);
        }
    }
}


