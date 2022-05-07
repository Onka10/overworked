using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class MusicManager : MonoBehaviour
{
    private AudioSource _audioSource;

    void Start(){
        _audioSource = GetComponent<AudioSource>();

        GameManager.I.State
        .Where(s => s==GameState.InGame)
        .Subscribe(s =>MusicStart(s))
        .AddTo(this);
    }

    public void MusicStop(){
        _audioSource.Stop();
    }

    private void MusicStart(GameState gamestate){
        //音源変更
        Music.Play("Music","");
    }
}
