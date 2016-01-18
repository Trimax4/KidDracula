using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int timeTf = 0;
    public bool isZero = false;
    public int checkpoint = 0;
    public int interval = 0;

    public void Start()
    {
       InvokeRepeating("AddTime", 1, 1);
    }

    public void AddTime()
    {

        if (timeTf == 0)
        {
            isZero = true;
        }

        timeTf += 1;

        if (getTime() == (checkpoint + 1))
        {
            checkpoint += interval;
        }

    }

    public bool getIsZero()
    {
        return isZero;
    }

    public void setCheckpoint(int time)
    {
        checkpoint = time;
    }

    public bool checkPoint()
    {
        if (checkpoint == timeTf)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public int getTime()
    {
        return timeTf;
    }
}
