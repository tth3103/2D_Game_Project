using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LifeCount : MonoBehaviour
{
    public int lifeRemaining = 3;
    public Animator anim;
    public void LifeLost()
    {
        if (lifeRemaining == 0)
        {
            GameOver();
        }
        else
        {
            lifeRemaining--;
        }
    }
    public void LifeGain()
    {
        if (lifeRemaining == 3)
        {
            return;
        }
        else
        {
            lifeRemaining++;
        }
    }
    public void LifeBarAnimation()
    {
        anim.SetInteger("LifeRemaining", lifeRemaining);
    }
    private void Update()
    {
       LifeBarAnimation();
    }
    public void GameOver() {
        SceneManager.LoadScene("Result");
    }
}
