using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public LayerMask solidObjectsLayer;
    public LayerMask grassLayer;

    private bool isMoving;
    private Vector2 input;
    private Animator animator;

    private void Awake(){
        animator = GetComponent<Animator>();
    }

    private void Update() {
        if (!isMoving){
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            // remove diagonal movement
            if(input.x != 0) input.y = 0;

            if (input != Vector2.zero)
            {
                // idle animation 적용
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                // 조건문을 추가해서 IsWalkable함수로 
                // solidObjectsLayer가 있다면 감지하여 
                // false를 return하고 그러면 부딪히게 됨
                if(IsWalkable(targetPos))
                    StartCoroutine(Move(targetPos));

                // StartCoroutine(Move(targetPos));
            }
        }
        // moving animation 적용
        animator.SetBool("isMoving", isMoving);
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;

        isMoving = false;

        CheckforEncounters();
    }

    private bool IsWalkable(Vector3 targetPos)
    {
        // Physics2D.OverlapCircle는 해당 위치 targetPos에 0.2f 반지름 안에, solidObjectLayer가 있는지 여부를 확인하는 함수
        if(Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectsLayer) != null)
        {   
            // null이 아니라면 객체가 감지되는 것이므로 false를 반환
            return false;
        } 
        // solidObjectsLayer에 해당하는 어떤 객체도 없다면 즉, 아무 객체도 감지되지 않는다면 true를 반환
        return true;
    }

    private void CheckforEncounters(){
        // Transform.position은 게임오브젝트의 절대좌표
        if(Physics2D.OverlapCircle(transform.position, 0.2f, grassLayer) != null)
        {
            if (Random.Range(1,101) <= 10)
            {
                Debug.Log("Wild Pokemon");
            }
        }

    }
}
