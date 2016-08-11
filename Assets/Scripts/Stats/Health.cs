using UnityEngine;
using System.Collections;



public class Health : MonoBehaviour
{
    public int maxHp;
    public int currentHp { get { return _hp; } set { changeHp(value); } }// this is the only variable that should be accesed at runtime
    private int _hp;


    /// <summary>
    /// only add events via the add event function or this += voidEventDelegate 
    /// </summary>
    public myEvents.voidEvent OnDie = new myEvents.voidEvent();
    /// <summary>
    /// only add events via the add event function or this += voidEventDelegate 
    /// </summary>
    public myEvents.voidEvent OnHpChanged = new myEvents.voidEvent();
    /// <summary>
    /// only add events via the add event function or this += voidEventDelegate 
    /// </summary>
    public myEvents.voidEvent OnHpReduced = new myEvents.voidEvent();
    /// <summary>
    /// only add events via the add event function or this += voidEventDelegate 
    /// </summary>
    public myEvents.voidEvent OnHpIncreased = new myEvents.voidEvent();

    public void Start()
    {
        _hp = maxHp;
        /*
        OnDie = new myEvents.voidEvent();
        OnHpChanged = new myEvents.voidEvent();
        OnHpReduced = new myEvents.voidEvent();
        OnHpIncreased = new myEvents.voidEvent();
        */
    }


    /// <summary>
    /// will display how much health the entity has expressed as a range between 0-1 can be used for UI
    /// </summary>
    /// <returns></returns>
    public float normalizedHp()
    {
        return (float)_hp / (float)maxHp;
    }

    /// <summary>
    /// will set hp to max hp
    /// </summary>
    public void resetHp()
    {
        _hp = maxHp;
    }





    private void changeHp(int newHp)
    {
        if (_hp < newHp)//if the hp is going up
        {
            OnHpIncreased.run();
        }
        else if (_hp > newHp)//if the hp is going down
        {
            OnHpReduced.run();
        }
        else
        {
            //if this exicuted it means 0 damage was dealt
            return;
        }
        OnHpChanged.run();

        _hp = newHp;
        if (_hp <= 0) //no -hp values
        {
            _hp = 0;
            OnDie.run();
        }
        else if (_hp > maxHp) //no over healing
        {
            _hp = maxHp;
        }
    }
}
