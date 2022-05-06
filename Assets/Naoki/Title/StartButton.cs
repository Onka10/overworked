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
    }
    private void Update()
    {

    }
}
