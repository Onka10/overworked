using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    [SerializeField] GameObject _socre;
    public void StarGame(){
        _socre.SetActive(true);
    }   
}
