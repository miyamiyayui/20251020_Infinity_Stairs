using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.InputSystem;

//階段に敵を入れる　負けたら一番下に落ちる　下からマグマかなんかを入れてはらはら感を出す　マグマの進行速度の強化など　進行速度上げるか攻撃力を上げるか
public class Player_Maine : MonoBehaviour
{
    //====== Playerの速度 ======
    [Header("===== Playerの速度系の設定 =====")]

    [Header("下りる速度")]
    [Tooltip("階段を下りていく速度の変更")]
    [SerializeField]
    [Range(0.1f, 1f)]                        // <- 最小値と最大値の設定するやつ
    private float downhillSpeed = 5f;

    [Header("上り速度")]
    [Tooltip("階段を上る速度の変更")]
    [SerializeField]
    [Min(0.1f)]                              // <- これが最小値を設定するやつ
    private float upSpeed = 2f;

    //====== レベル ======
    [Space(20)]

    [Header("総合レベルレベル")]
    [SerializeField]
    [Min(1)]
    private int level = 1;

    [Header("上りレベル")]
    [SerializeField]
    [Min(1)]
    private int upSpeedLevel = 1;

    [Header("下り速度")]
    [SerializeField]
    [Min(1)]
    private int downhillSpeedLevel = 1;

    [Header("攻撃力")]
    [SerializeField]
    [Min(1)]                            //最低数値を設定することができる
    private int attackPowerLevel = 1;

    [Header("HP")]
    [SerializeField]
    [Min(1)]
    private int hpLevel = 1;

    //====== コインやステータス系 ======

    [Header("コインの数")]
    [SerializeField]
    private int generalCoin = 100;

    [Header("攻撃力")]
    [SerializeField]
    private int attackPower = 1;

    [Header("HP")]
    [SerializeField]
    private int hp = 1;

    //====== 入力 ======

    //ボタンまだ決まってないところに一時的に入れるよう
    [Header("一時的なキー")]
    [SerializeField]
    private KeyCode levelUpKey = KeyCode.Q;

    //====== 階段管理 ======

    [Header("階段生成スクリプト")]
    [SerializeField]
    private Stairs stairs;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    void Update()
    {
        var kb = Keyboard.current;
        var pad = Gamepad.current;

        Vector2 moveinput = Vector2.zero;

        if (Time.frameCount % 1 == 0)
        {
            
            stairs.SpawnOneStair();
        }
        transform.position += new Vector3(upSpeed, upSpeed, 0) * Time.deltaTime;

        if (kb != null)
        {
            if (kb.dKey.isPressed)
            {
                Debug.Log("Dボタンが押されてるよ");
                transform.position += new Vector3(upSpeed, upSpeed, 0) * Time.deltaTime;
            }
            if (kb.aKey.isPressed)
            {
                Debug.Log("Aボタンが押されてるよ");
                transform.position += new Vector3(-downhillSpeed, -downhillSpeed, 0) * Time.deltaTime;
            }
            if (kb.qKey.isPressed)
            {
                LevelUp();
                Debug.Log("総合レベルアップ　qボタン押されてる");
            }
            if (kb.wKey.isPressed)
            {
                if (generalCoin >= 10)
                {
                    generalCoin -= 10;
                    SpeedLevel();
                }
            }
            if (kb.pKey.isPressed)
            {
                if(generalCoin >= 50)
                AttackPower();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

        }
    }

    void AttackPower()
    {
        attackPowerLevel++;
        attackPower += 1;
    }
    void SpeedLevel()
    {
        upSpeedLevel++;
        Debug.Log("SpeedLevel Up!" + upSpeedLevel);
        upSpeed += 0.2f;          //上る速度アップ
    }
    void LevelUp()
    {
        Time.timeScale = Time.timeScale + 0.1f;

        //ctrl + k  ctrl + cでコメントアウト　ctrl + uで解除
        //level++;
        //Debug.Log("Level Up! Lv " + level);

        //// レベルアップの恩恵
        //upSpeed += 0.2f;          //上る速度アップ
        //downhillSpeed += 0.5f;    //下り速度アップ

        //// 階段を1段増やす
        //stairs.SpawnOneStair();
    }
    /*
    void AutoClimb()
    {
        //右上に進む
        transform.position += new Vector3(upSpeed, upSpeed, 0) * Time.deltaTime;

    }
    */
}
