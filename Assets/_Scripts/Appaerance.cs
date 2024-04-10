using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Appaerance
{
    public FaceShape FaceShape;
    public NoseShape NoseShape;
    public SkinColor SkinColor;
    public EyeShape EyeShape;
    public EyeColor EyeColor;
    public HairColor HairColor;
    public HairTexture HairTexture;
    public EarShape EarShape;
    public Eyebrow Eyebrow;

}

[Serializable]
public class SpriteRenderers
{
    public SpriteRenderer Body;
    public SpriteRenderer Head;
    public SpriteRenderer Ears;
    public SpriteRenderer Nose;
    public SpriteRenderer Eyes;
    public SpriteRenderer BGHair;
    public SpriteRenderer FrontHair;
    public SpriteRenderer Eyebrow;
}
