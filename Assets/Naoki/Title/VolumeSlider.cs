using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class VolumeSlider : MonoBehaviour
{
    public Slider BgmSlider;
    // Start is called before the first frame update
    void Start()
    {
        BgmSlider = gameObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        var current = Keyboard.current;
        if (current == null)
        {
            // キーボードが接続されていないと
            // Keyboard.currentがnullになる
            return;
        }
        var aKey = current.aKey;
        var dKey = current.dKey;
        if (aKey.wasPressedThisFrame)
        {
            BgmSlider.value -= 0.1f;
            Debug.Log("Aキーが押された！");
        }
        if (dKey.wasPressedThisFrame)
        {
            BgmSlider.value += 0.1f;
            Debug.Log("Dキーが押された！");
        }

    }
}
