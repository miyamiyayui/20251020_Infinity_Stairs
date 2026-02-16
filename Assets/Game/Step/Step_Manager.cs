using UnityEngine;

public class Step_Manager : MonoBehaviour
{
    [Header("===== äKíiê›íË =====")]
    [SerializeField] private int totalSteps = 100;
    [SerializeField] private int enemyInterval = 10;
    [SerializeField] private int bossFloor = 100;

    [Header("===== éQè∆ =====")]
    [SerializeField] private Stairs stairs;

    [Header("===== ìGPrefab =====")]
    [SerializeField] private Enemy_Status enemyPrefab;
    [SerializeField] private Enemy_Status bossPrefab;

    private int currentStep = 0;

    public void AddStep()
    {
        if (currentStep >= totalSteps) return;

        currentStep++;

        SpawnEnemyIfNeeded(currentStep);
    }

    public void ResetStep()
    {
        currentStep = 0;
    }

    void SpawnEnemyIfNeeded(int floor)
    {
        Enemy_Status prefab = null;

        // É{ÉX
        if (floor == bossFloor)
        {
            prefab = bossPrefab;
        }
        // éGãõ
        else if (floor % enemyInterval == 0)
        {
            prefab = enemyPrefab;
        }

        if (prefab == null) return;

        Vector3 pos = stairs.GetStepPosition(floor - 1);

        Enemy_Status enemy =
            Instantiate(prefab, pos, Quaternion.identity);

        enemy.Initialize(floor);

        Debug.Log("ìGèoåªÅIäKíiÅF" + floor);
    }
}
