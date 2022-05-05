using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UniRx;

public class PlayerInput : MonoBehaviour
{
    Dictionary<string, KeyBoardEnum> keyDictionary;
    void Start(){
		//Dictionaryを作成
		keyDictionary = new Dictionary<string, KeyBoardEnum> (){

            {"Key:/Keyboard/a" , KeyBoardEnum.A},
            {"Key:/Keyboard/b" , KeyBoardEnum.B},
            {"Key:/Keyboard/c" , KeyBoardEnum.C},
            {"Key:/Keyboard/d" , KeyBoardEnum.D},
            {"Key:/Keyboard/e" , KeyBoardEnum.E},
            {"Key:/Keyboard/f" , KeyBoardEnum.F},
            {"Key:/Keyboard/g" , KeyBoardEnum.G},
            {"Key:/Keyboard/h" , KeyBoardEnum.H},
            {"Key:/Keyboard/i" , KeyBoardEnum.I},
            {"Key:/Keyboard/j" , KeyBoardEnum.J},
            {"Key:/Keyboard/k" , KeyBoardEnum.K},
        };
    }

    public void OnKey(InputAction.CallbackContext context){
        if(context.phase == InputActionPhase.Started){
            // _playcardsubject.OnNext(Unit.Default);
            // Debug.Log(context);
            // Debug.Log(context.control);
            // Debug.Log(context.control.ToString());
            string key = context.control.ToString();

            if(keyDictionary[key] == KeyBoardEnum.A)    Debug.Log("a");
            else Debug.Log("no");

        }
    }
}
