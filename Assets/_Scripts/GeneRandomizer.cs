using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using TMPro;

public class GeneRandomizer : MonoBehaviour
{
    [SerializeField] bool simplegenes = true;

    public GameObject ParentA;
    Genes aGenes = new Genes();
    Appaerance aAppaerance = new Appaerance();

    public GameObject ParentB;
    Genes bGenes = new Genes();
    Appaerance bAppearance = new Appaerance();

    public List<GeneRandomizer> Children = new List<GeneRandomizer>();

    public Appaerance appaerance;

    public Genes personGenes;


    [SerializeField] SpriteRenderers spriteRenderers;


    void Start()
    {
        Reset();    
    }

    public void Reset()
    {
        if (ParentA != null)
            SetParentVariable(ParentA);
        else
        {
            //aGenes = GenerateGenes();
            aGenes = GenerateSimpleGenes();
            GeneToAppearance(aGenes, aAppaerance);
        }

        if (ParentB != null)
            SetParentVariable(ParentB);
        else
        {
            //bGenes = GenerateGenes();
            bGenes = GenerateSimpleGenes();
            GeneToAppearance(bGenes, bAppearance);
        }

        if (simplegenes)
            personGenes = GenerateSimpleGenes();
        else
            MixGenes();

        GeneToAppearance(personGenes, appaerance);

        SetAppearance();

        foreach (var child in Children)
        {
            child.Reset();
        }
    }
    void SetParentVariable(GameObject parent)
    {
        GeneRandomizer gene = parent.GetComponent<GeneRandomizer>();

        aGenes = gene.personGenes;
        aAppaerance = gene.appaerance;

        if (gene.Children.Contains(this))
            gene.Children.Add(this);

        simplegenes = false;
    }

    void GeneToAppearance(Genes gene, Appaerance app)
    {
        #region Face Shape
        switch (UnityEngine.Random.Range(0, 1))
        {
            case 0:
                app.FaceShape = gene.FaceShapeA;
                break;
            case 1:
                app.FaceShape = gene.FaceShapeB;
                break;
        }
        #endregion

        #region Nose Shape
        switch (UnityEngine.Random.Range(0, 1))
        {
            case 0:
                app.NoseShape = gene.NoseShapeA;
                break;
            case 1:
                app.NoseShape = gene.NoseShapeB;
                break;
        }
        #endregion

        #region Skin Tone
        if (gene.SkinToneA == gene.SkinToneB)
            app.SkinColor = gene.SkinToneB;

        else if (gene.SkinToneA == SkinColor.Light && gene.SkinToneB == SkinColor.MediumLight)
        {
            if (UnityEngine.Random.Range(0, 1.1f) < 0.5f)
                app.SkinColor = SkinColor.Light;
            else
                app.SkinColor = SkinColor.MediumLight;
        }
        else if (gene.SkinToneB == SkinColor.Light && gene.SkinToneA == SkinColor.MediumLight)
        {
            if (UnityEngine.Random.Range(0, 1.1f) < 0.5f)
                app.SkinColor = SkinColor.Light;
            else
                app.SkinColor = SkinColor.MediumLight;
        }

        else if (gene.SkinToneA == SkinColor.MediumLight && gene.SkinToneB == SkinColor.MediumDark)
        {
            if (UnityEngine.Random.Range(0, 1.1f) < 0.5f)
                app.SkinColor = SkinColor.MediumLight;
            else
                app.SkinColor = SkinColor.MediumDark;
        }
        else if (gene.SkinToneB == SkinColor.MediumLight && gene.SkinToneA == SkinColor.MediumDark)
        {
            if (UnityEngine.Random.Range(0, 1.1f) < 0.5f)
                app.SkinColor = SkinColor.MediumLight;
            else
                app.SkinColor = SkinColor.MediumDark;
        }

        else if (gene.SkinToneA == SkinColor.MediumDark && gene.SkinToneB == SkinColor.Dark)
        {
            if (UnityEngine.Random.Range(0, 1.1f) < 0.5f)
                app.SkinColor = SkinColor.MediumDark;
            else
                app.SkinColor = SkinColor.Dark;
        }
        else if (gene.SkinToneB == SkinColor.MediumDark && gene.SkinToneA == SkinColor.Dark)
        {
            if (UnityEngine.Random.Range(0, 1.1f) < 0.5f)
                app.SkinColor = SkinColor.MediumDark;
            else
                app.SkinColor = SkinColor.Dark;
        }

        else if (gene.SkinToneA == SkinColor.Light && gene.SkinToneB == SkinColor.MediumDark)
        {
            if (UnityEngine.Random.Range(0, 1.1f) < 0.7f)
                app.SkinColor = SkinColor.MediumLight;
            else
                app.SkinColor = SkinColor.MediumDark;
        }
        else if (gene.SkinToneB == SkinColor.Light && gene.SkinToneA == SkinColor.MediumDark)
        {
            if (UnityEngine.Random.Range(0, 1.1f) < 0.7f)
                app.SkinColor = SkinColor.MediumLight;
            else
                app.SkinColor = SkinColor.MediumDark;
        }

        else if (gene.SkinToneA == SkinColor.MediumLight && gene.SkinToneB == SkinColor.Dark)
        {
            if (UnityEngine.Random.Range(0, 1.1f) < 0.5f)
                app.SkinColor = SkinColor.MediumDark;
            else
                app.SkinColor = SkinColor.Dark;
        }
        else if (gene.SkinToneB == SkinColor.MediumLight && gene.SkinToneA == SkinColor.Dark)
        {
            if (UnityEngine.Random.Range(0, 1.1f) < 0.5f)
                app.SkinColor = SkinColor.MediumDark;
            else
                app.SkinColor = SkinColor.Dark;
        }

        else if (gene.SkinToneA == SkinColor.Light && gene.SkinToneB == SkinColor.Dark)
        {
            if (UnityEngine.Random.Range(0, 1.1f) < 0.5f)
                app.SkinColor = SkinColor.MediumDark;
            else
                app.SkinColor = SkinColor.MediumLight;
        }
        else if (gene.SkinToneB == SkinColor.Light && gene.SkinToneA == SkinColor.Dark)
        {
            if (UnityEngine.Random.Range(0, 1.1f) < 0.5f)
                app.SkinColor = SkinColor.MediumDark;
            else
                app.SkinColor = SkinColor.MediumLight;
        }
        #endregion

        #region Eye Shape
        switch (UnityEngine.Random.Range(0, 1))
        {
            case 0:
                app.EyeShape = gene.EyeShapeA;
                break;
            case 1:
                app.EyeShape = gene.EyeShapeB;
                break;
        }
        #endregion

        #region Eye Color
        if(gene.EyeColorA == gene.EyeColorB)
            app.EyeColor= gene.EyeColorA;
        else if (gene.EyeColorA == EyeColor.Blue && gene.EyeColorB == EyeColor.Green)
        {
            float rand = UnityEngine.Random.Range(0, 1.1f);

            if(rand < 0.6f)
                app.EyeColor = EyeColor.Green;
            else
                app.EyeColor = EyeColor.Blue;
        }
        else if (gene.EyeColorB == EyeColor.Blue && gene.EyeColorA == EyeColor.Green)
        {
            float rand = UnityEngine.Random.Range(0, 1.1f);

            if(rand < 0.56)
                app.EyeColor = EyeColor.Green;
            else
                app.EyeColor = EyeColor.Blue;
        }

        else if (gene.EyeColorA == EyeColor.Brown && gene.EyeColorB == EyeColor.Green)
        {
            float rand = UnityEngine.Random.Range(0, 1.1f);

            if(rand < 0.05f)
                app.EyeColor = EyeColor.Green;
            else
                app.EyeColor = EyeColor.Brown;
        }
        else if (gene.EyeColorB == EyeColor.Brown && gene.EyeColorA == EyeColor.Green)
        {
            float rand = UnityEngine.Random.Range(0, 1.1f);

            if (rand < 0.05f)
                app.EyeColor = EyeColor.Green;
            else
                app.EyeColor = EyeColor.Brown;
        }
        else if (gene.EyeColorA == EyeColor.Brown && gene.EyeColorB == EyeColor.Blue)
        {
            app.EyeColor = EyeColor.Brown;
        }
        else if (gene.EyeColorB == EyeColor.Brown && gene.EyeColorA == EyeColor.Blue)
        {
            app.EyeColor = EyeColor.Brown;
        }
        #endregion

        #region Hair Color
        switch (UnityEngine.Random.Range(0, 3))
        {
            case 0:
                app.HairColor = gene.HairColorA;
                break;
            case 1:
                app.HairColor = gene.HairColorB;
                break;
            case 2:
                app.HairColor = gene.HairColorC;
                break;
            case 3:
                app.HairColor = gene.HairColorD;
                break;
        }
        #endregion

        #region Hair Texture
        switch (UnityEngine.Random.Range(0, 3))
        {
            case 0:
                app.HairTexture = gene.HairTextureA;
                break;
            case 1:
                app.HairTexture = gene.HairTextureB;
                break;
            case 2:
                app.HairTexture = gene.HairTextureC;
                break;
            case 3:
                app.HairTexture = gene.HairTextureD;
                break;
        }
        #endregion

        #region Ear Shape
        switch (UnityEngine.Random.Range(0, 1))
        {
            case 0:
                app.EarShape = gene.EarShapeA;
                break;
            case 1:
                app.EarShape = gene.EarShapeB;
                break;
        }
        #endregion

        #region Eyebrow
        switch (UnityEngine.Random.Range(0, 1))
        {
            case 0:
                app.Eyebrow = gene.EyebrowA;
                break;
            case 1:
                app.Eyebrow = gene.EyebrowB;
                break;
        }
        #endregion
    }

    Genes GenerateGenes()
    {
        Genes sampleGene = new Genes();

        //Face Shape A
        switch(UnityEngine.Random.Range(0, 2))
        {
            case 0:
                sampleGene.FaceShapeA = FaceShape.Square;
                break;
            case 1:
                sampleGene.FaceShapeA = FaceShape.Oval;
                break;
            case 2:
                sampleGene.FaceShapeA = FaceShape.Heart;
                break;
            default:
                sampleGene.FaceShapeA = FaceShape.Square;
                break;
        }
        //Face Shape B
        switch(UnityEngine.Random.Range(0, 2))
        {
            case 0:
                sampleGene.FaceShapeB = FaceShape.Square;
                break;
            case 1:
                sampleGene.FaceShapeB = FaceShape.Oval;
                break;
            case 2:
                sampleGene.FaceShapeB = FaceShape.Heart;
                break;
            default:
                sampleGene.FaceShapeB = FaceShape.Square;
                break;
        }
        //Nose Shape A
        switch (UnityEngine.Random.Range(0, 2))
        {
            case 0:
                sampleGene.NoseShapeA = NoseShape.Button;
                break;
            case 1:
                sampleGene.NoseShapeA = NoseShape.Hook;
                break;
            case 2:
                sampleGene.NoseShapeA = NoseShape.Sharp;
                break;
            default:
                sampleGene.NoseShapeA = NoseShape.Button;
                break;
        }
        //Nose Shape B
        switch (UnityEngine.Random.Range(0, 2))
        {
            case 0:
                sampleGene.NoseShapeB = NoseShape.Button;
                break;
            case 1:
                sampleGene.NoseShapeB = NoseShape.Hook;
                break;
            case 2:
                sampleGene.NoseShapeB = NoseShape.Sharp;
                break;
            default:
                sampleGene.NoseShapeB = NoseShape.Button;
                break;
        }
        //skintone A
        switch (UnityEngine.Random.Range(0, 3))
        {
            case 0:
                sampleGene.SkinToneA = SkinColor.Light;
                break;
            case 1:
                sampleGene.SkinToneA = SkinColor.MediumLight;
                break;
            case 2:
                sampleGene.SkinToneA = SkinColor.MediumDark;
                break;
            case 3:
                sampleGene.SkinToneA = SkinColor.Dark;
                break;
            default:
                sampleGene.SkinToneA = SkinColor.MediumLight;
                break;
        }
        //skintone B
        switch (UnityEngine.Random.Range(0, 3))
        {
            case 0:
                sampleGene.SkinToneB = SkinColor.Light;
                break;
            case 1:
                sampleGene.SkinToneB = SkinColor.MediumLight;
                break;
            case 2:
                sampleGene.SkinToneB = SkinColor.MediumDark;
                break;
            case 3:
                sampleGene.SkinToneB = SkinColor.Dark;
                break;
            default:
                sampleGene.SkinToneB = SkinColor.MediumLight;
                break;
        }
        //Eye Color A
        switch (UnityEngine.Random.Range(0, 2))
        {
            case 0:
                sampleGene.EyeColorA = EyeColor.Brown;
                break;
            case 1:
                sampleGene.EyeColorA = EyeColor.Blue;
                break;
            case 2:
                sampleGene.EyeColorA = EyeColor.Green;
                break;
            default:
                sampleGene.EyeColorA = EyeColor.Brown;
                break;
        }
        //Eye Color B
        switch (UnityEngine.Random.Range(0, 2))
        {
            case 0:
                sampleGene.EyeColorB = EyeColor.Brown;
                break;
            case 1:
                sampleGene.EyeColorB = EyeColor.Blue;
                break;
            case 2:
                sampleGene.EyeColorB = EyeColor.Green;
                break;
            default:
                sampleGene.EyeColorB = EyeColor.Brown;
                break;
        }
        //Eye Shape A
        switch (UnityEngine.Random.Range(0, 3))
        {
            case 0:
                sampleGene.EyeShapeA = EyeShape.Monolid;
                break;
            case 1:
                sampleGene.EyeShapeA = EyeShape.Sharp;
                break;
            case 2:
                sampleGene.EyeShapeA = EyeShape.Round;
                break;
            case 3:
                sampleGene.EyeShapeA = EyeShape.Square;
                break;
            default:
                sampleGene.EyeShapeA = EyeShape.Square;
                break;
        }
        //Eye Shape B
        switch (UnityEngine.Random.Range(0, 3))
        {
            case 0:
                sampleGene.EyeShapeB = EyeShape.Monolid;
                break;
            case 1:
                sampleGene.EyeShapeB = EyeShape.Sharp;
                break;
            case 2:
                sampleGene.EyeShapeB = EyeShape.Round;
                break;
            case 3:
                sampleGene.EyeShapeB = EyeShape.Square;
                break;
            default:
                sampleGene.EyeShapeB = EyeShape.Square;
                break;
        }
        //Hair Color A
        switch (UnityEngine.Random.Range(0, 3))
        {
            case 0:
                sampleGene.HairColorA = HairColor.Blonde;
                break;
            case 1:
                sampleGene.HairColorA = HairColor.Brunette;
                break;
            case 2:
                sampleGene.HairColorA = HairColor.Black;
                break;
            case 3:
                sampleGene.HairColorA = HairColor.Red;
                break;
            default:
                sampleGene.HairColorA = HairColor.Brunette;
                break;
        }
        //Hair Color B
        switch (UnityEngine.Random.Range(0, 3))
        {
            case 0:
                sampleGene.HairColorB = HairColor.Blonde;
                break;
            case 1:
                sampleGene.HairColorB = HairColor.Brunette;
                break;
            case 2:
                sampleGene.HairColorB = HairColor.Black;
                break;
            case 3:
                sampleGene.HairColorB = HairColor.Red;
                break;
            default:
                sampleGene.HairColorB = HairColor.Brunette;
                break;
        }
        //Hair Color C
        switch (UnityEngine.Random.Range(0, 3))
        {
            case 0:
                sampleGene.HairColorC = HairColor.Blonde;
                break;
            case 1:
                sampleGene.HairColorC = HairColor.Brunette;
                break;
            case 2:
                sampleGene.HairColorC = HairColor.Black;
                break;
            case 3:
                sampleGene.HairColorC = HairColor.Red;
                break;
            default:
                sampleGene.HairColorC = HairColor.Brunette;
                break;
        }
        //Hair Color D
        switch (UnityEngine.Random.Range(0, 3))
        {
            case 0:
                sampleGene.HairColorD = HairColor.Blonde;
                break;
            case 1:
                sampleGene.HairColorD = HairColor.Brunette;
                break;
            case 2:
                sampleGene.HairColorD = HairColor.Black;
                break;
            case 3:
                sampleGene.HairColorD = HairColor.Red;
                break;
            default:
                sampleGene.HairColorD = HairColor.Brunette;
                break;
        }
        //Hair Texture A
        switch (UnityEngine.Random.Range(0, 3))
        {
            case 0:
                sampleGene.HairTextureA = HairTexture.Curls;
                break;
            case 1:
                sampleGene.HairTextureA = HairTexture.Straight;
                break;
            case 2:
                sampleGene.HairTextureA = HairTexture.TightCurls;
                break;
            case 3:
                sampleGene.HairTextureA = HairTexture.Wavy;
                break;
            default:
                sampleGene.HairTextureA = HairTexture.Curls;
                break; 
        }
        //Hair Texture B
        switch (UnityEngine.Random.Range(0, 3))
        {
            case 0:
                sampleGene.HairTextureB = HairTexture.Curls;
                break;
            case 1:
                sampleGene.HairTextureB = HairTexture.Straight;
                break;
            case 2:
                sampleGene.HairTextureB = HairTexture.TightCurls;
                break;
            case 3:
                sampleGene.HairTextureB = HairTexture.Wavy;
                break;
            default:
                sampleGene.HairTextureB = HairTexture.Curls;
                break;
        }
        //Hair Texture c
        switch (UnityEngine.Random.Range(0, 3))
        {
            case 0:
                sampleGene.HairTextureC = HairTexture.Curls;
                break;
            case 1:
                sampleGene.HairTextureC = HairTexture.Straight;
                break;
            case 2:
                sampleGene.HairTextureC = HairTexture.TightCurls;
                break;
            case 3:
                sampleGene.HairTextureC = HairTexture.Wavy;
                break;
            default:
                sampleGene.HairTextureC = HairTexture.Curls;
                break;
        }
        //Hair Texture D
        switch (UnityEngine.Random.Range(0, 3))
        {
            case 0:
                sampleGene.HairTextureD = HairTexture.Curls;
                break;
            case 1:
                sampleGene.HairTextureD = HairTexture.Straight;
                break;
            case 2:
                sampleGene.HairTextureD = HairTexture.TightCurls;
                break;
            case 3:
                sampleGene.HairTextureD = HairTexture.Wavy;
                break;
            default:
                sampleGene.HairTextureD = HairTexture.Curls;
                break;
        }
        //Ear Shape A
        switch (UnityEngine.Random.Range(0, 2))
        {
            case 0:
                sampleGene.EarShapeA = EarShape.UnconnectedEarlobe;
                break;
            case 1:
                sampleGene.EarShapeA = EarShape.ConnectedEarlobe;
                break;
            default:
                sampleGene.EarShapeA = EarShape.ConnectedEarlobe;
                break;
        }
        //Ear Shape B
        switch (UnityEngine.Random.Range(0, 2))
        {
            case 0:
                sampleGene.EarShapeB = EarShape.UnconnectedEarlobe;
                break;
            case 1:
                sampleGene.EarShapeB = EarShape.ConnectedEarlobe;
                break;
            default:
                sampleGene.EarShapeB = EarShape.ConnectedEarlobe;
                break;
        }
        //eyebrow A
        switch (UnityEngine.Random.Range(0, 3))
        {
            case 0:
                sampleGene.EyebrowA = Eyebrow.Arched;
                break;
            case 1:
                sampleGene.EyebrowA = Eyebrow.Straight;
                break;
            case 2:
                sampleGene.EyebrowA = Eyebrow.Thick;
                break;
            case 3:
                sampleGene.EyebrowA = Eyebrow.Emo;
                break;
            default:
                sampleGene.EyebrowA = Eyebrow.Straight;
                break;
        }
        //eyebrow B
        switch (UnityEngine.Random.Range(0, 3))
        {
            case 0:
                sampleGene.EyebrowB = Eyebrow.Arched;
                break;
            case 1:
                sampleGene.EyebrowB = Eyebrow.Straight;
                break;
            case 2:
                sampleGene.EyebrowB = Eyebrow.Thick;
                break;
            case 3:
                sampleGene.EyebrowB = Eyebrow.Emo;
                break;
            default:
                sampleGene.EyebrowB = Eyebrow.Straight;
                break;
        }

        return sampleGene;
    }

    Genes GenerateSimpleGenes()
    {
        Genes sampleGene = new Genes();

        //Face Shape
        switch (UnityEngine.Random.Range(0, 3))
        {
            case 0:
                sampleGene.FaceShapeA = FaceShape.Square;
                sampleGene.FaceShapeB = FaceShape.Square;
                break;
            case 1:
                sampleGene.FaceShapeA = FaceShape.Oval;
                sampleGene.FaceShapeB = FaceShape.Oval;
                break;
            case 2:
                sampleGene.FaceShapeA = FaceShape.Heart;
                sampleGene.FaceShapeB = FaceShape.Heart;
                break;
            default:
                sampleGene.FaceShapeA = FaceShape.Square;
                sampleGene.FaceShapeB = FaceShape.Square;
                break;
        }
        
        //Nose Shape
        switch (UnityEngine.Random.Range(0, 3))
        {
            case 0:
                sampleGene.NoseShapeA = NoseShape.Button;
                sampleGene.NoseShapeB = NoseShape.Button;
                break;
            case 1:
                sampleGene.NoseShapeA = NoseShape.Hook;
                sampleGene.NoseShapeB = NoseShape.Hook;
                break;
            case 2:
                sampleGene.NoseShapeA = NoseShape.Sharp;
                sampleGene.NoseShapeB = NoseShape.Sharp;
                break;
            default:
                sampleGene.NoseShapeA = NoseShape.Button;
                sampleGene.NoseShapeB = NoseShape.Button;
                break;
        }
        
        //skintone
        switch (UnityEngine.Random.Range(0, 4))
        {
            case 0:
                sampleGene.SkinToneA = SkinColor.Light;
                sampleGene.SkinToneB = SkinColor.Light;
                break;
            case 1:
                sampleGene.SkinToneA = SkinColor.MediumLight;
                sampleGene.SkinToneB = SkinColor.MediumLight;
                break;
            case 2:
                sampleGene.SkinToneA = SkinColor.MediumDark;
                sampleGene.SkinToneB = SkinColor.MediumDark;
                break;
            case 3:
                sampleGene.SkinToneA = SkinColor.Dark;
                sampleGene.SkinToneB = SkinColor.Dark;
                break;
            default:
                sampleGene.SkinToneA = SkinColor.MediumLight;
                sampleGene.SkinToneB = SkinColor.MediumLight;
                break;
        }
        
        //Eye Color
        switch (UnityEngine.Random.Range(0, 3))
        {
            case 0:
                sampleGene.EyeColorA = EyeColor.Brown;
                sampleGene.EyeColorB = EyeColor.Brown;
                break;
            case 1:
                sampleGene.EyeColorA = EyeColor.Blue;
                sampleGene.EyeColorB = EyeColor.Blue;
                break;
            case 2:
                sampleGene.EyeColorA = EyeColor.Green;
                sampleGene.EyeColorB = EyeColor.Green;
                break;
            default:
                sampleGene.EyeColorA = EyeColor.Brown;
                sampleGene.EyeColorB = EyeColor.Brown;
                break;
        }
       
        //Eye Shape
        switch (UnityEngine.Random.Range(0, 4))
        {
            case 0:
                sampleGene.EyeShapeA = EyeShape.Monolid;
                sampleGene.EyeShapeB = EyeShape.Monolid;
                break;
            case 1:
                sampleGene.EyeShapeA = EyeShape.Sharp;
                sampleGene.EyeShapeB = EyeShape.Sharp;
                break;
            case 2:
                sampleGene.EyeShapeA = EyeShape.Round;
                sampleGene.EyeShapeB = EyeShape.Round;
                break;
            case 3:
                sampleGene.EyeShapeA = EyeShape.Square;
                sampleGene.EyeShapeB = EyeShape.Square;
                break;
            default:
                sampleGene.EyeShapeA = EyeShape.Square;
                sampleGene.EyeShapeB = EyeShape.Square;
                break;
        }
       
        //Hair Color A
        switch (UnityEngine.Random.Range(0, 4))
        {
            case 0:
                sampleGene.HairColorA = HairColor.Blonde;
                sampleGene.HairColorB = HairColor.Blonde;
                sampleGene.HairColorC = HairColor.Blonde;
                sampleGene.HairColorD = HairColor.Blonde;
                break;
            case 1:
                sampleGene.HairColorA = HairColor.Brunette;
                sampleGene.HairColorB = HairColor.Brunette;
                sampleGene.HairColorC = HairColor.Brunette;
                sampleGene.HairColorD = HairColor.Brunette;
                break;
            case 2:
                sampleGene.HairColorA = HairColor.Black;
                sampleGene.HairColorB = HairColor.Black;
                sampleGene.HairColorC = HairColor.Black;
                sampleGene.HairColorD = HairColor.Black;
                break;
            case 3:
                sampleGene.HairColorA = HairColor.Red;
                sampleGene.HairColorB = HairColor.Red;
                sampleGene.HairColorC = HairColor.Red;
                sampleGene.HairColorD = HairColor.Red;
                break;
            default:
                sampleGene.HairColorA = HairColor.Brunette;
                sampleGene.HairColorB = HairColor.Brunette;
                sampleGene.HairColorC = HairColor.Brunette;
                sampleGene.HairColorD = HairColor.Brunette;
                break;
        }
        
        //Hair Texture
        switch (UnityEngine.Random.Range(0, 4))
        {
            case 0:
                sampleGene.HairTextureA = HairTexture.Curls;
                sampleGene.HairTextureB = HairTexture.Curls;
                sampleGene.HairTextureC = HairTexture.Curls;
                sampleGene.HairTextureD = HairTexture.Curls;
                break;
            case 1:
                sampleGene.HairTextureA = HairTexture.Straight;
                sampleGene.HairTextureB = HairTexture.Straight;
                sampleGene.HairTextureC = HairTexture.Straight;
                sampleGene.HairTextureD = HairTexture.Straight;
                break;
            case 2:
                sampleGene.HairTextureA = HairTexture.TightCurls;
                sampleGene.HairTextureB = HairTexture.TightCurls;
                sampleGene.HairTextureC = HairTexture.TightCurls;
                sampleGene.HairTextureD = HairTexture.TightCurls;
                break;
            case 3:
                sampleGene.HairTextureA = HairTexture.Wavy;
                sampleGene.HairTextureB = HairTexture.Wavy;
                sampleGene.HairTextureC = HairTexture.Wavy;
                sampleGene.HairTextureD = HairTexture.Wavy;
                break;
            default:
                sampleGene.HairTextureA = HairTexture.Curls;
                sampleGene.HairTextureB = HairTexture.Curls;
                sampleGene.HairTextureC = HairTexture.Curls;
                sampleGene.HairTextureD = HairTexture.Curls;
                break;
        }
       
        //Ear Shape
        switch (UnityEngine.Random.Range(0, 3))
        {
            case 0:
                sampleGene.EarShapeA = EarShape.UnconnectedEarlobe;
                sampleGene.EarShapeB = EarShape.UnconnectedEarlobe;
                break;
            case 1:
                sampleGene.EarShapeA = EarShape.ConnectedEarlobe;
                sampleGene.EarShapeB = EarShape.ConnectedEarlobe;
                break;
            default:
                sampleGene.EarShapeA = EarShape.ConnectedEarlobe;
                sampleGene.EarShapeB = EarShape.ConnectedEarlobe;
                break;
        }
       
        //eyebrow
        switch (UnityEngine.Random.Range(0, 4))
        {
            case 0:
                sampleGene.EyebrowA = Eyebrow.Arched;
                sampleGene.EyebrowB = Eyebrow.Arched;
                break;
            case 1:
                sampleGene.EyebrowA = Eyebrow.Straight;
                sampleGene.EyebrowB = Eyebrow.Straight;
                break;
            case 2:
                sampleGene.EyebrowA = Eyebrow.Thick;
                sampleGene.EyebrowB = Eyebrow.Thick;
                break;
            case 3:
                sampleGene.EyebrowA = Eyebrow.Emo;
                sampleGene.EyebrowB = Eyebrow.Emo;
                break;
            default:
                sampleGene.EyebrowA = Eyebrow.Straight;
                sampleGene.EyebrowB = Eyebrow.Straight;
                break;
        }
        
        return sampleGene;

    }

    void MixGenes()
    {
        //Faceshape
        personGenes.FaceShapeA = aAppaerance.FaceShape;
        personGenes.FaceShapeB = bAppearance.FaceShape;

        //NOSE SHAPE
        personGenes.NoseShapeA = aAppaerance.NoseShape;
        personGenes.NoseShapeB = bAppearance.NoseShape;

        //skincolor
        personGenes.SkinToneA = aAppaerance.SkinColor;
        personGenes.SkinToneB = bAppearance.SkinColor;

        //eyecolor
        if (UnityEngine.Random.Range(0, 1f) < 0.5f)
            personGenes.EyeColorA = aGenes.EyeColorA;
        else
            personGenes.EyeColorA = aGenes.EyeColorB;
        if (UnityEngine.Random.Range(0, 1f) < 0.5f)
            personGenes.EyeColorB = bGenes.EyeColorA;
        else
            personGenes.EyeColorB = bGenes.EyeColorB;

        //Eyeshape
        if (UnityEngine.Random.Range(0, 1f) < 0.5f)
            personGenes.EyeShapeA = aGenes.EyeShapeA;
        else
            personGenes.EyeShapeA = aGenes.EyeShapeB;
        if (UnityEngine.Random.Range(0, 1f) < 0.5f)
            personGenes.EyeShapeB = bGenes.EyeShapeA;
        else
            personGenes.EyeShapeB = bGenes.EyeShapeB;

        //Haircolor
        personGenes.HairColorA = aAppaerance.HairColor;
        personGenes.HairColorB = bAppearance.HairColor;

        switch (UnityEngine.Random.Range(0,4))
        {
            case 1:
                personGenes.HairColorC = aGenes.HairColorA;
                break;
            case 2:
                personGenes.HairColorC = aGenes.HairColorB;
                break;
            case 3:
                personGenes.HairColorC = aGenes.HairColorC;
                break;
            case 4:
                personGenes.HairColorC = aGenes.HairColorD;
                break;
            default:
                personGenes.HairColorC = aGenes.HairColorD;
                break;
        }
        switch (UnityEngine.Random.Range(0,4))
        {
            case 1:
                personGenes.HairColorD = bGenes.HairColorA;
                break;
            case 2:
                personGenes.HairColorD = bGenes.HairColorB;
                break;
            case 3:
                personGenes.HairColorD = bGenes.HairColorC;
                break;
            case 4:
                personGenes.HairColorD = bGenes.HairColorD;
                break;
            default:
                personGenes.HairColorD = bGenes.HairColorD;
                break;
        }

        //hairtexture
        personGenes.HairTextureA = aAppaerance.HairTexture;
        personGenes.HairTextureB = bAppearance.HairTexture;

        switch (UnityEngine.Random.Range(0, 4))
        {
            case 1:
                personGenes.HairTextureC = aGenes.HairTextureA;
                break;
            case 2:
                personGenes.HairTextureC = aGenes.HairTextureB;
                break;
            case 3:
                personGenes.HairTextureC = aGenes.HairTextureC;
                break;
            case 4:
                personGenes.HairTextureC = aGenes.HairTextureD;
                break;
            default:
                personGenes.HairTextureC = aGenes.HairTextureD;
                break;
        }
        switch (UnityEngine.Random.Range(0, 4))
        {
            case 1:
                personGenes.HairTextureD = bGenes.HairTextureA;
                break;
            case 2:
                personGenes.HairTextureD = bGenes.HairTextureB;
                break;
            case 3:
                personGenes.HairTextureD = bGenes.HairTextureC;
                break;
            case 4:
                personGenes.HairTextureD = bGenes.HairTextureD;
                break;
            default:
                personGenes.HairTextureD = bGenes.HairTextureD;
                break;
        }

        //earshape
        personGenes.EarShapeA = aAppaerance.EarShape;
        personGenes.EarShapeB = bAppearance.EarShape;

        //eyebrow
        personGenes.EyebrowA = aAppaerance.Eyebrow;
        personGenes.EyebrowB = bAppearance.Eyebrow;
    }

    void SetAppearance()
    {
        spriteRenderers.Body.sprite = Resources.Load<Sprite>("Body/" + appaerance.SkinColor.ToString());
        spriteRenderers.Head.sprite = Resources.Load<Sprite>(appaerance.FaceShape.ToString() + "/" + appaerance.SkinColor.ToString());
        spriteRenderers.Ears.sprite = Resources.Load<Sprite>(appaerance.EarShape.ToString() + "/" + appaerance.SkinColor.ToString());
        spriteRenderers.Nose.sprite = Resources.Load<Sprite>("Nose/" + appaerance.NoseShape.ToString() + "/" + appaerance.SkinColor.ToString());
        spriteRenderers.Eyes.sprite = Resources.Load<Sprite>("Eyes/" + appaerance.EyeShape.ToString() + "/" + appaerance.EyeColor.ToString() + "/" + appaerance.SkinColor.ToString());
        spriteRenderers.BGHair.sprite = Resources.Load<Sprite>("Hair/BG/" + appaerance.HairTexture.ToString() + "/" + appaerance.HairColor.ToString());
        spriteRenderers.FrontHair.sprite = Resources.Load<Sprite>("Hair/Front/" + appaerance.HairTexture.ToString() + "/" + appaerance.HairColor.ToString());
        spriteRenderers.Eyebrow.sprite = Resources.Load<Sprite>("Eyebrow/" + appaerance.Eyebrow.ToString());
    }

}
