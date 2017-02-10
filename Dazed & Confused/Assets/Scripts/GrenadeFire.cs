using UnityEngine;
using System.Collections;

public class GrenadeFire : MonoBehaviour
{

    public GameObject grenade;
    public Transform bulletSpawn;
    public float fireRate;

    private float nextFire;

    void Update()
    {
        // Fire on button press.
		if (Input.GetButton (this.GetComponent<PlayerControls> ().grenade) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(grenade, bulletSpawn.position, bulletSpawn.rotation);
        }
    }
}
