using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombing : MonoBehaviour
{
    public float ExposionRadius = 5f;
    public float ExposionTime = 3f;
    public float BombHunNum = 3000f;

    public bool isExposion = false;

    SphereCollider BombCollider;

    public GameObject BombObj;
    public GameObject Magi;
    // Start is called before the first frame update
    void Start()
    {
        BombObj = GameObject.Find("BombTop");       
        BombCollider = GetComponent<SphereCollider>();
        Invoke("BombExposion", ExposionTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void BombExposion()
    {
        Instantiate(Magi,transform.position,transform.rotation);
        isExposion = true;
        BombObj.GetComponent<MeshRenderer>().enabled = false;
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        for (float r = 0.001f; r < ExposionRadius; r += 0.2f)
            BombCollider.radius = r;
        Destroy(gameObject,5);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NPC" && isExposion)
        {
            NPC_AI npc = other.gameObject.GetComponent<NPC_AI>();
            npc.NPC_HP -= BombHunNum;

            //isExposion = false;

            print("ooo");
        }
        if (other.gameObject.tag == "Player" && isExposion)
        {
            playerC.PlayHp -= BombHunNum;
           // isExposion = false;
        }
    }
}
