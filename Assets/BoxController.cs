using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{

    BoxScript bs;

    public int id;

    private void Awake()
    {
        bs = gameObject.GetComponent<BoxScript>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Trigger.onDoorwayTriggerEnter += onBoxBreak;
    }

    private void onBoxBreak(int id)
    {
        if (id == this.id)
        {
            bs.BreakBox(id);
        }
    }

    private void OnDestroy()
    {
        Trigger.onDoorwayTriggerEnter -= onBoxBreak;
    }
}
