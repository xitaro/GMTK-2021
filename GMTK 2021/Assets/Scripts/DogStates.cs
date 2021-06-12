using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogStates : MonoBehaviour
{
    private int state;

    private void Start()
    {
        state = 3;
    }

    public void IncreaseState()
    {
        state += 1;
    }

    public void DecreaseState()
    {
        state -= 1;
        CheckState();
    }

    private void CheckState()
    {
        if (state == 0)
        {
            //Game Over
        }
    }


}
