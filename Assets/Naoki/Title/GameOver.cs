using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    int Score;
    public GameObject OverScene;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void PlayOverAnime()
    {
        OverScene.SetActive(true);
        var OverAnimator = OverScene.GetComponent<Animator>();
        OverAnimator.SetInteger("Score", Score);

    }
    public void ResetOverAnime()
    {
        OverScene.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
