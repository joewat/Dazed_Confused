using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 

public class PlayerRespawn : MonoBehaviour { 

	public float respawnX, respawnY;

	public void Respawn() {
		transform.position = new Vector3 (respawnX, respawnY, 0);
		this.GetComponent<PlayerMovement> ().StartInvincible (3);
	}
}