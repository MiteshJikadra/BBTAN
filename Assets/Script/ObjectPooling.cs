using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPoolItem
{
    public int amountToPool;
    public GameObject objectToPool;
}
public class ObjectPooling : MonoBehaviour
{
    public List<GameObject> pooledObjects;
    public List<ObjectPoolItem> itemsToPool;
    // Start is called before the first frame update
    void Start()
    {
        //pooledObjects = new List<GameObject>();
        //foreach (ObjectPoolItem item in itemsToPool)
        //{
        //    GameObject obj = (GameObject)Instantiate(item.objectToPool);
        //    obj.SetActive(false);
        //    pooledObjects.Add(obj);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
