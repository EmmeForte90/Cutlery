using UnityEngine;

public class loading : MonoBehaviour
{
    public int Time;
    public LevelChanger Function;
    public void Start()
    {Function.LoadingEnd(); GameManager.instance.NotTouchOption = true;}
}