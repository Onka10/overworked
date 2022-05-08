using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartButton : MonoBehaviour
{
    Button SButton;
    public GameObject CountDown;
    private void Start()
    {
        SButton = gameObject.GetComponent<Button>();
    }
    public void GameStartAnime()
    {
        Debug.Log("GameStart");
        CountDown.SetActive(true);
        StartCoroutine(ResetCountDown());
    }
    IEnumerator ResetCountDown()
    {
        yield return new WaitForSeconds(5);
        CountDown.SetActive(false);
    }
    private void Update()
    {

    }
}
