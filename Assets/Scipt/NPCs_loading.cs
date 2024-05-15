using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCs_loading : MonoBehaviour
{
    public int NPC_num = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float num = Random.Range(0, 100f);        
        if (NPC_num < 6 && num >99)
          {
            GameObject NPCs = Instantiate(Resources.Load("NPC1", typeof(GameObject))) as GameObject;
            NPCs.transform.position = NPCs.transform.position + new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f));
            NPC_num += 1;
        }
       

    }
}
