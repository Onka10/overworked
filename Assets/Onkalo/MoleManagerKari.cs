using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class MoleManagerKari : MonoBehaviour
{
    public PlayerInput _playerInput;
    // List<IMole> MoleList = new List<IMole>(25);
    IMole[] MoleList = new IMole[25];

    void Start(){
        _playerInput.InputKey
        .Subscribe(_ => MoleAttack())
        .AddTo(this);
    }

    private void InitMole(){
        for(int i=0;i<MoleList.Length;i++){
            // MoleList[i].SetDeadKey(key);
        }
    }

    private void MoleAttack(){
        //判定
        var Key = _playerInput.GetInputkey();
        // MoleList[].AttackedMole();
    }

    private void ApperMole(){

    }
}
