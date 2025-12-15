using UnityEngine.Pool;
using UnityEngine;
using System.Collections.Generic;
using System.Threading;

public class Stairs : MonoBehaviour
{
    //====== 階段 ======
    //階段のprefab
    [Header("階段のprefab入れる場所")]
    [SerializeField]
    private GameObject stairsObject;

    //最初に用意しておくprefab数
    [Header("最初から用意しておく階段のprefabの数")]
    [SerializeField]
    private int startStairs = 20;

    //階段の間隔
    [Header("階段の間隔設定")]
    [SerializeField]
    private int IntervalStairs = 1;

    //階段をループするやつ
    private ObjectPool<GameObject> stairsPool;
    //階段の数を管理するリスト
    private List<GameObject> activeStairs = new List<GameObject>();

    private void Awake()
    {
        //============================
        //   階段ブロックのプール作成
        //============================
        stairsPool = new ObjectPool<GameObject>(
            createFunc: () =>
            {
                // 新しく階段ブロックを作る
                var obj = Instantiate(stairsObject);
                obj.SetActive(false);                       // まずは非表示
                return obj;
            },
            actionOnGet: obj => obj.SetActive(true),        // 取り出したら表示
            actionOnRelease: obj => obj.SetActive(false),   // 返したら非表示
            actionOnDestroy: obj => Destroy(obj),           // 最大サイズ超えたら破棄
            collectionCheck: false,
            defaultCapacity: 3,                            // 最初に20個作っておく
            maxSize: 100                                    // 最大100個まで管理
        );
    }

    private void Start()
    {
        GenerateStairs(startStairs);
    }

    
    public void GenerateStairs;
    {
        for (int i = 0; i < count; i++)
        
        
    }

    public void RemoveStairs;
    {

    }
}
