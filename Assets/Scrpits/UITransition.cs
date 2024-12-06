using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class UITransition : MonoBehaviour
{
    public Animator anim;

    public void ToShop()
    {
        anim.Play("UITransition");
    }

    public void ToClicker()
    {
        anim.Play("UIToClicker");
    }
}