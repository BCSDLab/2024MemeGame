using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.XR;

public class ObjectMerge : MonoBehaviour
{
    [SerializeField] private int level = 0;
    [SerializeField] private int score = 0;

    private static int maxLevel = 8;
    public bool isCollided {  get; private set; }
    private bool isMerge = false;

    [SerializeField] private GameObject nextLevelObjectPrefab;

    public delegate void IsCollidedChanged();
    public static event IsCollidedChanged OnIsCollidedChanged;

    public delegate void scoreChaged(int score);
    public static event scoreChaged OnScoreChanged;

    private void Awake()
    {
        //TextMeshPro text = GetComponentInChildren<TextMeshPro>().GetComponent<TextMeshPro>();
        //Stext.text = this.name.Split('(')[0];
    }


    private void SetIsMergeTrue() { isMerge = true; }

    private void InstantiateNextLevelObject(ObjectMerge other)
    {
        SetIsMergeTrue();
        other.SetIsMergeTrue();

        //�� ��ü ������ �߰� ���� ��ǥ ���ϱ�
        Vector3 middleLocation = (this.transform.position + other.transform.position) / 2;
        Destroy(other.gameObject);

        //�� ��ü ����
        GameObject newGrade = Instantiate(nextLevelObjectPrefab, middleLocation, Quaternion.identity);
        newGrade.GetComponent<ObjectMerge>().isCollided = true;
        //�� ��ü ����
        Destroy(gameObject);
    }

    private void ProcessGameClear()
    {
        Debug.Log("Game Clear!");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(isCollided == false)
        {
            isCollided = true;
            OnIsCollidedChanged?.Invoke();
        }

        ObjectMerge other = collision.gameObject.GetComponent<ObjectMerge>();

        if(other != null)      //Ÿ�� üũ
        {
            if ((this.level == other.level) && (level < maxLevel) && !isMerge && !other.isMerge)      //�浹 ���� üũ
            {
                if (this.transform.position.x < other.transform.position.x 
                    || this.transform.position.y < other.transform.position.y)    //�� ������Ʈ�� �غ�
                {
                    OnScoreChanged?.Invoke(score * 2);
                    InstantiateNextLevelObject(other);
                }
            }
        }
    }
}
