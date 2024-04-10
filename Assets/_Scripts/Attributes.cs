using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleGene
{
    public string Name;
    public bool Dominant;
    public bool Weak;
    public Sprite Appearance;

    public SingleGene(string name, bool dominant, bool weak)
    {
        Name = name;
        Dominant = dominant;
        Weak = weak;
    }

    public SingleGene() { }
}

public enum FaceShape
{
    Square, Heart, Oval
}

public enum NoseShape
{
    Button, Hook, Sharp
}

public enum SkinColor
{
    Light, MediumLight, MediumDark, Dark
}

public enum EyeShape
{
    Round, Square, Sharp, Monolid
}

public enum EyeColor
{
    Brown, Blue, Green
}

public enum HairColor
{
    Blonde, Brunette, Black, Red
}

public enum HairTexture
{
    Curls, TightCurls, Straight, Wavy
}

public enum EarShape
{
    UnconnectedEarlobe, ConnectedEarlobe
}

public enum Eyebrow
{
    Arched, Straight, Thick, Emo
}

