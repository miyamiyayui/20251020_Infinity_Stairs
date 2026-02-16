using UnityEngine;

public class Enemy_Status : MonoBehaviour
{
    // ===== 基本ステータス =====

    [Header(" <color=#00FFFF><size=25> Enemy設定 </size></color> ")]

    [Header(" ===== <color=yellow><size=20> 基盤ステータス </size></color> ===== ")]

    [Header("基礎HP")]
    [SerializeField, Min(1)]
    private int baseHp = 5;

    [Header("基礎攻撃力")]
    [SerializeField, Min(1)]
    private int baseAttack = 1;

    // ===== 倍率設定 =====

    [Header("===== <color=yellow><size=20> 成長倍率 </size></color> =====")]

    [Header("階段ごとのHP倍率")]
    [SerializeField]
    private float hpMultiplier = 1.2f;

    [Header("階段ごとの攻撃倍率")]
    [SerializeField]
    private float attackMultiplier = 1.1f;

    // ===== ボス設定 =====

    [Header("===== <color=yellow><size=20> ボス設定 </size></color> =====")]

    [Header("ボスかどうか")]
    [SerializeField]
    private bool isBoss = false;

    [Header("ボスHP倍率")]
    [SerializeField]
    private float bossHpMultiplier = 3f;

    [Header("ボス攻撃倍率")]
    [SerializeField]
    private float bossAttackMultiplier = 2f;

    // ===== 現在ステータス（外部参照OK） =====

    public int Hp { get; private set; }
    public int Attack { get; private set; }

    private int currentFloor;

    // ===== 初期化 =====
    public void Initialize(int floor)
    {
        currentFloor = floor;

        // 階段による成長計算
        float hpScale = Mathf.Pow(hpMultiplier, floor / 10f);
        float attackScale = Mathf.Pow(attackMultiplier, floor / 10f);

        int finalHp = Mathf.RoundToInt(baseHp * hpScale);
        int finalAttack = Mathf.RoundToInt(baseAttack * attackScale);

        // ボス補正
        if (isBoss)
        {
            finalHp = Mathf.RoundToInt(finalHp * bossHpMultiplier);
            finalAttack = Mathf.RoundToInt(finalAttack * bossAttackMultiplier);
        }

        Hp = finalHp;
        Attack = finalAttack;
    }

    // ===== ダメージ処理 =====
    public bool TakeDamage(int damage)
    {
        Hp -= damage;

        if (Hp <= 0)
        {
            Hp = 0;
            Die();
            return true; // 倒された
        }

        return false;
    }

    private void Die()
    {
        Debug.Log(gameObject.name + " を倒した！");
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Battle_Manager battle = FindObjectOfType<Battle_Manager>();
            battle.StartBattle(GetComponent<Enemy_Status>());
        }
    }

}
