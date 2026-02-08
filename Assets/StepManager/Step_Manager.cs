using UnityEngine;

public class StepManager : MonoBehaviour
{
    [Header("敵出現設定")]
    [SerializeField] private int enemyInterval = 20;
    [SerializeField] private int bossStep = 100;

    public int CurrentStep { get; private set; }

    public void AddStep(int value = 1)
    {
        CurrentStep += value;

        if (CurrentStep == bossStep)
        {
            Debug.Log("ボス出現！");
        }
        else if (CurrentStep % enemyInterval == 0)
        {
            Debug.Log("敵出現！");
        }
    }

    public void ResetStep()
    {
        CurrentStep = 0;
        Debug.Log("一番下に落ちた");
    }
}
