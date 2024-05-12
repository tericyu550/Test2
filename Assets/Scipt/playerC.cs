using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerC : MonoBehaviour
{
    public CharacterController controller;
    public float moveSpeed = 5f;
    public float turnSpeed = 200f;
    public float jumpForce = 5f;
    public float mtfk;
 //  private bool isJumping = false;
  //  private bool groundedPlayer = false;
    private Rigidbody rb;
    private float moveInput;
    public Animator anim;
    public GameObject knife;
    public float gravity = 9.8f;
    public float PlayHp = 100f;
    public Image PlayHpIMG;
    public float PlayerAtkTime;
    public float op;
    static public bool Player_isAttk = false;

    private Vector3 moveDirection;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();      
    }
    private void Update()
    {
        PlayHpIMG.fillAmount =PlayHp* 0.01f;

        if (controller.isGrounded)
        {
            float tunX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");
            moveSpeed = Input.GetKey(KeyCode.LeftShift) ? 6 : 2; //當按下左Shift鍵時，verticalInput的值為3，否則為1  
            //Debug.Log(moveSpeed);          
            anim.SetFloat("Blend", Mathf.Abs(moveZ * moveSpeed));
           // PlayHpIMG.fillAmount = PlayHp * 0.1f;
            // 計算移動方向
           // moveDirection = new Vector3(0f, 0f, moveZ);
            moveDirection = transform.TransformDirection(new Vector3(0f, 0f, moveZ)* moveSpeed);
            //moveDirection *= moveSpeed;
            //處理角色轉向
            transform.Rotate(Vector3.up * tunX * turnSpeed * Time.deltaTime); // 
                                                                              // Move forward and backward
            moveInput = Input.GetAxis("Vertical");
            // 處理重力


            //if (Input.GetKey(KeyCode.LeftShift)&& Input.GetAxisRaw("Vertical")!=0 )
            //{
            //    transform.Translate(Vector3.forward * moveInput * moveSpeed * Time.deltaTime * 2f);
            //    anim.SetFloat("Blend", 2);
            //}
            //else
            //{
            //    transform.Translate(Vector3.forward * moveInput * moveSpeed * Time.deltaTime);
            //    anim.SetFloat("Blend", moveInput);
            //}

            //// Turn left and right
            //float turnInput = Input.GetAxis("Horizontal");

            // transform.Rotate(Vector3.up * turnInput * turnSpeed * Time.deltaTime);


            // Jump
            if (Input.GetButton("Jump"))
            {
                // rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                anim.SetTrigger("player_jump");
                moveDirection.y = jumpForce;

                // anim.SetTrigger("player_jp");
            }

           
        }
        PlayerAtkTime = anim.GetFloat("playerAttacktime");
        Player_isAttk = PlayerAtkTime > 0.02f ? true : false;
        moveDirection.y -= gravity * Time.deltaTime;
            // 移動角色
        controller.Move(moveDirection * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetBool("Player_attack", true);
        }
        else
            anim.SetBool("Player_attack", false);
        if (PlayHp <= 0)
        { 
        
        
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Reset jump state when touching the ground
        //if (collision.gameObject.CompareTag("Ground"))
        //{
        //    isJumping = false;
        //}
    }
    void playerAttack()
    {
       
        StartCoroutine("attack");

    }
    IEnumerator attack()
    {
        
        yield return new WaitForSeconds(2f);
    }
    
    // private void OnTriggerEnter(Collider other)
    // {
    //     print("OnTriggerEnter");
    //     if(other.CompareTag("COIN"))
    //     {
    //         Destroy(other.gameObject);
    //     }
    // }
    //取武器碰撞偵測的function 
    private void OnTriggerEnter(Collider other)
    {
       // print("OnTriggerEnter"); //當物件進入觸發區時，印出OnTriggerEnter
        // if (other.CompareTag("weapon"))
        // {
        //    // playerPickWeapon = true;
        //     sword.SetActive(true); 
        //     Destroy(other.gameObject); // 刪除進入觸發區的物件
        // }
        if(other.CompareTag("COIN"))
        {
            // playerPickWeapon = true;
            knife.SetActive(true);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Enemy" && NPC_AI.NPC_isAtk == true && PlayHp>0)
        {
            PlayHp -= 10f;
            print(PlayHp);
        }
     
    }
}