using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Health))]
public class PlayerStats : MonoBehaviour
{
    [HideInInspector]
    public Health myHp;
    // Use this for initialization
    void Start ()
    {
        //myHp 
        myHp = GetComponent<Health>();
        myHp.OnDie += testOnDie;
        myHp.OnHpIncreased += testOnHeal;
        myHp.OnHpReduced += testOnDamage;
        myHp.OnHpChanged += testOnChangedHp;
        myHp.currentHp--;
        myHp.currentHp++;
        myHp.resetHp();
        myHp.currentHp = 5;
        print(myHp.normalizedHp());

	}

    void testOnHeal()
    {
        print("healed");
    }
    void testOnDamage()
    {
        print("Damaged");
    }
    void testOnChangedHp()
    {
        print("Changed");
    }
    void testOnDie()
    {
        print("Dead");
    }
}
