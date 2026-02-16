using UnityEngine;
using System.Collections.Generic;

public class Stairs : MonoBehaviour
{
    [Header("äKíiPrefab")]
    [SerializeField]
    private GameObject stairsObject;

    [Header("äKíiêî")]
    [SerializeField]
    private int totalStairs = 100;

    [Header("ä‘äu")]
    [SerializeField]
    private float intervalX = 1f;

    [SerializeField]
    private float intervalY = 1f;

    private List<Vector3> stairPositions = new List<Vector3>();

    private void Start()
    {
        GenerateStairs();
    }

    void GenerateStairs()
    {
        for (int i = 0; i < totalStairs; i++)
        {
            Vector3 pos = new Vector3(
                i * intervalX,
                i * intervalY,
                0
            );

            Instantiate(stairsObject, pos, Quaternion.identity);
            stairPositions.Add(pos);
        }
    }

    //äKíiÇÃç¿ïWÇéÊìæ
    public Vector3 GetStepPosition(int index)
    {
        if (index < 0 || index >= stairPositions.Count)
            return Vector3.zero;

        return stairPositions[index];
    }
}
