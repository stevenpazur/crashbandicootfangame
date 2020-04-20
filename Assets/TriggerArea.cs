using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    public int id;

    public void OnTriggerEnter(Collider other)
    {
        Trigger.current.DoorwayTriggerEnter(id);
    }
}
