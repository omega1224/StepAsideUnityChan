using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnTriggerEnter(Collider other)
    {
        string s = other.gameObject.transform.tag;


        Debug.Log("衝突した:"+other.gameObject.transform.tag);
        if(s =="CoinTag" || s == "CarTag" || s == "TrafficConeTag")
        {
            Destroy(other.gameObject);

        }  

        
    }
    
   
}