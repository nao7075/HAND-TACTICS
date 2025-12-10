using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// オンラインマッチング画面の制御クラス。
/// Photonサーバーへの接続、ルームへの参加・作成を行う。
/// </summary>
public class OnlineMenuManager : MonoBehaviourPunCallbacks
{
    // ボタンを押したらマッチング開始
    // ランダムマッチングで誰かの部屋に入れればマッチング成功
    // 部屋がなければ自分で作る
    // 部屋が2名になればシーンを遷移
    //[SerializeField] GameObject loadingAnim;
    [SerializeField] GameObject matchingButton; //マッチングボタン
    [SerializeField] Button CpuBattleButton; //CPU対戦ボタン
    //[SerializeField] GameObject matchingMessage;
    bool inRoom; //roomにいるかどうか
    bool isMatching; //マッチングしたかどうか
    

    /// <summary>
    /// CPU対戦開始ボタン処理
    /// </summary>
    public void OnCpuBattleButton()
    {
        SoundManager.instance.PlaySE(0);
        GameManager.instance.IsOnlineBattle = false;
        SceneTransitionManager.instance.Load("Battle");
    }

    /// <summary>
    /// マッチング開始ボタン処理
    /// </summary>
    public void OnMatchingButton()
    {
        SoundManager.instance.PlaySE(0);
        GameManager.instance.IsOnlineBattle = true;
        //loadingAnim.SetActive(true);
        matchingButton.SetActive(false);
        CpuBattleButton.interactable = false;
        //matchingMessage.SetActive(true);
        // PhotonServerSettingsの設定内容を使ってマスターサーバーへ接続する
        PhotonNetwork.ConnectUsingSettings();
    }

    /// <summary>
    /// マスターサーバーへの接続が成功した時に呼ばれるコールバック
    /// </summary>
    public override void OnConnectedToMaster()
    {
        // ランダムなルームに参加を試みる
        PhotonNetwork.JoinRandomRoom();
    }

    /// <summary>
    /// ゲームサーバーへの接続が成功した時に呼ばれるコールバック
    /// </summary>
    public override void OnJoinedRoom()
    {
        inRoom = true;
    }

    /// <summary>
    /// ランダム参加失敗（部屋がない）コールバック
    /// </summary>
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = 2}, TypedLobby.Default);
    }

    /// <summary>
    /// 毎フレーム監視し、部屋が2人ならシーンを変える
    /// </summary>
    private void Update()
    {
        if (isMatching)
        {
            return;
        }
        
        if (inRoom)
        {
            // 人数が最大数（2人）に達したら
            if (PhotonNetwork.CurrentRoom.MaxPlayers == PhotonNetwork.CurrentRoom.PlayerCount)
            {
                isMatching = true;
                
                SceneTransitionManager.instance.Load("Battle");
            }
        }
    }

    /// <summary>
    /// マッチングキャンセル・戻るボタン処理
    /// </summary>
    public void BackDeckSelectButtom()
    {
       if (PhotonNetwork.IsConnected)
        {
                PhotonNetwork.LeaveRoom();
                PhotonNetwork.Disconnect();
        }
        matchingButton.SetActive(true);
        SceneTransitionManager.instance.Load("DeckSelect");
    }
    


}