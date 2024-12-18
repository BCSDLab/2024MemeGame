using System.Collections;
using UnityEngine;
using UnityEngine.XR;

public class ObjectMerge : MonoBehaviour
{
    [SerializeField] private int level = 0;

    private static int maxLevel = 8;
    private bool isCollided = false;
    private bool isMerge = false;

    [SerializeField] private GameObject nextLevelObjectPrefab;

    private Rigidbody2D rb;

    public delegate void IsCollidedChanged();
    public static event IsCollidedChanged OnIsCollidedChanged;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public bool IsCollided
    {
        get { return isCollided; }
        private set 
        { 
            isCollided = value; 
            if(value == true)
                OnIsCollidedChanged?.Invoke();
        }
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
        newGrade.GetComponent<ObjectMerge>().IsCollided = true;
        newGrade.GetComponent<CircleCollider2D>().enabled = true;
        newGrade.GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.NeverSleep;
        //�� ��ü ����
        Destroy(gameObject);
    }

    private void ProcessGameClear()
    {
        Debug.Log("Game Clear!");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsCollided = true;

        ObjectMerge other = collision.gameObject.GetComponent<ObjectMerge>();

        if(other != null)      //Ÿ�� üũ
        {
            if ((this.level == other.level) && (level < maxLevel) && !isMerge && !other.isMerge)      //�浹 ���� üũ
            {
                if (this.transform.position.x < other.transform.position.x 
                    || this.transform.position.y < other.transform.position.y)    //�� ������Ʈ�� �غ�
                {
                    Debug.Log("3");
                    InstantiateNextLevelObject(other);
                }
            }
        }
    }
}
