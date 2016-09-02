using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

//namespace Assets.Scripts
//{
public class PlayerShooting : NetworkBehaviour
{
    public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);
    
    public GameObject bulletPrefab;
    int bulletLayer;
    public AudioClip shotSound;

    public float fireDelay = 0.25f;
    float cooldownTimer = 0;


    public float maxSpeed = 5f;


    void Start()
    {
       
        bulletLayer = gameObject.layer;
        transform.Rotate(0, 0, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
       
        cooldownTimer -= Time.deltaTime;
        if (Input.GetButton("Fire1") && cooldownTimer <= 0)
        {
            // SHOOT!
            CmdFire(this.gameObject);
        cooldownTimer = fireDelay;
        }
    }
  

    [Command]
    void CmdFire(GameObject shooter)
    {
        AudioSource source = GetComponent<AudioSource>();
        var tmpVol = source.volume;
        source.volume = 0f;
        source.PlayOneShot(shotSound);
        source.volume = tmpVol;

        Vector3 offset = transform.rotation * bulletOffset;

        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
        bulletGO.GetComponent<Bullet>().shooter = shooter;
        bulletGO.SetActive(true);

        #region addforcesettet
        // bulletGO.transform.Rotate(0, 0, 90);

        //  bulletGO.GetComponent<Rigidbody2D>().AddForce(bulletGO.transform.right * 500f);
        #endregion
        NetworkServer.Spawn(bulletGO);

        Destroy(bulletGO, 3f); //Klonerna av skottet förstörs här
       // bulletGO.layer = bulletLayer;
    }
}
//}
