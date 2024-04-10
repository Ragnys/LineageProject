using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SetRelation : MonoBehaviour
{
    [SerializeField] GameManagerScript scrub;

    [SerializeField] GameObject buttons;


    [SerializeField] GameObject parentObject;

    GeneRandomizer geneRandomizer;
    

    // Start is called before the first frame update
    void Start()
    {
        scrub = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        geneRandomizer = GetComponentInParent<GeneRandomizer>();
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public void WhatParent(bool parent)
    {
        scrub.ParentA = parent;
    }
    

    public void ButtonFlipFlop(GameObject obj)
    {
        if (scrub.Tool)
        {
            if (!scrub.IsCreatingRelation)
            {
                buttons.SetActive(!buttons.activeSelf);
            }
            else
            {
                scrub.IsCreatingRelation = false;
                SetNewParent();
            }
        }
        else if (scrub.Death)
        {
            foreach (var child in geneRandomizer.Children)
            {
                if (child.ParentA == parentObject)
                {
                    child.ParentA = null;
                    break;
                }
                else if(child.ParentB == parentObject)
                {
                    child.ParentB = null;
                    break;
                }

            }
            if(geneRandomizer.ParentA!= null)
                geneRandomizer.ParentA.GetComponent<GeneRandomizer>().Children.Remove(geneRandomizer);
            if(geneRandomizer.ParentB!= null)
                geneRandomizer.ParentB.GetComponent<GeneRandomizer>().Children.Remove(geneRandomizer);

            Destroy(parentObject);
        }

    }

    public void CreateRelation(bool setIsParent)
    {
        scrub.IsChild = setIsParent;

        if (!scrub.IsChild)
        {
            if (parentObject.GetComponent<GeneRandomizer>().ParentA != null)
            {
                parentObject.GetComponent<GeneRandomizer>().ParentA = null;
                parentObject.GetComponent<GeneRandomizer>().Reset();
            }
            else if (parentObject.GetComponent<GeneRandomizer>().ParentB != null)
            {
                parentObject.GetComponent<GeneRandomizer>().ParentB = null;
                parentObject.GetComponent<GeneRandomizer>().Reset();
            }
            else
            {
                scrub.NewRelation = parentObject;
                scrub.IsCreatingRelation = true;
            }
        }
        else
        {
            scrub.NewRelation = parentObject;
            scrub.IsCreatingRelation = true;
        }
    }

    void SetNewParent()
    {
        GeneRandomizer gene = scrub.NewRelation.GetComponent<GeneRandomizer>();

        if (scrub.NewRelation == parentObject || gene.ParentA == parentObject || gene.ParentB == parentObject || gene.Children.Contains(geneRandomizer) || geneRandomizer.ParentA == scrub.NewRelation || geneRandomizer.ParentB == scrub.NewRelation || geneRandomizer.Children.Contains(gene))
            print("Cannot Create Relation: " + scrub.NewRelation.name + " + " + parentObject.name);
        else
        {
            GeneRandomizer parentGene;
            GeneRandomizer childGene;

            if (!scrub.IsChild)
            {
                childGene = parentObject.GetComponent<GeneRandomizer>();
                parentGene = scrub.NewRelation.GetComponent<GeneRandomizer>();
            }
            else
            {
                parentGene = parentObject.GetComponent<GeneRandomizer>();
                childGene = scrub.NewRelation.GetComponent<GeneRandomizer>();
            }



            if (!scrub.IsChild)
            {
                if (childGene.ParentA == null)
                    childGene.ParentA = parentGene.gameObject;
                else
                    childGene.ParentB = parentGene.gameObject;
            }
            else
            {
                if (scrub.ParentA)
                {
                    if (childGene.ParentA != null)
                        childGene.ParentA.GetComponent<GeneRandomizer>().Children.Remove(childGene);
                    childGene.ParentA = parentGene.gameObject;
                }
                else
                {
                    if (childGene.ParentB != null)
                        childGene.ParentB.GetComponent<GeneRandomizer>().Children.Remove(childGene);
                    childGene.ParentB = parentGene.gameObject;
                }


            }      
            
                parentGene.Children.Add(childGene);
                childGene.Reset();
        }
    }


}
