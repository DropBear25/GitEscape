using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [System.Serializable]
    public class PoolItem
{
    public GameObject prefab;
    public int amount;
    public bool expandable;
}


public class Pool : MonoBehaviour{

    public static Pool singleton;
    public List<PoolItem> items;  //bullet
    public List<GameObject> pooledItems; 

    void Awake()
    {
        singleton = this;
    }

    public GameObject Get(string tag)
    {
        for (int i = 0; i < pooledItems.Count; i++)
        {
            if(!pooledItems[i].activeInHierarchy && pooledItems[i].tag == tag)
            {
                return pooledItems[i];
            }
        }
        return null;
    }


    // Start is called before the first frame update
    void Start()
    {
        pooledItems = new List<GameObject>();
        foreach(PoolItem item in items)
        {
            for(int i = 0; i < item.amount; i++)
            {
                GameObject obj = Instantiate(item.prefab);
                obj.SetActive(false);
                pooledItems.Add(obj);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
 
}
