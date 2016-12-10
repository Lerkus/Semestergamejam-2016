using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

    int[] resources = new int[12];

	public void addResources(int[] added)
    {
        for(int i = 0; i < 12; i++)
        {
            resources[i] += added[i];
        }
    }
}
