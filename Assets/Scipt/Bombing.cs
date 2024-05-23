using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombing : MonoBehaviour
{
    public float ExposionRadius = 5f;
    public float ExposionTime = 3f;
    public int BombHunNum = 100;

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
        Instantiate(Magi);
        BombObj.GetComponent<MeshRenderer>().enabled = false;
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        for (float r = 0.05f; r < ExposionRadius; r += 0.2f)
            BombCollider.radius = r;
    }
}
