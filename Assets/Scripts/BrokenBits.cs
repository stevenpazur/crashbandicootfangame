using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenBits : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("destroyBits", 0.3f);
    }

    void destroyBits()
    {
        this.GetComponent<SkinnedMeshRenderer>().enabled = false;
    }
}
