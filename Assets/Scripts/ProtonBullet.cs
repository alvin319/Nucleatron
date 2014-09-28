using UnityEngine;

public class ProtonBullet : MonoBehaviour 
{
    void OnTriggerEnter2D(Collider2D col)
    {
        LevelManager.Instance.LoseGame();
    }
}
