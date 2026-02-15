using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Maine : MonoBehaviour
{
    [Header("参照")]
    [SerializeField] private Player_Status status;
    [SerializeField] private Step_Manager stepManager;

    [Header("落下位置")]
    [SerializeField] private Vector3 bottomPosition = Vector3.zero;

    private void Update()
    {
        var kb = Keyboard.current;
        if (kb == null) return;

        // ===== 上る =====
        if (kb.dKey.isPressed)
        {
            MoveUp();
        }

        // ===== 下りる =====
        if (kb.aKey.isPressed)
        {
            MoveDown();
        }

        // ===== 仮：ダメージ =====
        if (kb.spaceKey.wasPressedThisFrame)
        {
            status.Damage(1);
            Debug.Log("HP : " + status.Hp);
        }

        // ===== 死亡 =====
        if (status.Hp <= 0)
        {
            FallToBottom();
        }

        // ===== テスト用レベルアップ =====
        if (kb.qKey.wasPressedThisFrame)
        {
            status.LevelUpUpSpeed();
            Debug.Log("上り速度Lv：" + status.UpSpeedLevel);
        }

        if (kb.wKey.wasPressedThisFrame)
        {
            status.LevelUpDownSpeed();
            Debug.Log("下り速度Lv：" + status.DownSpeedLevel);
        }
    }

    void MoveUp()
    {
        Vector3 move =
            Vector3.right * status.UpSpeed +
            Vector3.up * status.UpSpeed;

        transform.position += move * Time.deltaTime;
        stepManager.AddStep();
    }

    void MoveDown()
    {
        Vector3 move =
            Vector3.left * status.DownSpeed +
            Vector3.down * status.DownSpeed;

        transform.position += move * Time.deltaTime;
    }

    void FallToBottom()
    {
    confirmation:
        transform.position = bottomPosition;
        stepManager.ResetStep();
        status.HealFull();
    }
}
