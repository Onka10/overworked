using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class MoleManagerKari : MonoBehaviour
{
    public PlayerInput _playerInput;

    public GameObject ParentMoleKeyObject;

    //キーボード順に代入すること
    private GameObject[] MoleList = new GameObject[25];

    void Start(){
        for(int i=0 ;i<MoleList.Length;i++){
            MoleList[i] = ParentMoleKeyObject.transform.GetChild(i).gameObject;
        }

        _playerInput.InputKey
        .Subscribe(_ => MoleAttack())
        .AddTo(this);
    }

    private void MoleAttack(){
        Debug.Log("攻撃開始");
        //押されたキーとMoleを紐づける
        var InputKey = _playerInput.GetInputkey();
        var MoleObject = MoleList[(int)InputKey];
        var mole = MoleObject.GetComponent<Mole>();

        //攻撃出来るか判定して攻撃
        if(mole.GetMoleState() != MoleState.Appearance) return;
        mole.Attacked();
    }

    // private void ApperMole(){

    // }
}
