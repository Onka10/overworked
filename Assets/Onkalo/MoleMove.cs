using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;

public class MoleMove : MonoBehaviour
{
    [SerializeField] private int MovingSeconds;

    // [SerializeField] private float StartPositionY;                  //最初のポジション
    Vector3 StartPosition;
    [SerializeField] private float TopPositionY;                     //一番上のポジション
    Vector3 TopPosition;

    public bool _onKey=false;                      //キーボード上にいるならTrue
    private CancellationTokenSource cts = new CancellationTokenSource();

    void Start(){
        //ポジションの初期化
        StartPosition = this.gameObject.transform.position;
        // StartPosition.y = StartPositionY;

        TopPosition = this.gameObject.transform.position;
        TopPosition.y = TopPositionY;
    }

    public async UniTask StartUpDown(CancellationToken cancellationToken = default){
        try{
        //上へ
        _onKey = true;

        this.gameObject.transform.position = TopPosition;

        //しばらく上に居る
        await UniTask.Delay(1000,cancellationToken:cancellationToken);
        
        this.gameObject.transform.position = StartPosition;
        _onKey = false;

        }catch(System.OperationCanceledException){
            this.gameObject.transform.position = StartPosition;
            _onKey = false;
            throw;
        }
    }
}