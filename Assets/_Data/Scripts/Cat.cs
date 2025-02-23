using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : FourLeg
{
    public override string GetName()
    {
        return "Cat";
    }

    public override string MakeSound()
    {
        string sound = "meow meow";
        return sound;
    }

}
