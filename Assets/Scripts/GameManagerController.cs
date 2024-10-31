using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// ゲームの進行、スコア判定など総括的な処理を行うスクリプト
public class GameManagerController : MonoBehaviour
{
    public Image HPGauge;
    public GameObject Enemy;
    public GameObject Boss;
    public AudioSource audioSource;
    public AudioClip StartBGM;
    public AudioClip GameBGM;
    public AudioClip ClearBGM;
    public AudioClip LaunchSE;
    public AudioClip AttackSE;
    public AudioClip ButtonSE;
    public AudioClip ReplaySE;
    public GameObject StartUI;
    public GameObject ClearUI;
    // 本当はファイルで区切らずにタグと配列でやったほうが良き(画面比変えたとき大変)

    float maxHPGauge;
    Transform BossHPMask;
    float maxBossHPGauge;
    int enemyNum;

    GameObject[] GameUIs;

    // Start関数は、ゲーム開始直後一回だけ実行される
    void Start()
    {
        // 敵の生成
        enemyNum = 10;

        for (int i = 0; i < enemyNum; i++)
        {
            // x軸方向はランダムな位置に、方向は6とびずつ生成していく
            float randomX = Random.Range(-2.5f, 1.5f);
            Instantiate(Enemy, new Vector2(randomX, 4 + 6 * i), Quaternion.Euler(0, 0, -90));
        }

        // ボスを生成
        // 生成する位置は、雑魚キャラを生成しきった先なので Vector2(0, 4 + 6 * enemyNum) の位置にする(最後の雑魚キャラのy座標のさらに奥)
        GameObject boss = Instantiate(Boss, new Vector2(0, 7.2f + 6 * enemyNum), Quaternion.Euler(0, 0, 90));

        BossHPMask = boss.transform.Find("BossHPMask");
        audioSource = GameObject.Find("Audio Source").GetComponent<AudioSource>();
    
        GameUIs = GameObject.FindGameObjectsWithTag("GameUI");
        foreach(GameObject obj in GameUIs) obj.SetActive(false);

        // スタート画面用でのBGMの再生
        audioSource.clip = StartBGM;
        audioSource.Play();
    }

    // Update関数は毎フレームごとに実行される
    void Update() {
        
    }

    // プレイヤーの体力の最大値をHPゲージの最大値に設定
    public void SetMaxHP(int maxHP) => maxHPGauge = maxHP;
    public void SetMaxBossHP(int maxHP) => maxBossHPGauge = maxHP;

    public void DecreaseHP(float weight) => HPGauge.fillAmount = weight / maxHPGauge;
    public void DecreaseBossHP(float weight) {
        Debug.Log(weight / maxBossHPGauge * 5);
        
        BossHPMask.position = new Vector3(
         (weight - 1) / maxBossHPGauge * 3.9f - 3.9f, BossHPMask.position.y, 0);
    }

    // 各効果音を鳴らす処理
    // 関数（引数）｛動作｝のうち{動作}が一行の時の書き方
    public void LaunchSEPlay() => audioSource.PlayOneShot(LaunchSE);
    public void AttackSEPlay() => audioSource.PlayOneShot(AttackSE);
    public void ButtonSEPlay() => audioSource.PlayOneShot(ButtonSE);
    public void ReplaySEPlay() => audioSource.PlayOneShot(ReplaySE);

    // UIの制御
    public void StartProcess(){
        StartUI.SetActive(false);
        foreach(GameObject obj in GameUIs) obj.SetActive(true);

        // ゲームBGMに変更する
        // audioSourceクラスのclip変数を変える
        audioSource.clip = GameBGM;
        audioSource.Play();
    }
    public void ClearProcess() {
        foreach(GameObject obj in GameUIs) obj.SetActive(false);
        ClearUI.SetActive(true);

        // BGMをクリア後のBGMに変更する処理
        // AudioSourceクラスのclipを変更する
        audioSource.clip = ClearBGM;
        audioSource.Play();
    }

    public void ReplayButtonDown() => Invoke(nameof(LoadScene), 0.5f);
    public void LoadScene() => SceneManager.LoadScene("GameScene");
    public void GameOver() => SceneManager.LoadScene("GameOverScene");
}
