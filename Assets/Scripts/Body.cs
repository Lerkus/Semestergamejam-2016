using UnityEngine;
using System.Collections;

public class Body : MonoBehaviour {

    public GameObject Arm;

    void LateUpdate()
    {
        this.transform.position = Arm.transform.position;
    }
}
