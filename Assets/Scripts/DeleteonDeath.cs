using UnityEngine;
using System.Collections;

public class DeleteonDeath : MonoBehaviour {

	public static bool die;

	void Start () {
		die = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(die)
		{
			ElectronBullet[] others = FindObjectsOfType(typeof(ElectronBullet)) as ElectronBullet[];
			
			foreach(ElectronBullet other in others)
			{
				if(other.transform.gameObject.name == "ElectronBullet(Clone)")
				{
					Destroy(other.gameObject);
				}
			}

			ProtonBullet[] otherss = FindObjectsOfType(typeof(ProtonBullet)) as ProtonBullet[];
			
			foreach(ProtonBullet other in otherss)
			{
				if(other.transform.gameObject.name == "ProtonBullet(Clone)")
				{
					Destroy(other.gameObject);
				}
			}

			NeutralBullet[] otherz = FindObjectsOfType(typeof(NeutralBullet)) as NeutralBullet[];
			
			foreach(NeutralBullet other in otherz)
			{
				if(other.transform.gameObject.name == "NeutralBullet(Clone)")
				{
					Destroy(other.gameObject);
				}
			}
			die = false;
		}
	}
}
