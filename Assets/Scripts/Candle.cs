using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lighter"))
        {
            Debug.Log("Success");
            this.GetComponentInParent<ToggleParticle>().Play();
        }
    }
}
