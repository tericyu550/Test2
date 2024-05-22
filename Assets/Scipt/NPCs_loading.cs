using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCs_loading : MonoBehaviour
{
    public int NPC_num = 5;
    // Start is called before the first frame update
   private void Start()
    {
        NPC_spawner spawner = new NPC_spawner();
        spawner.spawnNPC(100, 2, 1);
    }

    // Update is called once per frame
    void Update()
    {
        //float num = Random.Range(0, 100f);        
        //if (NPC_num < 6 && num >99)
        //  {
        //    GameObject NPCs = Instantiate(Resources.Load("NPC1", typeof(GameObject))) as GameObject;
        //    NPCs.transform.position = NPCs.transform.position + new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f));
        //    NPC_num += 1;
        //}
    }

}

public class NPC_spawner : MonoBehaviour
{
    public void spawnNPC(float hp,float WalkSpeed,int NPC_AttkPower)
    {
        GameObject NPCs = Instantiate(Resources.Load("NPC1", typeof(GameObject))) as GameObject;
        NPC_AI NPC_Crtl = NPCs.GetComponent<NPC_AI>();
    }
}