using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;

public class MoleManagerKari : MonoBehaviour
{
    public PlayerInput _playerInput;

    public GameObject ParentMoleKeyObject;

    //キーボード順に代入すること
    private GameObject[] MoleList = new GameObject[25];

    private bool _inGame;


    void Start(){
        for(int i=0 ;i<MoleList.Length;i++){
            MoleList[i] = ParentMoleKeyObject.transform.GetChild(i).gameObject;
        }

        _playerInput.InputKey
        .Subscribe(_ => MoleAttack())
        .AddTo(this);

        GameManager.I.State
        .Subscribe(t =>{
            _inGame = t==GameState.InGame ? true:false;
        })
        .AddTo(this);

    }

    private void MoleAttack(){
        //押されたキーとMoleを紐づける
        var InputKey = _playerInput.GetInputkey();
        var MoleObject = MoleList[(int)InputKey];
        var mole = MoleObject.GetComponent<Mole>();

        //攻撃出来るか判定して攻撃
        if(mole.GetMoleState() != MoleState.Appearance) return;
        mole.Attacked();
    }

    void Update(){
        if(_inGame){
            if(Music.IsNearChangedBeat()){
                int up = (int)Random.Range (1.0f, 25.0f);
                Debug.Log(up);
                MoleList[up].SetActive(true);
                False(up).Forget();
            }
        }
    }

    async UniTask False(int i){
        await UniTask.Delay(1000);
        MoleList[i].SetActive(false);
    }
}
