using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Electron : MonoBehaviour
{
    public Animator Animator;

	void Start ()
	{
	    gameObject.layer = LayerMask.NameToLayer("Electron");
	}

    void Update()
    {
        if (transform.position.x < LevelManager.Instance.Camera.CurrnetBoundMinX)
        {
            transform.position = new Vector3(LevelManager.Instance.Camera.CurrnetBoundMinX, transform.position.y, transform.position.z);
        }
        if (transform.position.x > LevelManager.Instance.Camera.CurrnetBoundMaxX)
        {
            transform.position = new Vector3(LevelManager.Instance.Camera.CurrnetBoundMaxX, transform.position.y, transform.position.z);
        }
        if (transform.position.y > LevelManager.Instance.Camera.CurrnetBoundMaxY)
        {
            transform.position = new Vector3(transform.position.x, LevelManager.Instance.Camera.CurrnetBoundMaxY, transform.position.z);
        }
        if (transform.position.y < LevelManager.Instance.Camera.CurrnetBoundMinY)
        {
            LevelManager.Instance.LoseGame();
        }
    }

    public void Death()
    {
        StartCoroutine(DeathIE());
    }

    private IEnumerator DeathIE()
    {
        Animator.SetBool("Death", true);
        yield return new WaitForSeconds(0.1f);
        Animator.SetBool("Death", false);
    }

    public void Swap()
    {
        StartCoroutine(SwapIE());
    }

    private IEnumerator SwapIE()
    {
        Animator.SetBool("Swap", true);
        yield return new WaitForSeconds(0.1f);
        Animator.SetBool("Swap", false);
    }
}
