using UnityEngine;
using System.Collections;

public class SwapCoolDownUpdate : MonoBehaviour
{
    public GUIText GuiText;

    public void UpdateText(float time)
    {
        if (time <= 0f)
        {
            GuiText.text = "Swap";
        }
        else
        {
            GuiText.text = time.ToString("0.0");
        }
    }
}
