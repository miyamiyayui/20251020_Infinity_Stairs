using UnityEngine;

public class Battle_Manager : MonoBehaviour
{
    [SerializeField] 
    private Player_Maine player;
    [SerializeField] 
    private Player_Status playerStatus;

    public void StartBattle(Enemy_Status enemy)
    {
        Debug.Log("=== 戦闘開始 ===");
        
        Time.timeScale = 0f;

        while (enemy.Hp > 0 && playerStatus.Hp > 0)
        {
            // プレイヤー攻撃
            enemy.TakeDamage(playerStatus.Attack);

            if (enemy.Hp <= 0)
                break;

            // 敵攻撃
            playerStatus.Damage(enemy.Attack);
        }

        // 勝敗判定
        if (playerStatus.Hp <= 0)
        {
            Time.timeScale = 1f;
            Debug.Log("負けた！");
            player.FallToBottomExternal();
        }
        else
        {
            Time.timeScale = 1f;
            Debug.Log("勝った！");
            playerStatus.AddCoin(10);
        }
    }
}
