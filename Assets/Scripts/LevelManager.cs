using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public Proton Proton;
    public Electron Electron;
    public RespawnPoint LastRespawnPoint;
    public CameraLogic Camera;
    public AudioClip DieSoundEffect;

    void Awake()
    {
        Instance = FindObjectOfType<LevelManager>();
    }

    public void UpdateRespawnPoint(RespawnPoint respawnPoint)
    {
        LastRespawnPoint = respawnPoint;
    }

    public void LoseGame()
    {
        AudioSource.PlayClipAtPoint(DieSoundEffect, Vector3.zero);
        LastRespawnPoint.Respawn();
    }

    public void WinGame()
    {
        Application.LoadLevel(1);
    }
}
