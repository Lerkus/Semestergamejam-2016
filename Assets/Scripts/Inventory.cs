using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

    public static int[] resources = { 200, 200, 200, 200, 200, 200, 200, 200, 200, 200 };//new int[10];

    public static void addResources(int[] added)
    {
        for(int i = 0; i < 10; i++)
        {
            resources[i] += added[i];
        }
    }

    public static void resetInventory()
    {
        resources = new int[10];
    }
}
