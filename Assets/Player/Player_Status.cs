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

    [Header("----- 初期速度 -----")]
    [SerializeField]
    [Min(0.01f)]
    private float baseSpeed = 0.1f;

    [Header("初期レベル")]
    [SerializeField]
    [Min(1)]
    private int level = 1;

    [Header("初期所持コイン")]
    [SerializeField]
    private int baseCoin = 100;

    // ===== 基本ステータス（外部参照可能 変更不可） =====
    public int Hp { get; private set; }     // 現在HP
    public int Attack { get; private set; } // 現在攻撃力
    public int Coin { get; private set; }   // 現在コイン
    public int Level => Level;              // 現在レベル

    private void Awake()
    {
        Hp = baseHp;
        Attack = baseAttack;
        Coin = baseCoin;
    }
}
