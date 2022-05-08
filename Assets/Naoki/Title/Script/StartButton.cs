using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartButton : MonoBehaviour
{
    public Button SButton;
    public GameObject CountDown;
    // public Slider BgmSlider;
    public AudioSource audioSource;
    public GameObject GameTitle;
    //タイトルシーンが終わればtrue
    public bool TitleEnd = false;

    private void Start()
    {


    }
    public void GameStartAnime()
    {
        Debug.Log("GameStart");
        GameTitle.SetActive(false);
        SButton.gameObject.SetActive(false);
        // BgmSlider.gameObject.SetActive(false);
        CountDown.SetActive(true);
        audioSource.mute = true;
        StartCoroutine(ResetCountDown());
    }
    IEnumerator ResetCountDown()
    {
        yield return new WaitForSeconds(5);
        CountDown.SetActive(false);
        TitleEnd = true;
    }
    private void Update()
    {

    }
}
