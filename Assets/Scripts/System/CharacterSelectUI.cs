using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;
using UnityEngine.UI;

public class CharacterSelectUI : MonoBehaviour
{
    public GameObject _player;
    public Sprite _knight;
    public Sprite _elf;

    private int _CharacterIndex = 0;

    public void CharacterToggle()
    {
        _CharacterIndex = (_CharacterIndex == 0) ? 1 : 0;

        if (_CharacterIndex == 0)
        {
            gameObject.transform.Find("SelectImage").GetComponent<Image>().sprite = _knight;
            _player.transform.Find("MainSprite").GetComponent<SpriteLibrary>().spriteLibraryAsset = Resources.Load<SpriteLibraryAsset>("PlayerSpriteLibrary/Knight");
        }
        if (_CharacterIndex == 1)
        {
            gameObject.transform.Find("SelectImage").GetComponent<Image>().sprite = _elf;
            _player.transform.Find("MainSprite").GetComponent<SpriteLibrary>().spriteLibraryAsset = Resources.Load<SpriteLibraryAsset>("PlayerSpriteLibrary/Elf");
        }
    }
}
