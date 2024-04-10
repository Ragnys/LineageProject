using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileScript : MonoBehaviour
{
    Camera cam;
    Vector3 mousePosition;
    public GameObject selectedObject;
    Vector3 offset;
    GameManagerScript gameManager;


    void Start()
    {
        cam = Camera.main;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    void Update()
    {
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

        if (gameManager.Move)
        {     
            if (Input.GetMouseButtonDown(0))
            {
                Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
                if (targetObject)
                {
                    selectedObject = targetObject.transform.parent.gameObject;
                    offset = selectedObject.transform.position - mousePosition;
                }
            }
            if (selectedObject)
            {
                MoveProfile();
            }
            if (Input.GetMouseButtonUp(0) && selectedObject)
            {
                selectedObject = null;
            }

        }
    }

    private void MoveProfile()
    {
        selectedObject.transform.position = mousePosition + offset;
    }
}
