using System.Collections;
using UnityEngine;

public class SwapManager : MonoBehaviour
{
    public AudioClip SwapSoundEffect;

    public float ElectronCoolDown;
    public float ProtonCoolDown;

    public float ElectronCoolDownTimer;
    public float ProtonCoolDownTimer;

    public SwapCoolDownUpdate ProtonSwapCoolDownUpdate;
    public SwapCoolDownUpdate ElectronSwapCoolDownUpdate;

	void FixedUpdate () 
    {
        if (ElectronCoolDownTimer >= 0)
        {
            ElectronCoolDownTimer -= Time.fixedDeltaTime;
        }

        if (ProtonCoolDownTimer >= 0)
        {
            ProtonCoolDownTimer -= Time.fixedDeltaTime;
        }

        ProtonSwapCoolDownUpdate.UpdateText(ProtonCoolDownTimer);
        ElectronSwapCoolDownUpdate.UpdateText(ElectronCoolDownTimer);

        if (Input.GetKeyDown(KeyCode.LeftControl) && ProtonCoolDownTimer <= 0)
        {
            ProtonCoolDownTimer = ProtonCoolDown;
            Swap();
        }

        if (Input.GetKeyDown(KeyCode.RightControl) && ElectronCoolDownTimer <= 0)
        {
            ElectronCoolDownTimer = ElectronCoolDown;
            Swap();
        }
	}

    void Swap()
    {
        StartCoroutine(SwapIE());
    }

    IEnumerator SwapIE()
    {
        AudioSource.PlayClipAtPoint(SwapSoundEffect, Vector3.zero);
        LevelManager.Instance.Proton.Swap();
        LevelManager.Instance.Electron.Swap();
        yield return new WaitForSeconds(0.2f);
        Vector3 electronOriginPos = LevelManager.Instance.Electron.transform.position;
        LevelManager.Instance.Electron.transform.position = LevelManager.Instance.Proton.transform.position;
        LevelManager.Instance.Proton.transform.position = electronOriginPos;
    }
}
