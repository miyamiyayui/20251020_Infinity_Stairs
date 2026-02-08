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
    private int hpLevel = 1;

    [Header("攻撃力レベル")]
    [SerializeField, Range(1, 99)]
    private int attackLevel = 1;

    [Header("上りレベル")]
    [SerializeField, Range(1, 99)]
    private int upSpeedLevel = 1;

    [Header("下りレベル")]
    [SerializeField, Range(1, 99)]
    private int downSpeedLevel = 1;


    // ===== 基本ステータス（外部参照可能 変更不可） =====
    public int Hp { get; private set; }          // 現在HP
    public int Attack { get; private set; }      // 現在攻撃力
    public float UpSpeed { get; private set; }   // 上り速度
    public float DownSpeed { get; private set; } // 下り速度
    public int Coin { get; private set; }        // 現在コイン
    public int HpLevel => hpLevel;
    public int AttackLevel => attackLevel;
    public int UpSpeedLevel => upSpeedLevel;
    public int DownSpeedLevel => downSpeedLevel;

    // ===== ゲーム開始時の初期値の設定 =====
    private void Awake()
    {
        Hp = baseHp;
        Attack = baseAttack;
        UpSpeed = baseUpSpeed;
        DownSpeed = baseDownhillSpeed;
        Coin = baseCoin;
    }

    // ===== レベルアップ系 =====

    public void Damage(int value)
    {
        Hp -= value;
        if (Hp < 0) Hp = 0;
    }

    public void HealFull()
    {
        Hp = baseHp + hpLevel - 1;
    }

    // ===== コイン =====

    public bool UseCoin(int cost)
    {
        if (Coin < cost) return false;
        Coin -= cost;
        return true;
    }

    public void AddCoin(int value)
    {
        Coin += value;
    }

    // ===== レベルアップ =====

    public void LevelUpHp()
    {
        hpLevel++;
        Hp++;
    }

    public void LevelUpAttack()
    {
        attackLevel++;
        Attack++;
    }

    public void LevelUpUpSpeed()
    {
        upSpeedLevel++;
        UpSpeed += 0.2f;
    }

    public void LevelUpDownSpeed()
    {
        downSpeedLevel++;
        DownSpeed += 0.3f;
    }
}
