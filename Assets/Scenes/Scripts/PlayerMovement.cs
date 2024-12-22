using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    private float rightMaxDistance;
    private float leftMaxDistance;
    [SerializeField] private float moveSpeed;

    [SerializeField] private HolderController holder;
    [SerializeField] private GameObject pauseUI;


    public static bool isPaused { get; private set; }

    private Vector2 moveDir = Vector2.zero;

    private void Start()
    {
        rightMaxDistance = 3.1f;
        leftMaxDistance = -2.1f;

    }

    private void Update()
    {
        if(isPaused) { return; }
        Move();
    }

    private void Move()
    {
        Vector2 currSpeed = moveDir * moveSpeed * Time.deltaTime;
        transform.position += new Vector3(currSpeed.x, currSpeed.y, 0);
        if(transform.position.x >= rightMaxDistance)
        {
            transform.position = new Vector3(rightMaxDistance, transform.position.y, 0);
        }
        else if (transform.position.x <= leftMaxDistance)
        {
            transform.position = new Vector3(leftMaxDistance, transform.position.y, 0);
        }
    }

    public void OnMove(InputValue value)
    {
        moveDir = value.Get<Vector2>();
    }

    public void OnDrop()
    {
        holder.DropGrade();
    }

    public void OnPause()
    {
        isPaused = !isPaused;
        if(isPaused)
        {
            pauseUI.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseUI.SetActive(false);
            Time.timeScale = 1f;
        }
    }



}
