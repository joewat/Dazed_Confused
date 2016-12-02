using UnityEngine;
using System.Collections;

public class aoeFire : MonoBehaviour
{

    public GameObject aoebullet;
    public Transform bulletSpawn;
    public float fireRate;

    private float nextFire;

    void Update()
    {
        // Fire on button press.
		if (Input.GetButton (this.GetComponent<PlayerControls> ().grenade) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(aoebullet, bulletSpawn.position, bulletSpawn.rotation);
        }
    }
}
