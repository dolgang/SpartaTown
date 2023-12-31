using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UserNameInitUI : MonoBehaviour
{
    public TMP_Text _userName;

    public TMP_InputField _userNameInput;
    public GameObject _errorMassege;
    public GameObject _characterSelect;
    private string _inputText;

    private void Awake()
    {
        Time.timeScale = 0.0f;
    }

    void Update()
    {
        _inputText = _userNameInput.GetComponent<TMP_InputField>().text;
        
    }

    public void InputCheck()
    {
        if (_inputText.Length >= 2 && _inputText.Length <= 10)
        {
            SetUserName();
        }
        else
        {
            _errorMassege.SetActive(true);
        }
    }

    private void SetUserName()
    {
        _userName.text = _inputText;

        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
        _characterSelect.SetActive(false);
    }
}