using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance; // Inventory is a singleton

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
    }

    #endregion

    public delegate void OnRelicChanged();
    public OnRelicChanged onRelicChangedCallback;

    public int space = 14;

    public List<Relic> relics = new List<Relic>();

    public void Add(Relic relic)
    {
        if (relics.Count >= space)
        {
            Debug.Log("Inventory Full");
            return; 
            //may need to make this function a bool, because relic will be consumed even if inventory is full
        }
        relics.Add(relic);

        if(onRelicChangedCallback !=null)
            onRelicChangedCallback.Invoke();

    }

    public void Remove(Relic relic)
    {
        relics.Remove(relic);


        if (onRelicChangedCallback != null)
            onRelicChangedCallback.Invoke();
    }


}
