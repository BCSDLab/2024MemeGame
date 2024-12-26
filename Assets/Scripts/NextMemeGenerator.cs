using UnityEngine;

public class NextMemeGenerator : MonoBehaviour
{
    const int initMemeCount = 4;

    [SerializeField] private NextMemeUI nextMemeUI;
    [SerializeField] GameObject[] initialMemePrefabs = new GameObject[initMemeCount];
    private readonly int[] memeProbabilityTable = new int[initMemeCount];

    public GameObject nextMeme { get; private set; }
    public GameObject nextG;

    private void Awake()
    {
        InitTable();
        nextMeme = GenerateNextRandomMeme();
    }

    private void Update()
    {
        nextG = nextMeme;
    }

    private void InitTable()
    {
        memeProbabilityTable[0] = 30;
        memeProbabilityTable[1] = 30;
        memeProbabilityTable[2] = 25;
        memeProbabilityTable[3] = 15;
    }

    public GameObject GetNextMeme()
    {
        GameObject nextHoldMeme = nextMeme;
        nextMeme = GenerateNextRandomMeme();
        nextMemeUI.DisplayNextMeme(nextMeme.GetComponent<SpriteRenderer>().sprite, nextMeme.transform.localScale.x);
        return nextHoldMeme;
    }

    private GameObject GenerateNextRandomMeme()
    {
        int randNum = Random.Range(1, 101);

        for (int i = 0; i < initMemeCount; i++)
        {
            if(randNum <= memeProbabilityTable[i])
            {
                return initialMemePrefabs[i];
            }
            randNum -= memeProbabilityTable[i];
        }
        return null;
    }
}
