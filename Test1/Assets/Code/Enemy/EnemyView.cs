using System;
using UnityEngine;
using UnityEngine.UI;

public class EnemyView : MonoBehaviour
{
    public Action PlayerOnTriggerEnterTrigger;
    public Action PlayerOnTriggerExitTrigger;

    public float Strength = 5;
    public float MaxHp;
    public float Hp;


    [SerializeField] private Image _hpBar;
    [SerializeField] private Text _hpText;
    public Image HpBar => _hpBar;
    public Text HPText => _hpText;


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
