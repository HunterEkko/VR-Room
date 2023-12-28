using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OpenBook : MonoBehaviour
{
    public GameObject bookCover;
    private HingeJoint hingeJoint;
    // Start is called before the first frame update
    void Start()
    {
        hingeJoint = bookCover.GetComponent<HingeJoint>();
        hingeJoint.useMotor = false;
    }
    public void GrabBook()
    {
        hingeJoint.useMotor = true;
    }
    public void ExitBook()
    {
        hingeJoint.useMotor = false;
    }
}
