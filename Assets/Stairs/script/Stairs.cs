using UnityEngine;
using UnityEngine.Pool;
using System.Collections.Generic;

public class Stairs : MonoBehaviour
{
    //====== 階段 ======
    [Header("階段のPrefab（1x1キューブ）")]
    [SerializeField]
    private GameObject stairsObject;

    [Header("最初に用意しておく階段の数")]
    [SerializeField]
    private int startStairs = 20;

    [Header("階段の間隔（右・上）")]
    [SerializeField]
    private float intervalX = 1f;
    [SerializeField]
    private float intervalY = 1f;

    //プール
    private ObjectPool<GameObject> stairsPool;

    //使用中の階段
    private List<GameObject> activeStairs = new List<GameObject>();

    //今何段目か
    private int currentIndex = 0;

    private void Awake()
    {
        stairsPool = new ObjectPool<GameObject>(
            createFunc: () =>
            {
                var obj = Instantiate(stairsObject);
                obj.SetActive(false);
                return obj;
            },
            actionOnGet: obj => obj.SetActive(true),
            actionOnRelease: obj => obj.SetActive(false),
            actionOnDestroy: obj => Destroy(obj),
            collectionCheck: false,
            defaultCapacity: startStairs,
            maxSize: 200
        );
    }

    private void Start()
    {
        //最初の階段を生成
        GenerateStairs(startStairs);
    }

    //指定数だけ階段を生成
    public void GenerateStairs(int count)
    {
        for (int i = 0; i < count; i++)
        {
            SpawnOneStair();
        }
    }
    //階段を1段だけ生成 <= Player から呼ぶ
    public void SpawnOneStair()
    {
        GameObject stair = stairsPool.Get();

        stair.transform.position = new Vector3(
            currentIndex * intervalX,
            currentIndex * intervalY,
            0
        );

        activeStairs.Add(stair);
        currentIndex++;
    }
    // 全階段を消す（リセット用）
    public void RemoveStairs()
    {
        foreach (var stair in activeStairs)
        {
            stairsPool.Release(stair);
        }

        activeStairs.Clear();
        currentIndex = 0;
    }
}
