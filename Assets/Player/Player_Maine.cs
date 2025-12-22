using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.InputSystem;

public class Player_Maine : MonoBehaviour
{
    //====== Playerの速度 ======

    [Header("下りる速度")]
    [Tooltip("階段を下りていく速度の変更")]
    [SerializeField]
    private float downhillSpeed = 5f;

    [Header("上り速度")]
    [Tooltip("階段を上る速度の変更")]
    [SerializeField]
    private float upSpeed = 2f;

    //====== レベル ======

    [Header("現在のレベル")]
    [SerializeField]
    private int level = 1;

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
                Debug.Log("qボタン押されてる");
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

        }
    }

    void LevelUp()
    {
        level++;
        Debug.Log("Level Up! Lv " + level);

        // レベルアップの恩恵
        upSpeed += 0.2f;          //上る速度アップ
        downhillSpeed = 0.2f;    //下り速度アップ

        // 階段を1段増やす
        stairs.SpawnOneStair();
    }
    /*
    void AutoClimb()
    {
        //右上に進む
        transform.position += new Vector3(upSpeed, upSpeed, 0) * Time.deltaTime;

    }
    */
}
