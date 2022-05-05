using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UniRx;

public class PlayerInput : MonoBehaviour
{
    public void OnA(InputAction.CallbackContext context){
        if(context.phase == InputActionPhase.Started){
            // _playcardsubject.OnNext(Unit.Default);
        }
    }
}
