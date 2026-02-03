using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Status : MonoBehaviour
{
    // ===== 基本ステータス =====

    [Header(" ===== 基盤ステータス ===== ")]

    [Header("初期HP")]
    [SerializeField]
    [Min(1)]
    private int baseHp = 1;

    [Header("初期攻撃力")]
    [SerializeField]
    [Min(1)]
    private int baseAttack = 1;

    [Header(" ----- 初期速度 ----- ")]

    [Header("初期上り速度")]
    [SerializeField]
    [Min(0.01f)]
    private float baseUpSpeed = 0.1f;

    [Header("初期下り速度")]
    [SerializeField]
    [Min(0.01f)]
    private float baseDownhillSpeed = 0.2f;

    [Header(" ----- 初期設定 ----- ")]

    [Header("初期レベル")]
    [SerializeField]
    [Min(1)]
    private int level = 1;

    [Header("初期所持コイン")]
    [SerializeField]
    private int baseCoin = 100;

    // ===== 基本ステータス（外部参照可能 変更不可） =====
    public int Hp { get; private set; }          // 現在HP
    public int Attack { get; private set; }      // 現在攻撃力
    public float UpSpeed { get; private set; }   // 上り速度
    public float DownSpeed { get; private set; } // 下り速度
    public int Coin { get; private set; }        // 現在コイン
    public int Level => Level;                   // 現在レベル


    // ゲーム開始時の初期値の設定
    private void Awake()
    {
        Hp = baseHp;
        Attack = baseAttack;
        UpSpeed = baseUpSpeed;
        DownSpeed = baseDownhillSpeed;
        Coin = baseCoin;
    }

    public bool UseCoin(int amount)
    {
        if (Coin < amount) return false;
        Coin -= amount;
        return true;
    }
}
