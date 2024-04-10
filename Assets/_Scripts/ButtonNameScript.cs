using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonNameScript : MonoBehaviour
{
    public void ChangeButtonName(TextMeshProUGUI text)
    {
        if (text.text == "Add")
            text.text = "Remove";
        else
            text.text = "Add";
    }
}
