using UnityEngine;
using System.Collections;

public class PlayerMobility : MonoBehaviour {

    public float speed;
    Animator anim;
    public Camera cam;

    void Start()
    {
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        //Input.GetKey(KeyCode.Space);

        //if (Input.GetMouseButtonDown(0))
        //{
        //    anim.SetTrigger("Attack");
        //}
    }

    void FixedUpdate()
    {


        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);
        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);

        var player = GetComponent<Rigidbody2D>();
        player.angularVelocity = 0;

        float input = Input.GetAxis("Vertical");
        player.AddForce(gameObject.transform.up * speed * input);
        float strafeInput = Input.GetAxis("Horizontal");
        player.AddForce(gameObject.transform.right * speed * strafeInput);

        cam.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, cam.transform.position.z);

        //if (obj.velocity.magnitude <= 0)
        //    anim.enabled = false;
        //else
        //    anim.enabled = true;
    }
}
