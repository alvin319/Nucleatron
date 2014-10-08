using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	public Transform wall;
	public bool spawn_despawn;
	public bool pressed;
	public bool proton_electron;
	public static bool reset;
	public Sprite unpress;
	public Sprite press;
	public AudioClip ButtonEffect;
	private SpriteRenderer myRenderer;

	// Use this for initialization
	void Start () {
		myRenderer = gameObject.GetComponent<SpriteRenderer>();
		reset = false;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (reset);
		if(pressed)
		{
			wall.renderer.enabled = spawn_despawn;
			wall.collider2D.enabled = spawn_despawn;
			myRenderer.sprite = press;
		}
		else if(!pressed)
		{
			wall.renderer.enabled = !spawn_despawn;
			wall.collider2D.enabled = !spawn_despawn;
			myRenderer.sprite = unpress;
		}
		if(reset)
		{
			//pressed = false;
			//Debug.Log("jkladsfj");
			resett();
		}
	}

	void pushed()
	{
		pressed = true;
		AudioSource.PlayClipAtPoint (ButtonEffect, Vector3.zero);
	}

	void resett()
	{
		Button[] others = FindObjectsOfType(typeof(Button)) as Button[];
		
		foreach(Button other in others)
		{
			other.pressed = false;
		}
		reset = false;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.transform.gameObject.name == "Proton")
		{
			if(!proton_electron)
			{
				pushed();
			}
		}
		if(col.transform.gameObject.name == "Electron")
		{
			if(proton_electron)
			{
				pushed();
			}
		}
	}
}
