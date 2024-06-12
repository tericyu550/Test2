using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhostBomb : MonoBehaviour
{
    NavMeshAgent GhostNavi;

    public GameObject TargetObj;
    public GameObject explosion;

    public int DetectDistance = 10;
    public float ExposionRadius = 2.5f;
    public float ExposionTime = 5f;
    public float BombHunNum = 2000f;

    public bool isExposion = false;

    CapsuleCollider GhostBombCollider;
   
    // Start is called before the first frame update
    void Start()
    {
        GhostNavi = GetComponent<NavMeshAgent>();
        TargetObj = GameObject.Find("player");
        GhostBombCollider = GetComponent<CapsuleCollider>();
        Invoke("BombExposion", ExposionTime);
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, TargetObj.transform.position);
        if (dist < DetectDistance && playerC.PlayHp > 0)
        {
            GhostNavi.destination = TargetObj.transform.position;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && isExposion)
        {
            playerC.PlayHp -= (BombHunNum / 200);
            isExposion = false;
        }
    }
    private void BombExposion()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        isExposion = true;

        for (float r = 0.001f; r < ExposionRadius; r += 0.2f)
            GhostBombCollider.radius = r;
        Destroy(this.gameObject, 0.2f);
    }
}
