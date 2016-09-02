using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{

    public float rotationSpeed = 90f;
    public Transform player;
    public float speed;

    void Start()
    {
        //Fienden hittar spelaren
        
    }
    bool findPlayer()
    {
        var players = GameObject.FindGameObjectsWithTag("Player");
        GameObject go = null;
        if (players.Length>0)
            go = players[Random.Range(0, players.Length)];

        if (go != null)
        {
            player = go.transform;
        }
        return player != null;
    }


    void Update()
    {

        if (player == null)
        {
            if(!findPlayer())
                return;
        }

        Vector3 dir = player.position - transform.position;
        dir.Normalize();
        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

        Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotationSpeed * Time.deltaTime);
    }
    void FixedUpdate()
    {
        if (player == null)
        {
            if (!findPlayer())
                return;
        }

        float z = Mathf.Atan2((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;

        transform.eulerAngles = new Vector3(0, 0, z);

        GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * speed);
    }
}
