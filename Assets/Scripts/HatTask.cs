using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HatTask : MonoBehaviour
{
    public TextMeshProUGUI messageOutput = null;
    [TextArea] public List<string> messages = new List<string>();
    private int index = 0;
    private bool isCompleted;
    public void OpenUI()
    {
        if (isCompleted)
            return;
        gameObject.SetActive(true);
        ShowMessage(0);
    }

    public void PickHat()
    {
        ShowMessage(1);
    }

    public void MissionCompleted()
    {
        gameObject.SetActive(false);
        isCompleted = true;
    }

    private void ShowMessage(int num)
    {
        messageOutput.text = messages[num];
    }
}
