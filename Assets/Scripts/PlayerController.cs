using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// プレイヤーの行動の制御を行うスクリプト
public class PlayerController : MonoBehaviour
{
    // 弾丸のゲームオブジェクト
    // GameObject型は、その変数(=Bullet)に代入されたものの全ての情報にアクセスできる
    public GameObject Bullet;

    // ex) GameManagerController.csのある関数を呼び出したいときには
    //     GameManager.関数名() とする
    public GameManagerController GameManager;

    public int HP;

    Rigidbody2D myRigidbody;

    //boolの初期値はfalse
    public bool isStarted;

    // Start関数は、ゲーム開始直後一回だけ実行される
    void Start()
    {
        // HPの初期値（最大値）を設定する処理
        HP = 10;
        // 体力ゲージの最大値を設定する関数を呼ぶ
        GameManager.SetMaxHP(HP);

        // 物理演算コンポーネントを取得
        myRigidbody = GetComponent<Rigidbody2D>();

    }

    // Update関数は毎フレームごとに実行される
    void Update()
    {
        // 前に進む速度を設定する処理
        if(myRigidbody.velocity.y < 2 && isStarted){
            //bool関数は==が省略可、否定は!
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x,2);
        }

        //Ctrl + Alt + Shift 任意の矢印で複数行選択
        if (Input.GetKeyDown(KeyCode.LeftArrow)) LeftButtonDown();
        if (Input.GetKeyDown(KeyCode.RightArrow)) RightButtonDown();
        if (Input.GetKeyDown(KeyCode.Return)) BulletButtonDown();

        if(this.transform.position.x > 2 ) {
            myRigidbody.velocity = new Vector2(0, 0);
            this.transform.position += new Vector3(-0.1f, 0f, 0f);
        }
        if(this.transform.position.x < -2 ) {
            myRigidbody.velocity = new Vector2(0, 0);
            this.transform.position += new Vector3(0.1f, 0f, 0f);
        }
        if(this.transform.position.y > 62) {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0);
        }
    }


    // 衝突判定、当たったもののタグで判断する
    // 当たったものの情報がotherに代入されてこの関数が実行される
    void OnTriggerEnter2D(Collider2D other) {
            Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Boss")) {
            // 自分のHPを減らす処理
            HP -= 5;
            // UIを更新するためGameManagerController.csのDecreaseHP()関数を呼ぶ
            GameManager.DecreaseHP(HP);

            // HPが0なら削除
            if(HP <= 0) {
                GameManager.GameOver();
            }
        }
    }

    // ここに左ボタン押したときの処理を書く
    public void LeftButtonDown() {
        myRigidbody.velocity = new Vector2(-4, 0);
        GameManager.ButtonSEPlay();
    }

    // ここに右ボタン押したときの処理を書く
    public void RightButtonDown() {
        myRigidbody.velocity = new Vector2(4, 0);
        GameManager.ButtonSEPlay();
    }

    // ここに弾丸発射ボタン押したときの処理を書く
    public void BulletButtonDown() {
        
        // 弾丸を生成するには、Instantiate()関数を使う
        Vector3 pos = new Vector3(
            this.transform.position.x, this.transform.position.y + 2, this.transform.position.y
        );
        Instantiate(Bullet, pos, Quaternion.Euler(0, 0, 90));

        GameManager.LaunchSEPlay();
    }

    public void Started() => isStarted = true;
}
