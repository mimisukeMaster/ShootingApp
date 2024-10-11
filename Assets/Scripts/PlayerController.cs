using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// プレイヤーの行動の制御を行うスクリプト
public class PlayerController : MonoBehaviour
{
    // 弾丸のゲームオブジェクト
    // GameObject型は、その変数(=Bullet)に代入されたものの全ての情報にアクセスできる
    public GameObject Bullet;

    // 各スクリプト情報
    // ex) GameManagerController.csのある関数を呼び出したいときには
    //     GameManager.関数名() とする
    public GameManagerController GameManager;
    public EnemyController enemy;

    // 以下のようにパラメータを作成していく
    // ("public"はこのスクリプト外からこの変数にアクセスする必要がある時につける)
    // 外部からのアクセスが必要になったらつければいい

    // public float HP; (HPゲージ表示等でこの値が取得されることを想定)
    // float velocityY; (移動速度は今のところ外部取得を想定していない)

    // Start関数は、ゲーム開始直後一回だけ実行される
    void Start()
    {
        
    }

    // Update関数は毎フレームごとに実行される
    void Update()
    {
        
    }


    // 衝突判定、当たったもののタグで判断する
    // 当たったものの情報がotherに代入されてこの関数が実行される
    void OnCollisionEnter2D(Collision2D other) {
        
    }

    // ここに左ボタン押したときの処理を書く
    public void LeftButtonDown() {

    }

    // ここに右ボタン押したときの処理を書く
    public void RightButtonDown() {

    }

    // ここに弾丸発射ボタン押したときの処理を書く
    public void BulletButtonDown() {

    }
}
