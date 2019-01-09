using Persistence;
using TMPro;
using UnityEngine;

public class TimeTextController: MonoBehaviour, ITimeListener
{
    public static TimeTextController Instance;
    
    private TextMeshProUGUI _text;
    
    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        Instance = this;
    }

    public void ExecuteAwake()
    {
        DayTime.Instance.AddTimeListener(this);
    }
    
    private void Refresh()
    {
        _text.text = DayTime.Instance.ToString();
    }
    
    public void TimePassed()
    {
        Refresh();
    }

    public void HourPassed()
    {
        
    }
}