using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Boss_AI : MonoBehaviour
{
    NavMeshAgent BossNavi;
    public enum Status { Idle, Walk,Attack };
    public enum ATKmode {CallGhost,FireMagic };
    public Status status;
    public ATKmode Amod;
    public GameObject TargetObj;
    public GameObject MagiGhoht;
    public GameObject MagicObj;

    public Transform BossTrans;

    public Animator Boss_ani;

    public float Boss_MaxHP = 500f;
    public float Boss_HP;
    public int DetectDistance = 10;
    public float atktime = 5;
    public float AttkDistance = 3.1f;
    void Start()
    {
        TargetObj = GameObject.Find("player");
        BossNavi = GetComponent<NavMeshAgent>();
        Boss_ani = GetComponent<Animator>();
        BossTrans = GetComponent<Transform>();
        status = Status.Idle;
        Amod = ATKmode.CallGhost;
    }

    // Update is called once per frame
    void Update()
    {
        BossState();
        
    }

    private void BossState()
    {
        float dist = Vector3.Distance(transform.position, TargetObj.transform.position);
        switch (status)
        {
            case Status.Idle:
                if (dist > DetectDistance)
                {
                    BossNavi.destination = transform.position;
                    Boss_ani.SetFloat("Blend", 0);
                }
                else
                    status = Status.Walk;
                break;
            case Status.Walk:
                if (dist < DetectDistance && playerC.PlayHp > 0 && dist > AttkDistance)
                {
                    BossNavi.destination = TargetObj.transform.position;
                    Boss_ani.SetFloat("Blend", 1);                   
                }
                else 
                    status = Status.Attack;
                break;
            case Status.Attack:
                Boss_ani.SetFloat("Blend", 0);
                CheckMode();
                atktime += Time.deltaTime;
                switch (Amod)
                {
                    case ATKmode.CallGhost:
                        if(atktime>=5)
                            callGhost();
                        break;
                    case ATKmode.FireMagic:
                        if (atktime >= 5)
                            fireMagic();
                        break;
                }
                break;
        }
    }

    private void callGhost()
    {
        Boss_ani.SetTrigger("BossCall");
        for (int num = 0; num < 3; num++)
        {
            float r = Random.Range(-5f, 5f);
            float r2 = Random.Range(-5f, 5f);
            Vector3 pos = new Vector3(BossTrans.position.x + r, BossTrans.position.y, BossTrans.position.z + r2);
            Instantiate(MagiGhoht, pos, transform.rotation);
        }
        atktime = 0;  
    }
    private void fireMagic()
    {
        Vector3 pos = new Vector3(TargetObj.transform.position.x , BossTrans.position.y, TargetObj.transform.position.z);
        Instantiate(MagicObj, pos, transform.rotation);
        atktime = 0;
    }

    private void CheckMode()
    {
        float r = Random.Range(0f, 100f);
        if (r > 70)
            Amod = ATKmode.CallGhost;
        else
            Amod = ATKmode.FireMagic;
    }

}

