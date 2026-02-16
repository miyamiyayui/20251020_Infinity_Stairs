using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Maine : MonoBehaviour
{
    [Header("参照")]
    [SerializeField]
    private Player_Status status;

    [SerializeField]
    private Step_Manager stepManager;

    [Header("落下位置")]
    [SerializeField]
    private Vector3 bottomPosition = Vector3.zero;

    [Header("落下速度倍率")]
    [SerializeField]
    private float fallSpeedMultiplier = 3f;

    private float stepTimer = 0f;
    private float stepInterval = 1f;

    private bool isFalling = false;
    private int currentFloor;

    private void Update()
    {
        // ===== 落下中は落下処理だけ =====
        if (isFalling)
        {
            SlideFall();
            return;
        }

        var kb = Keyboard.current;
        if (kb == null) return;

        // ===== 仮ダメージ =====
        if (kb.spaceKey.wasPressedThisFrame)
        {
            status.Damage(1);
            Debug.Log("HP : " + status.Hp);
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

        AutoClimb();

        // ===== 死亡チェック =====
        if (status.Hp <= 0)
        {
            StartFall();
        }

        UpdateFloor();
    }
    void UpdateFloor()
    {
        int floor =
            Mathf.FloorToInt(transform.position.y);

        if (floor != currentFloor)
        {
            currentFloor = floor;
            Debug.Log("階段：" + currentFloor);
        }
    }

    // ===== 自動で上る =====
    void AutoClimb()
    {
        Vector3 move =
            Vector3.right * status.UpSpeed +
            Vector3.up * status.UpSpeed;

        transform.position += move * Time.deltaTime;

        stepTimer += Time.deltaTime;

        if (stepTimer >= stepInterval)
        {
            stepTimer = 0f;
            stepManager.AddStep();
        }
    }

    // ===== 落下開始 =====
    void StartFall()
    {
        isFalling = true;
        stepManager.ResetStep();
    }

    // ===== 滑り落ちる =====
    void SlideFall()
    {
        Vector3 direction =
            Vector3.left * status.DownSpeed +
            Vector3.down * status.DownSpeed;

        transform.position +=
            direction * fallSpeedMultiplier * Time.deltaTime;

        // 底に到達
        if (transform.position.y <= bottomPosition.y)
        {
            transform.position = bottomPosition;
            isFalling = false;
            status.HealFull();
        }
    }

    // ===== 外部から落とす =====
    public void FallToBottomExternal()
    {
        StartFall();
    }
}
