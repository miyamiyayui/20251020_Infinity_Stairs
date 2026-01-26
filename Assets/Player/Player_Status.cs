using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Status : MonoBehaviour
{
    [Header("【初期ステータス】")]

    [Header("初期HP")]
    [SerializeField]
    private int baseHp = 1;

    [Header("初期攻撃力")]
    [SerializeField]
    private int baseAttack = 1;

    [Header("初期速度")]
    [SerializeField]
    private int baseSpeed;

    [Header("初期所持コイン")]
    [SerializeField]
    private int baseCoin = 100;

    // ===== 基本ステータス（外部参照可能） =====
    public int Hp { get; private set; }     // HP
    public int attack { get; private set; } // 攻撃力
    public int coin { get; private set; }   // コイン



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
