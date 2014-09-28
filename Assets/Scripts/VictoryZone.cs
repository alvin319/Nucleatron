using UnityEngine;

public class VictoryZone : MonoBehaviour
{
    private bool _updated = false;
	void Start () 
    {
        gameObject.layer = LayerMask.NameToLayer("Wall");
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!_updated)
        {
            _updated = true;
            LevelManager.Instance.WinGame();
        }
    }
}
