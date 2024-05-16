using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailRenderTime : MonoBehaviour
{
    public TrailRenderer SwordTrailTime;
    void Start()
    {
        SwordTrailTime = GetComponent<TrailRenderer>();
        SwordTrailTime.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerC.Player_isAttk)
        {
            //SwordTrailTime.time = 1;
            SwordTrailTime.enabled = true;
        }
        else          
        {
           // SwordTrailTime.time = 0;
            SwordTrailTime.enabled = false;
        }
    }
}
