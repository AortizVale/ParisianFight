using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterManager : MonoBehaviour
{
    public CharacterDatabase characterDB;

    public TMP_Text nameText1;
    public TMP_Text nameText2;
    public Image menuSprite1;
    public Image menuSprite2;
    public Image menuSpriteSiluette1;
    public Image menuSpriteSiluette2;

    private int selectedCharacter1=0;
    private int selectedCharacter2=0;
    void Start()
    {

    }

    public void SelectCharacter1(int index)
    {
        selectedCharacter1=index;
        UpdateCharcter1(index);
        Save();
    }
    public void SelectCharacter2(int index)
    {
        selectedCharacter2=index;
        UpdateCharcter2(index);
        Save();
    }

    private void UpdateCharcter1(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedCharacter1);
        menuSprite1.sprite = character.characterMenuSprite;
        menuSpriteSiluette1.sprite=character.charaterSiluettePoints;
        nameText1.text = character.characterName;
    }

    private void UpdateCharcter2(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedCharacter1);
        menuSprite2.sprite = character.characterMenuSprite;
        menuSpriteSiluette2.sprite = character.charaterSiluettePoints;
        nameText2.text = character.characterName;
    }

    private void Load()
    {
        selectedCharacter1 = PlayerPrefs.GetInt("selectedCharacter1");
        selectedCharacter2 = PlayerPrefs.GetInt("selectedCharacter2");
    }
    private void Save()
    {
        PlayerPrefs.SetInt("selectedCharacter1", selectedCharacter1);
        PlayerPrefs.SetInt("selectedCharacter2", selectedCharacter2);
    }
}
