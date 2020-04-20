using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wumpaCollect : MonoBehaviour
{

    public AudioSource collectSound;

    private void OnTriggerEnter(Collider col)
    {
        //collectSound.Play();
        //ScoringSystem.theScore += 1;
        //Destroy(gameObject);
    }

}
