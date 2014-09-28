using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class RespawnPoint : MonoBehaviour
{
    public Transform ProtonRespawnPosition;
    public Transform ElectronRespawnPosition;

    private bool _updated = false;

    void Start()
    {
        gameObject.layer = LayerMask.NameToLayer("Wall");
    }

    public void Respawn()
    {
        StartCoroutine(RespawnIE());
    }

    IEnumerator RespawnIE()
    {
        LevelManager.Instance.Proton.Death();
        LevelManager.Instance.Electron.Death();
        yield return new WaitForSeconds(0.7f);
        LevelManager.Instance.Camera.transform.position = new Vector3(LevelManager.Instance.Camera.transform.position.x, transform.position.y, LevelManager.Instance.Camera.transform.position.z);
        LevelManager.Instance.Camera.ResetFreeze();
        LevelManager.Instance.Proton.transform.position = ProtonRespawnPosition.transform.position;
        LevelManager.Instance.Electron.transform.position = ElectronRespawnPosition.transform.position;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!_updated)
        {
            _updated = true;
            LevelManager.Instance.UpdateRespawnPoint(this);
        }
    }
}
