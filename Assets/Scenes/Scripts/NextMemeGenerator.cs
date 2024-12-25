using UnityEngine;

public class NextMemeGenerator : MonoBehaviour
{
    const int initGradeCount = 4;

    [SerializeField] private NextMemeUI nextGradeUI;
    [SerializeField] GameObject[] initialGradesPrefabs = new GameObject[initGradeCount];
    private readonly int[] gradeProbabilityTable = new int[initGradeCount];

    public GameObject nextGrade { get; private set; }

    private void Awake()
    {
        InitTable();
        nextGrade = GenerateNextRandomGrade();
    }

    private void InitTable()
    {
        gradeProbabilityTable[0] = 30;
        gradeProbabilityTable[1] = 30;
        gradeProbabilityTable[2] = 25;
        gradeProbabilityTable[3] = 15;
    }

    public GameObject GetNextGrade()
    {
        GameObject nextHoldGrade = nextGrade;
        nextGrade = GenerateNextRandomGrade();
        nextGradeUI.DisplayNextGrade(nextGrade.GetComponent<SpriteRenderer>().sprite, nextGrade.transform.localScale.x);
        return nextHoldGrade;
    }

    private GameObject GenerateNextRandomGrade()
    {
        int randNum = Random.Range(1, 101);

        for (int i = 0; i < initGradeCount; i++)
        {
            if(randNum <= gradeProbabilityTable[i])
            {
                return initialGradesPrefabs[i];
            }
            randNum -= gradeProbabilityTable[i];
        }
        return null;
    }

    private void DebugFunc()
    {
        Debug.Log("next: " + nextGrade.name);
    }

}
