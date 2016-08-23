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

        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Attack");
        }
    }

    void FixedUpdate()
    {


        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);
        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
        GetComponent<Rigidbody2D>().angularVelocity = 0;

        float input = Input.GetAxis("Vertical");
        GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * speed * input);
        var obj = GetComponent<Rigidbody2D>();
        cam.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, cam.transform.position.z);
    }
}
