using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Threading;

public class MoleManagerKari : MonoBehaviour
{
    //
    [SerializeField] PlayerEffectManager _playerEffectManager;
    
    public PlayerInput _playerInput;

    public GameObject ParentMoleKeyObject;

    //キーボード順に代入すること
    private GameObject[] MoleList = new GameObject[26];
    private Mole[] MoleLists = new Mole[26];

    private bool _inGame;

    private CancellationTokenSource cts = new CancellationTokenSource();

    private int _upkey1;
    private int _upkey2;

    private GameManager _gameManager;


    void Start(){
        for(int i=0 ;i<MoleList.Length;i++){
            // MoleList[i] = ParentMoleKeyObject.transform.GetChild(i).gameObject;
            MoleLists[i] = ParentMoleKeyObject.transform.GetChild(i).gameObject.GetComponent<Mole>();
        }

        _gameManager = GameManager.I;

        _playerInput.InputKey
        .Where(_ => _gameManager.State.Value == GameState.InGame)
        .Subscribe(_ => MoleAttack())
        .AddTo(this);

        GameManager.I.State
        .Subscribe(t =>{
            _inGame = t==GameState.InGame ? true:false;
            if(t==GameState.InGame) ParentMoleKeyObject.SetActive(true);
            // _playerEffectManager.Active();
        })
        .AddTo(this);

    }

    private void MoleAttack(){
        // Debug.Log("クリック");
        //押されたキーとMoleを紐づける
        var InputKey = _playerInput.GetInputkey();
        var mole = MoleLists[(int)InputKey];

        //FIXME エフェクト再生
        _playerEffectManager.Play(InputKey);

        //se再生
        SEManager.I.StartClickSE();

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
        int up = (int)Random.Range (0f, 24.0f);
        _upkey1 = up;
        //TODO キーボード点滅

        // up = (int)Random.Range (12.0f, 24.0f);
        // _upkey2 = up;
        // //TODO キーボード点滅
    }

    private void UpMole(){
        // Debug.Log(_upkey1+"キー");
        if(MoleLists[_upkey1].GetMoleState() == MoleState.Incubation)   MoleLists[_upkey1].Apper(cts.Token);
        // if(MoleLists[_upkey2].GetMoleState() == MoleState.Incubation)   MoleLists[_upkey2].Apper(cts.Token);
    }

    private void OnDestroy(){
        cts.Cancel();
    }
}
