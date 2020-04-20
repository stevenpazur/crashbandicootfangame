using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{

    public GameObject destroyedVersion;

    public GameObject wumpa;

    public AudioSource boxBreak;

    //public PlayerControls ps;

    public bool enteredJumper;

    private void Start()
    {
        //ps = FindObjectOfType<PlayerControls>();
        
    }

    public void BreakBox(int id)
    {
        boxBreak.Play();
        Instantiate(destroyedVersion, transform.position, Quaternion.identity);
        Destroy(gameObject);
        spawn();
    }

    void spawn()
    {
        int spawnNum = Random.Range(2, 8);

        for (int i = 0; i < spawnNum; i++)
        {
            Vector3 spawnLoc = new Vector3(this.transform.position.x + Random.Range(-0.1f, 0.1f),
                                           this.transform.position.y + Random.Range(-0.1f, 0.1f),
                                           this.transform.position.z + Random.Range(-0.1f, 0.1f));
            Instantiate(wumpa, spawnLoc, Quaternion.identity);
        }
    }
}
