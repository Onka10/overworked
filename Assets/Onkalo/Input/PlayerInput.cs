using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;
using UniRx;

public class PlayerInput : MonoBehaviour
{
    public IObservable<Unit> InputKey => _inputSubject;
    private Subject<Unit> _inputSubject = new Subject<Unit>();

    private Dictionary<string, KeyBoardEnum> keyDictionary;
    private KeyBoardEnum InputKeyCode;

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
            {"Key:/Keyboard/l" , KeyBoardEnum.L},
            {"Key:/Keyboard/m" , KeyBoardEnum.M},
            {"Key:/Keyboard/n" , KeyBoardEnum.N},
            {"Key:/Keyboard/o" , KeyBoardEnum.O},
            {"Key:/Keyboard/p" , KeyBoardEnum.P},
            {"Key:/Keyboard/q" , KeyBoardEnum.Q},
            {"Key:/Keyboard/r" , KeyBoardEnum.R},
            {"Key:/Keyboard/s" , KeyBoardEnum.S},
            {"Key:/Keyboard/t" , KeyBoardEnum.T},
            {"Key:/Keyboard/u" , KeyBoardEnum.U},
            {"Key:/Keyboard/v" , KeyBoardEnum.V},
            {"Key:/Keyboard/w" , KeyBoardEnum.W},
            {"Key:/Keyboard/x" , KeyBoardEnum.X},
            {"Key:/Keyboard/y" , KeyBoardEnum.Y},
            {"Key:/Keyboard/z" , KeyBoardEnum.Z}
        };
    }

    public void OnKey(InputAction.CallbackContext context){
        //ゲーム中以外は実行しない
        // if(GameManager.I.State.Value != GameState.InGame)   return;

        if(context.phase == InputActionPhase.Started){
            string key = context.control.ToString();
            InputKeyCode = keyDictionary[key];
            Debug.Log(key);

            _inputSubject.OnNext(Unit.Default);
        }
    }

    public KeyBoardEnum GetInputkey(){
        return InputKeyCode;
    }
}
