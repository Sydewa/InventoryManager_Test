using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeLanguage : MonoBehaviour
{
    public Scriptable_Text esText;
    public Scriptable_Text enText;
    public Scriptable_Text frText;

    public Text text;

    void Start()
    {
        ChangeToES();
    }

    public void ChangeToES()
    {
        text.text = esText.Text;
    }

    public void ChangeToEN()
    {
        text.text = enText.Text;
    }

    public void ChangeToFR()
    {
        text.text = frText.Text;
    }
}
