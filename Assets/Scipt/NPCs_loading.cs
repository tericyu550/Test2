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
        spawner.spawnNPC(100f, 2f, 10);
        NPC_spawner spawner2 = new NPC_spawner();
        spawner2.spawnNPC(200f, 4f, 20);
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
    public void spawnNPC(float hp,float WalkSpeed,int AttkPower)
    {
        GameObject NPCs = Instantiate(Resources.Load("NPC1", typeof(GameObject))) as GameObject;
        NPC_AI NPC_Crtl = NPCs.GetComponent<NPC_AI>();
        NPC_Crtl.NPC_MaxHP = hp;
        NPC_Crtl.NPC_WalkSpeed = WalkSpeed;
        NPC_Crtl.NPC_AttkPower = AttkPower;
    }
}