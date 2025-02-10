using UnityEngine;
using System;

public class ClockController : MonoBehaviour
{
    public Transform hourHand;
    public Transform minuteHand;
    public Transform secondHand;

    void Update()
    {
        DateTime currentTime = DateTime.Now;

        float hourAngle = (currentTime.Hour % 12 + currentTime.Minute / 60f) * 30f;
        hourHand.localRotation = Quaternion.Euler(0, hourAngle, 0); 

        float minuteAngle = currentTime.Minute * 6f;
        minuteHand.localRotation = Quaternion.Euler(0, minuteAngle, 0); 

        float secondAngle = currentTime.Second * 6f;
        secondHand.localRotation = Quaternion.Euler(0, secondAngle, 0); 
    }
}
