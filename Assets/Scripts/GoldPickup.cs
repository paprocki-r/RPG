using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickup : MonoBehaviour
{
	public int value;
	public MoneyManager theMM;
    // Start is called before the first frame update
    void Start()
    {
        theMM = FindObjectOfType<MoneyManager>();

    }

    void OnTriggerEnter2D(Collider2D other)
    {
    	if(other.gameObject.name=="Player")
    	{
    		theMM.AddMoney(value);
    		Destroy(gameObject);
    	}
    }
}
