using UnityEngine;
using System.Collections;

public class NeutralBullet : MonoBehaviour 
{
    void OnTriggerEnter2D(Collider2D col)
    {
        LevelManager.Instance.LoseGame();
    }
}
