using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Genes
{
    [Header("Face Shape")]
    public FaceShape FaceShapeA;
    public FaceShape FaceShapeB;

    [Header("Nose Shape")]
    public NoseShape NoseShapeA;
    public NoseShape NoseShapeB;

    [Header("Skin Color")]
    public SkinColor SkinToneA;
    public SkinColor SkinToneB;

    [Header("Eye Shape")]
    public EyeShape EyeShapeA;
    public EyeShape EyeShapeB;

    [Header("Eye Color")]
    public EyeColor EyeColorA;
    public EyeColor EyeColorB;

    [Header("Hair Color")]
    public HairColor HairColorA;
    public HairColor HairColorB;
    public HairColor HairColorC;
    public HairColor HairColorD;

    [Header("Hair Texture")]
    public HairTexture HairTextureA;
    public HairTexture HairTextureB;
    public HairTexture HairTextureC;
    public HairTexture HairTextureD;

    [Header("Ear Shape")]
    public EarShape EarShapeA;
    public EarShape EarShapeB;

    [Header("Eyebrow Shape")]
    public Eyebrow EyebrowA;
    public Eyebrow EyebrowB;
}
