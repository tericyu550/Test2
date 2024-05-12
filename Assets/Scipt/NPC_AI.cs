using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
public class NPC_AI : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent npcNavi;
    public GameObject TargetObj;
    public Animator NPC01_ani;
    public int DetectDistance = 10;
    public float AttkDistance = .9f;
    public float NPC_HP = 100f;
    static public bool NPC_isAtk = false;
    public float NPC_AtkTime;


    void Start()
    {

        npcNavi = GetComponent<NavMeshAgent>();
        NPC01_ani = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, TargetObj.transform.position);

        float NPC_Speed = npcNavi.velocity.magnitude;   // ���oNPC���t��. 
       
        if (dist < DetectDistance) // ����NPC�M���a�������Z��, �p�b�ҳ]�w���Z����, �}�l�l��
        {
            npcNavi.destination = TargetObj.transform.position;
            NPC01_ani.SetFloat("Blend", 1);
        }
        else // �S������, �h�l�ܦۤv �Τ]�i�H�令�^��NPC�������m. 
        {
            npcNavi.destination = transform.position;
            NPC01_ani.SetFloat("Blend", 0);
        }
        if (dist < AttkDistance)
        {
            NPC01_ani.SetBool("NPC_ATK", true);
        }
        else
        {
            NPC01_ani.SetBool("NPC_ATK", false);
        }
        if (NPC_HP <= 0)
        {
            NPC01_ani.SetBool("NPC_Die", true);
            Destroy(gameObject, 5);
        }
        NPC_AtkTime = NPC01_ani.GetFloat("NPC_AtkTtime");
        NPC_isAtk = NPC01_ani.GetFloat("NPC_AtkTtime") > 0.006 ? true : false;
        
    }


    private void OnTriggerEnter(Collider Hit)
    {
        if (Hit.gameObject.tag == "weapon" && NPC_HP > 0&& playerC.Player_isAttk==true)
        {
            NPC_HP -= 50;
        }
    }

    //NavMeshAgent NPCNav;
    //public GameObject TargetObj;
    //void Start()
    //{
    //    NPCNav = GetComponent<NavMeshAgent>();

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    NPCNav.destination = TargetObj.transform.position;
    //}
}
