using UnityEngine;
using System.Collections;

public class BulletSpawn : MonoBehaviour {

	public Transform camera;
	private BulletLinearShooter temp;

	// Update is called once per frame
	void Update () {
		temp = GetComponent<BulletLinearShooter>();
		if(transform.position.y >= camera.transform.position.y+80 || transform.position.y <= camera.transform.position.y+50)
		{
			temp.enabled = false;
		}
		else
		{
			temp.enabled = true;
		}
	}
}
