using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Status : MonoBehaviour
{
    // ===== 基本ステータス =====

    [Header(" ===== 基盤ステータス ===== ")]

    [Header("初期HP")]
    [SerializeField, Min(1)]
    private int baseHp = 1;

    [Header("初期攻撃力")]
    [SerializeField, Min(1)]
    private int baseAttack = 1;

    // ----- 初期速度 -----

    [Header(" ----- 初期速度 ----- ")]

    [Header("初期上り速度")]
    [SerializeField, Min(0.01f)]
    private float baseUpSpeed = 0.1f;

    [Header("初期下り速度")]
    [SerializeField, Min(0.01f)]
    private float baseDownhillSpeed = 0.2f;

    // ----- 所持コイン -----

    [Header(" ----- 所持コイン ----- ")]

    [Header("初期所持コイン")]
    [SerializeField, Min(1)]
    private int baseCoin = 100;

    // ===== レベル系 =====

    [Header(" ----- レベル ----- ")]

    [Header("HPレベル")]
    [SerializeField, Range(1, 99)]
    private int levelHp = 1;

    [Header("攻撃力レベル")]
    [SerializeField, Range(1, 99)]
    private int levelAttack = 1;

    [Header("上りレベル")]
    [SerializeField, Range(1, 99)]
    private int levelUpSpeed = 1;

    [Header("下りレベル")]
    [SerializeField, Range(1, 99)]
    private int levelDownhillSpeed = 1;


    // ===== 基本ステータス（外部参照可能 変更不可） =====
    public int Hp { get; private set; }          // 現在HP
    public int Attack { get; private set; }      // 現在攻撃力
    public float UpSpeed { get; private set; }   // 上り速度
    public float DownSpeed { get; private set; } // 下り速度
    public int Coin { get; private set; }        // 現在コイン
    public int LevelHp => levelHp;               // 現在レベル


    // ===== ゲーム開始時の初期値の設定 =====
    private void Awake()
    {
        Hp = baseHp;
        Attack = baseAttack;
        UpSpeed = baseUpSpeed;
        DownSpeed = baseDownhillSpeed;
        Coin = baseCoin;
    }

    // ===== コイン消費処理 =====
    public bool UseCoin(int amount)
    {
        if (Coin < amount) return false;
        Coin -= amount;
        return true;
    }

    // ===== レベルアップ系 =====

    // HPレベルアップ
    public void LevelUpHp()
    {
        levelHp++;
        Hp += 1;
    }

    // 攻撃力レベルアップ
    public void LevelUpAttack()
    {
        levelAttack++;
        Attack += 1;
    }

    // 上りレベルアップ
    public void LevelUpUpSpeed()
    {
        levelUpSpeed++;
        UpSpeed += 1;
    }

    // 下りレベルアップ
    public void LevelUpDownhillSpeed()
    {
        levelDownhillSpeed++;
        DownSpeed += 1;
    }

    public void Damage(int damege)
    {
        Hp -= damege;

        if (Hp <= 0)
        {
            Hp = levelHp;
        }

    }
}
