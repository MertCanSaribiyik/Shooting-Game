using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] private Transform firstPoint, lastPoint;
    private Rigidbody rb;
    private int jumpCount;

    //Variables for animation : 
    [SerializeField] private Animator animator;
    [SerializeField] private string idleAnim, rightMovingAnim, leftMovingAnim;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            jumpCount = 0;
        }
    }

    private void Update() {
        Move();
        Jump();
    }

    //The character moving in a certain range of position : 
    private void Move() {
        float moveHorizontal = Input.GetAxis("Horizontal") * Player.Instance.Speed * Time.deltaTime;

        MoveAnimation(moveHorizontal);

        //Movement : 
        rb.velocity = new Vector3(moveHorizontal, rb.velocity.y, rb.velocity.z);

        //Certain range of position : 
        float xPos = Mathf.Clamp(transform.position.x, firstPoint.position.x, lastPoint.position.x);
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
    }

    //Character can jump up to maxJump : 
    private void Jump() {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < Player.Instance.MaxJumpCount) {
            rb.AddForce(0f, Player.Instance.JumpForce, 0f);
            jumpCount++;
        }
    }

    private void MoveAnimation(float move) {
        //Idle animation : 
        if (move == 0f) {
            animator.SetBool(idleAnim, true);
            animator.SetBool(rightMovingAnim, false);
            animator.SetBool(leftMovingAnim, false);
        }

        //Right moving animation : 
        else if (move > 0f) {
            animator.SetBool(rightMovingAnim, true);
            animator.SetBool(idleAnim, false);
            animator.SetBool(leftMovingAnim, false);
        }

        //Left moving animation : 
        else {
            animator.SetBool(leftMovingAnim, true);
            animator.SetBool(idleAnim, false);
            animator.SetBool(rightMovingAnim, false);
        }
    }

}
