using UnityEngine;
using UnityEngine.Events;


public class Timer : MonoBehaviour
{

    private float currentTime = 0;

    [SerializeField]
    private float timeOut = 10;

    private bool end = false;


    public float CurrentTime { get { return currentTime; } }
    public float RemainingTime { get { return timeOut - currentTime; } }

    [SerializeField]
    private UnityEvent onTimeOut;

    public static bool paused = false;

    public event TimeUpdate OnTimeUpdate;
    public delegate void TimeUpdate();

    public bool reset = false;

    public void AddTime(float time)
    {

        currentTime -= time;

    }

    // Update is called once per frame
    void Update()
    {
        if (paused) return;
        if (end) return;


        currentTime += Time.deltaTime;
        OnTimeUpdate?.Invoke();

        if (currentTime > timeOut)
        {

            onTimeOut.Invoke();
            if (reset)
                currentTime = 0;
            else
                end = true;





        }
    }
    
}
