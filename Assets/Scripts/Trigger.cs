using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public static Trigger current;

    private void Awake()
    {
        current = this;
    }

    public delegate void Action(int id);
    public static event Action onDoorwayTriggerEnter;

    public void DoorwayTriggerEnter(int id)
    {
        if(onDoorwayTriggerEnter != null)
        {
            onDoorwayTriggerEnter(id);
        }
    }


}
