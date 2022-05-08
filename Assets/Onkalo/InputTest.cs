using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class InputTest : MonoBehaviour
{
    public PlayerInput _playerInput;
    public Text text;

    void Start(){
        _playerInput.InputKey
        .Subscribe(_ =>{
            text.text = _playerInput.GetInputkey().ToString();
        })
        .AddTo(this);
    }
}
