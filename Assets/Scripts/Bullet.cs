using UnityEngine;
using System.Collections;


class Bullet : MonoBehaviour
{
    private int dmg = 1;
    public GameObject shooter;
    void Start()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject hit = collision.gameObject;


        if (collision.gameObject.tag == "Player")
        {
            hit.GetComponent<Health>().TakeDamage(dmg);
            SetupLocalPlayer player = null;
            if(shooter != null)
                player = shooter.GetComponent<SetupLocalPlayer>();
            if (player != null)
                player.RpcAddScore(dmg);

            Debug.Log("Du är skjuten collision");
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            hit.GetComponent<EnemyHealth>().TakeDamage(dmg);
            SetupLocalPlayer player = null;
            if (shooter != null)
                player = shooter.GetComponent<SetupLocalPlayer>();
            if (player != null)
            {
                player.RpcAddScore(dmg);
                Debug.Log(player.score + " : " + dmg);
            }


            Debug.Log("Enemy skjuten collision");

        }
        Destroy(this.gameObject);
    }


}

