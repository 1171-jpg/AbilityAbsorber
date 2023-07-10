using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitySelectionManager : MonoBehaviour
{
    private string selectedAbility;
    public GameObject abilityChoicePanel;
    private AbilityManager abilityManager;

    void Start() 
    {
        abilityManager = GetComponent<AbilityManager>();
    
    }
        

    public void SelectFireAbility()
    {
        selectedAbility = "fire";
        abilityManager.unlockedAbilities["fire"] = true;
        abilityChoicePanel.SetActive(false);
        Debug.Log("Fire ability activated");
    }

    public void SelectBatAbility()
    {
        selectedAbility = "screech";
        abilityManager.unlockedAbilities["screech"] = true;
        abilityChoicePanel.SetActive(false);
        Debug.Log("Screech ability activated");
    }
}