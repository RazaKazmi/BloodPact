using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllRelics : MonoBehaviour
{

    public Relic maxHP;
    public Relic maxMana;
    public Relic DmgResist;
    public Relic DmgIncrease;
    public Relic MagicDmg;
    public Relic MeleeDmg;
    public Relic ManaCostReduction;

    private List<Relic> relics = new List<Relic>();

    private void Awake()
    {
        relics.Add(maxHP);
        relics.Add(maxMana);
        relics.Add(DmgResist);
        relics.Add(DmgIncrease);
        relics.Add(MagicDmg);
        relics.Add(MeleeDmg);
        relics.Add(ManaCostReduction);
       
    }

    public Relic getRandomRelic()
    {
        if (relics != null)
            return relics[Random.Range(0, relics.Count)];
        else
            return null;
    }



}
