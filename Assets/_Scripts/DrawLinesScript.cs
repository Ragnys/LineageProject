using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class DrawLinesScript : MonoBehaviour
{
    [SerializeField] bool isA;
    LineRenderer line;
    GeneRandomizer geneRandomizer;
    GameManagerScript gm;
    Camera cam;

    bool usingLines;

    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        geneRandomizer = GetComponentInParent<GeneRandomizer>();
        gm = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        usingLines = false;
        if(isA)
        {
            ChoosingLine();
            if (geneRandomizer.ParentA != null)
                LineToParent(geneRandomizer.ParentA, true);
        }
        else if(!isA)
        {
            ChoosingLine();
            if (geneRandomizer.ParentB != null)
                LineToParent(geneRandomizer.ParentB, false);
        }
        

        if(!usingLines)
        {
            line.SetPosition(0, transform.position);
            line.SetPosition(1, transform.position);
            line.SetPosition(2, transform.position);
            line.SetPosition(3, transform.position);
            //line.SetPosition(4, transform.position);
            //line.SetPosition(5, transform.position);
        }

        if (Input.GetMouseButtonDown(0) && gm.IsCreatingRelation)
            StartCoroutine(DelayCancel());

    }

    void ChoosingLine()
    {
        if (gm.IsCreatingRelation && gm.NewRelation == transform.parent.gameObject)
        {
            usingLines = true;

            Vector3 pos = new Vector3(cam.ScreenToWorldPoint(Input.mousePosition).x, cam.ScreenToWorldPoint(Input.mousePosition).y, 0);

            float dif = (pos.y - transform.position.y)/2;

            line.SetPosition(0, transform.position);
            line.SetPosition(1,  new Vector3(transform.position.x, pos.y - dif, 0));
            line.SetPosition(2, new Vector3(pos.x, pos.y - dif, 0));
            line.SetPosition(3,  pos);
            //line.SetPosition(4,  pos);
            //line.SetPosition(5,  pos);

            int plusminus;

            if(pos.y > transform.position.y)
            {
                plusminus = +10;
            }
            else
                plusminus = -10;

            Vector3 aPos = new Vector3(transform.position.x, transform.position.y + plusminus, 0);

            line.SetPosition(1, aPos);
            line.SetPosition(2, new Vector3(pos.x, aPos.y, 0));
        }
    }

    private void LineToParent(GameObject obj, bool a)
    {
        usingLines = true;

        int aorb;
        if (a)
            aorb = +5;
        else
            aorb = -5;

        float dif = (obj.transform.position.y - transform.position.y - 10) / 2;
        Vector3 aPos = new Vector3(obj.transform.position.x + aorb, obj.transform.position.y - 10 - dif, 0);


        line.SetPosition(0, transform.position);
        line.SetPosition(1, new Vector3(transform.position.x, transform.position.y + dif, 0));
        line.SetPosition(2, aPos);
        line.SetPosition(3, new Vector3(obj.transform.position.x + aorb, obj.transform.position.y, 0));



        //usingLines = true;
        //int aorb;

        //if (a)
        //    aorb = +5;
        //else
        //    aorb = -5;

        //Vector3 aPos = new Vector3(obj.transform.position.x + aorb, transform.position.y, 0);
        //float dif = (obj.transform.position.y - transform.position.y)/2;

        //line.SetPosition(0, transform.position);
        //line.SetPosition(1, new Vector3(transform.position.x, transform.position.y + dif, 0));

        //if (obj.transform.position.y > transform.position.y)
        //{
        //    line.SetPosition(2, new Vector3(aPos.x, transform.position.y -dif, 0));
        //    line.SetPosition(3, aPos);
        //    line.SetPosition(4, aPos);
        //    line.SetPosition(5, aPos);
        //}
        //else
        //{
        //    if (obj.transform.position.x < transform.position.x)
        //    {
        //        line.SetPosition(2, new Vector3(obj.transform.position.x + 15, aPos.y + 10, 0));
        //        line.SetPosition(3, new Vector3(obj.transform.position.x + 15, transform.position.y + 10, 0));
        //    }
        //    else
        //    {
        //        line.SetPosition(2, new Vector3(obj.transform.position.x - 15, aPos.y + 10, 0));
        //        line.SetPosition(3, new Vector3(obj.transform.position.x - 15, transform.position.y + 10, 0));
        //    }



        //    line.SetPosition(4, new Vector3(aPos.x, aPos.y - 10, 0));
        //    line.SetPosition(5, aPos);
        //}

    }

    IEnumerator DelayCancel()
    {
        yield return new WaitForSeconds(0.3f);
        gm.IsCreatingRelation = false;
    }
}
