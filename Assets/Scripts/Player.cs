using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private GameObject bulletPrefab;
    private Rigidbody rb;

    //Variables for movement : 
    public float speed;
    [SerializeField] private Transform firstPoint;
    [SerializeField] private Transform lastPoint;

    //Variables for jumping : 
    [SerializeField] private float jumpForce;
    [SerializeField] private int maxJump;
    private int jumpCount;

    //Variables for animation : 
    [SerializeField] private Animator animator;
    [SerializeField] private string idleAnim;
    [SerializeField] private string rightMovingAnim;
    [SerializeField] private string leftMovingAnim;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        if(Input.GetMouseButtonDown(0)) {
            Shoot();
        }

        Move();
        Jump();
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            jumpCount = 0;
        }
    }

    private void Shoot() {
        Instantiate(bulletPrefab, transform.position + new Vector3(0.35f, 1f, 1f), transform.rotation);
    }

    //The character moving in a certain range of position : 
    private void Move() {
        float moveHorizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        MoveAnimation(moveHorizontal);

        //Movement : 
        rb.velocity = new Vector3(moveHorizontal, rb.velocity.y, rb.velocity.z);

        //Certain range of position : 
        float xPos = Mathf.Clamp(transform.position.x, firstPoint.position.x, lastPoint.position.x);
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
    }

    //Character can jump up to maxJump : 
    private void Jump() {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJump) {
            rb.AddForce(0f, jumpForce, 0f);
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