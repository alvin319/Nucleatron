using UnityEngine;

public class ElectronBullet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        LevelManager.Instance.LoseGame();
    }
}
