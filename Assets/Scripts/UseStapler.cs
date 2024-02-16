using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseStapler : MonoBehaviour
{
    public GameObject staplerMain;
    private HingeJoint hingeJoint;
    // Start is called before the first frame update
    void Start()
    {
        hingeJoint = staplerMain.GetComponent<HingeJoint>();
        hingeJoint.useMotor = false;
    }
    public void GrabStapler()
    {
        hingeJoint.useMotor = true;
    }
    public void ExitStapler()
    {
        hingeJoint.useMotor = false;
    }
}
