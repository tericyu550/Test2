using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    public Rigidbody BullteRig;
    // Start is called before the first frame update
    void Start()
    {
        BullteRig = GetComponent<Rigidbody>();
        BullteRig.AddForce(transform.forward * 1000f);
        Destroy(this.gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
