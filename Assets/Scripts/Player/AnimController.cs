using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    public Animator animator;
    public GameObject effect;

    private void Start()
    {
        effect.SetActive(false);
    }

    public void SetGrab(bool state)
    {
        animator.SetBool("Grab", state);
        if(state)
        {
            effect.SetActive(true);
        }
        else
        {
            effect.SetActive(false);
        }
    }

    public void SetDamage(bool state)
    {
        animator.SetBool("Damage", state);
    }

    public IEnumerator Damage2()
    {
        animator.SetBool("Damage", true);
        yield return new WaitForSeconds(1f);
        animator.SetBool("Damage", false);
    }

    public void Damage()
    {
        StartCoroutine(Damage2());
    }
}