using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    [HideInInspector] public bool IsCreatingRelation;
    [HideInInspector] public GameObject NewRelation;
    [HideInInspector] public bool ParentA;
    [HideInInspector] public bool IsChild;

    [HideInInspector] public bool Move = true;
    [HideInInspector] public bool Tool;
    [HideInInspector] public bool Info;
    [HideInInspector] public bool Death;

    public GameObject Profile;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SetMove();
        if (Input.GetKeyDown(KeyCode.Alpha2))
            SetTools();
        if (Input.GetKeyDown(KeyCode.Alpha3))
            SetInfo();
        if (Input.GetKeyDown(KeyCode.Alpha4))
            SetDeath();

    }

    public void SetMove()
    {
        Move = true;
        Tool = false;
        Info= false;
        Death= false;
    }

    public void SetTools()
    {
        Tool = true;
        Move= false;
        Info= false;
        Death= false;
    }

    public void SetInfo()
    {
        Info = true;
        Move = false;
        Tool= false;
        Death= false;
    }

    public void SetDeath()
    {
        Death = true;
        Info = false;
        Move= false;
        Tool = false;
    }

    public void NewProfile()
    {
        GameObject profile = Instantiate(Profile);

        profile.name = "Profile";
    }
}
