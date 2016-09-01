using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System;

public class NetWorkingShooting : NetworkBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawn;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer)
        {
            return;
        }
        if (Input.GetButton("Fire1"))
        {
            CmdFire();
        }

    }

    [Command]
    void CmdFire()
    {
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        bullet.GetComponent<Rigidbody2D>().angularVelocity = 0;
        bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.forward * 6.0f);

        NetworkServer.Spawn(bullet);

        Destroy(bullet,3);
    }
}
