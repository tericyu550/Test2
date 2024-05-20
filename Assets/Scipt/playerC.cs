using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerC : MonoBehaviour
{
    public CharacterController controller;

    public float moveSpeed = 5f;
    public float turnSpeed = 500f;
    public float jumpForce = 5f;
    public float mtfk;
    private float moveInput;
    public float gravity = 9.8f;
    static public float PlayHp = 100f;
    public float PlayerAtkTime;

    static public bool Player_isAttk = false;
    public bool isFire;

    public Animator anim;
    
    public Image PlayHpIMG;
 
    private Rigidbody rb;

    public GameObject knife;
    public GameObject PlayerHpBar;
    public GameObject cameraObj;
    public GameObject Bullet;

    public Transform FirePos;

    public VariableJoystick JoyS;

    private Vector3 moveDirection;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        PlayerHpBar = GameObject.Find("PlayerCanvas");
        cameraObj = GameObject.Find("Main Camera");
       // Bullet = GameObject.Find("bullet");
        FirePos = GameObject.Find("Gun").transform;
        JoyS = FindObjectOfType<VariableJoystick>();
    }
    private void Update()
    {
        PlayerHpBar.transform.LookAt(cameraObj.transform.position);
        PlayHpIMG.fillAmount =PlayHp* 0.01f;

        if (controller.isGrounded)
        {
            PlayerMove();
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
            // transform.Rotate(Vector3.up * turnInput * turnSpeed * Time.deltaTime);
        }
        moveDirection.y -= gravity * Time.deltaTime;          
        controller.Move(moveDirection * Time.deltaTime);// 移動角色

        PlayerAttk();

        if (PlayHp <= 0)
        {
            anim.SetBool("playerdying",true);          
        }
    }
    private void OnCollisionEnter(Collision collision)
    {

    }
   
    void PlayerMove()
    {
        float tunX = Input.GetAxis("Horizontal")+JoyS.Horizontal;
        float moveZ = Input.GetAxis("Vertical")+JoyS.Vertical;
        moveSpeed = Input.GetKey(KeyCode.LeftShift) ? 6 : 2; //當按下左Shift鍵時，verticalInput的值為3，否則為1                                                            //
        anim.SetFloat("Blend", Mathf.Abs(moveZ * moveSpeed));
        // moveDirection = new Vector3(0f, 0f, moveZ);
        moveDirection = transform.TransformDirection(new Vector3(0f, 0f, moveZ) * moveSpeed);
        //moveDirection *= moveSpeed;
        
        transform.Rotate(Vector3.up * tunX * turnSpeed * Time.deltaTime); //處理角色轉向
        moveInput = Input.GetAxis("Vertical");// 處理重力
        if (Input.GetButton("Jump"))
        {
            // rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            anim.SetTrigger("player_jump");
            moveDirection.y = jumpForce;     
        }
    }
    void PlayerAttk()
    {
        PlayerAtkTime = anim.GetFloat("playerAttacktime");
        Player_isAttk = PlayerAtkTime > 0.02f ? true : false;
        
        if (Input.GetKeyDown(KeyCode.G) || isFire==true)
        {
            Instantiate(Bullet, FirePos.position, FirePos.rotation);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetBool("Player_attack", true);
        }
        else
            anim.SetBool("Player_attack", false);
    }

    public void FireButtonDown()
    {
        isFire = true;
    }
    public void FireButtonUp()
    {
        isFire = false;
    }
    //取武器碰撞偵測的function 
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("COIN"))
        {
            // playerPickWeapon = true;
            knife.SetActive(true);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Enemy" && NPC_AI.NPC_isAtk == true && PlayHp>0)
        {
            PlayHp -= 20f;
            print(PlayHp);
        }   
    }
}