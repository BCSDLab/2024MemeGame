using UnityEngine;

public class NextGradeGenerator : MonoBehaviour
{
    const int initGradeCount = 4;

    [SerializeField] GameObject[] initialGradesPrefabs = new GameObject[initGradeCount];
    private int[] gradeTable = new int[initGradeCount];

    private GameObject currentNextGrade;

    private void Start()
    {
        InitTable();
        currentNextGrade = setNextRandomGrade();
    }

    private void InitTable()
    {
        gradeTable[0] = 30;
        gradeTable[1] = 30;
        gradeTable[2] = 25;
        gradeTable[3] = 15;
    }

    public GameObject GetNextGrade()
    {
        GameObject nextGrade = currentNextGrade;
        currentNextGrade = setNextRandomGrade();
        Debug.Log("current: " + nextGrade.name + " / next: " + currentNextGrade.name);
        return nextGrade;
    }

    private GameObject setNextRandomGrade()
    {
        int randNum = Random.Range(1, 101);

        for (int i = 0; i < initGradeCount; i++)
        {
            if(randNum <= gradeTable[i])
            {
                return initialGradesPrefabs[i];
            }
            randNum -= gradeTable[i];
        }
        return null;
    }


}
