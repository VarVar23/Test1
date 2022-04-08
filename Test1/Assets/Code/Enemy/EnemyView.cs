using System;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    public float Strength = 5;
    public float Hp = 1000;
    public Action PlayerOnTriggerEnterTrigger;
    public Action PlayerOnTriggerExitTrigger;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == Layers.Player)
        {
            PlayerOnTriggerEnterTrigger();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == Layers.Player)
        {
            PlayerOnTriggerExitTrigger();
        }
    }
}
