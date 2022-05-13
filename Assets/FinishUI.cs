using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishUI : MonoBehaviour
{
    [SerializeField]
    private AudioSource gameBGM;

    [SerializeField]
    private GameObject finishUI;

    private float playTime = 0;
    private bool start = false;

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            playTime += Time.deltaTime;
            if (playTime > 2)
            {
                finishUI.SetActive(false);
                start = false;
            }
        }
        if(gameBGM.time > 97f)
        {
            finishUI.SetActive(true);
            start = true;
        }
    }
}
