using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DateTimeUI : MonoBehaviour
{
    public TMP_Text _dateTimeTxt;

    private string DateTimeUpdate()
    {
        return DateTime.Now.ToString(("HH:mm"));
    }

    private void Update()
    {
        _dateTimeTxt.text = DateTimeUpdate();
    }
}
