using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float rightMaxDistance;
    public float leftMaxDistance;
    public float moveSpeed;
    [SerializeField] private HolderController holder;

    private Vector2 moveDir = Vector2.zero;

    private void Awake()
    {
    }

    private void Update()
    {
        Vector2 currSpeed = moveDir * moveSpeed * Time.deltaTime;
        transform.position += new Vector3(currSpeed.x, currSpeed.y, 0);
    }

    public void OnMove(InputValue value)
    {
        moveDir = value.Get<Vector2>();
    }

    public void OnDrop(InputValue value)
    {
        holder.DropGrade();
    }
}
