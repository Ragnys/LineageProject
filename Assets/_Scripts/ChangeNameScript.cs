using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChangeNameScript : MonoBehaviour
{
    TextMeshProUGUI text;

    string currentName;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();

        currentName = transform.parent.parent.parent.name;

        text.text = currentName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeName(string name)
    {
        if (name == "")
            text.text = currentName;
        else
        {
            text.text = name;
            transform.parent.parent.parent.name = name;
        }

        currentName = name;
    }


}
