using Unity.Mathematics;
using UnityEngine;

public class Player : Block
{

    [SerializeField]
    private Animator myAnim;
    void start()
    {

    }
    private void Update()
    {

        if (State == MoveStates.idle) MoveInput();
    }

    private void MoveInput()
    {

        Vector3 forward = transform.forward;
        forward.y = 0f;

        Vector3 right = transform.right;
        right.y = 0f;

        int deltaX = 0;
        int deltaY = 0;

        if (Input.GetKey(KeyCode.A))
        {
            if (Mathf.Abs(forward.x) > Mathf.Abs(forward.z))
                deltaY = forward.x > 0f ? -1 : 1;
            else
                deltaX = forward.z > 0f ? -1 : 1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (Mathf.Abs(forward.x) > Mathf.Abs(forward.z))
                deltaY = forward.x > 0f ? 1 : -1;
            else
                deltaX = forward.z > 0f ? 1 : -1;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            if (Mathf.Abs(right.x) > Mathf.Abs(right.z))
                deltaY = right.x > 0f ? -1 : 1;
            else
                deltaX = right.z > 0f ? -1 : 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (Mathf.Abs(right.x) > Mathf.Abs(right.z))
                deltaY = right.x > 0f ? 1 : -1;
            else
                deltaX = right.z > 0f ? 1 : -1;
        }
        else
        {
            return;
        }

        CheckMove(deltaX, deltaY);
        // Vector3 dir = Vector3.zero;

        // if (Input.GetKey(KeyCode.W))
        //     dir = transform.right;
        // else if (Input.GetKey(KeyCode.S))
        //     dir = -transform.right;
        // else if (Input.GetKey(KeyCode.D))
        //     dir = -transform.forward;
        // else if (Input.GetKey(KeyCode.A))
        //     dir = transform.forward;

        // if (dir == Vector3.zero) return;

        // dir.y = 0f;
        // dir.Normalize();

        // int deltaX = 0;
        // int deltaY = 0;

        // if (Mathf.Abs(dir.x) > Mathf.Abs(dir.z))
        // {
        //     deltaY = dir.x > 0f ? -1 : 1;
        // }
        // else
        // {
        //     deltaX = dir.z > 0f ? -1 : 1;
        // }

        // CheckMove(deltaX, deltaY);

        // if (Input.GetKey(KeyCode.A))
        // {
        //     if (CheckMove(-1, 0)) transform.rotation = Quaternion.LookRotation(Vector3.left);
        // }
        // else if (Input.GetKey(KeyCode.D))
        // {
        //     if (CheckMove(1, 0)) transform.rotation = Quaternion.LookRotation(Vector3.right);
        // }
        // else if (Input.GetKey(KeyCode.W))
        // {
        //     if (CheckMove(0, -1)) transform.rotation = Quaternion.LookRotation(Vector3.back);
        // }
        // else if (Input.GetKey(KeyCode.S))
        // {
        //     if (CheckMove(0, 1)) transform.rotation = Quaternion.LookRotation(Vector3.forward);
        // }
    }

    protected override void StartMove(Cell newParent, int _deltaX, int _deltaY)
    {
        myAnim.SetBool("isMoving", true);
        base.StartMove(newParent, _deltaX, _deltaY);
    }

    protected override void FinishMove()
    {
        myAnim.SetBool("isMoving", false);
        base.FinishMove();
    }

}
