/*
using UnityEngine;

public class otehon : MonoBehaviour
{
    public GameObject cubePrefab; // 1x1 キューブ
    public Vector3 startPos = Vector3.zero;

    public int stepCount = 0; // 今何段目か

    // 1段上がるときのオフセット（右斜め方向）
    public float horizontalOffset = 1f;
    public float verticalOffset = 1f;

    private Vector3 lastPos;

    void Start()
    {
        lastPos = startPos;
        SpawnStep(); // 最初の1段目を生成
    }

    public void SpawnStep()
    {
        // 位置決定
        Vector3 newPos = new Vector3(
            lastPos.x + horizontalOffset,
            lastPos.y + verticalOffset,
            lastPos.z
        );

        Instantiate(cubePrefab, newPos, Quaternion.identity);

        lastPos = newPos;
        stepCount++;
    }
}
*/