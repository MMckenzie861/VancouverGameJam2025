using UnityEngine;
using EasyTextEffects;
using UnityEngine.UIElements;
public class ButtonHover : MonoBehaviour
{
    public TextEffect buttonText;
    // Start t called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnButtonHover()
    {
        buttonText.StartManualEffects();
    }

    public void OnButtonLeave()
    {
        buttonText.StopManualEffects();
    }

}
