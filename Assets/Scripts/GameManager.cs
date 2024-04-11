using UnityEngine;

public class GameManager : MonoBehaviour
{
    public EndingTrigger endingTrigger;

    void Update()
    {
        endingTrigger.GameComplete(); 
    }
}
