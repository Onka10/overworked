using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Threading;

public class MoleManagerKari : MonoBehaviour
{
    //FIXME現状責任が重い
    
    public PlayerInput _playerInput;

    public GameObject ParentMoleKeyObject;

    //キーボード順に代入すること
    private GameObject[] MoleList = new GameObject[25];
    private Mole[] MoleLists = new Mole[25];

    private bool _inGame;

    private CancellationTokenSource cts = new CancellationTokenSource();

    private int _upkey1;
    private int _upkey2;


    void Start(){
        for(int i=0 ;i<MoleList.Length;i++){
            // MoleList[i] = ParentMoleKeyObject.transform.GetChild(i).gameObject;
            MoleLists[i] = ParentMoleKeyObject.transform.GetChild(i).gameObject.GetComponent<Mole>();
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
                DecideUpMole();
            }
            if(Music.IsJustChangedBeat()){
                UpMole();
            }
        }
    }

    private void DecideUpMole(){
        int up = (int)Random.Range (0f, 12.0f);
        _upkey1 = up;
        //TODO キーボード点滅

        up = (int)Random.Range (12.0f, 24.0f);
        _upkey2 = up;
        //TODO キーボード点滅
    }

    private void UpMole(){
        MoleLists[_upkey1].Apper(cts.Token);
        MoleLists[_upkey2].Apper(cts.Token);
    }

    private void OnDestroy(){
        cts.Cancel();
    }
}
