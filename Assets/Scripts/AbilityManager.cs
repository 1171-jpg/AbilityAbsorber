using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


// reads player input (1, 2, 3) to select ability.
public class AbilityManager : MonoBehaviour
{
    public string selectedAbility = "none"; // options: fire, screech, glue, ram, electric, magnet
    public float absorbRadius = 3f;
    public GameObject MessageToPlayer;
    public GameObject flame; 
    public GameObject flare; 
    public GameObject batForm;
    public GameObject glueForm;
    public GameObject rockForm;
    public GameObject electronicForm;
    public GameObject magnetForm;
    public GameObject ghostForm;
    public GameObject UIActiveBat;
    public GameObject UIActiveFire;
    public GameObject UIActiveRock;
    public GameObject UIActiveGlue;
    public GameObject UIActiveGhost;
    public GameObject UIActiveElectric;
    public GameObject UIActiveMagnet;
    private PlayerController playerController;
    public Healthbar healthBar;
    private PlayerMovement playerMovement;
    public List<string> abilityInventory = new List<string>();
    
    void Start() {
        playerController = GetComponent<PlayerController>();
        playerMovement = GetComponent<PlayerMovement>();
        healthBar.setHealthBar("none", 7);
    }

    public string getSelectedAbility() {
        return selectedAbility;
    }

    void setAllFormsFalse() {
        // completely reset player's form/UI
        batForm.SetActive(false);
        UIActiveBat.SetActive(false);
        playerController.isBat = false;
        glueForm.SetActive(false);
        rockForm.SetActive(false);
        ghostForm.SetActive(false);
        electronicForm.SetActive(false);
        flare.SetActive(false);
        flame.SetActive(false);
        UIActiveFire.SetActive(false);
        magnetForm.SetActive(false);
        playerMovement.setSpeed(5f);
        UIActiveRock.SetActive(false);
        UIActiveGlue.SetActive(false); 
        UIActiveGhost.SetActive(false);
        UIActiveElectric.SetActive(false); 
        UIActiveMagnet.SetActive(false);
    }
    

    void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha0)) {
            setAllFormsFalse();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (abilityInventory.Count > 0)
            {
                selectedAbility = abilityInventory[0];
                switchAbility(selectedAbility);
            }
        } 
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (abilityInventory.Count > 1)
            {
                selectedAbility = abilityInventory[1];
                switchAbility(selectedAbility);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (abilityInventory.Count > 2)
            {
                selectedAbility = abilityInventory[2];
                switchAbility(selectedAbility);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (abilityInventory.Count > 3)
            {
                selectedAbility = abilityInventory[3];
                switchAbility(selectedAbility);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (abilityInventory.Count > 4)
            {
                selectedAbility = abilityInventory[4];
                switchAbility(selectedAbility);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            if (abilityInventory.Count > 5)
            {
                selectedAbility = abilityInventory[5];
                switchAbility(selectedAbility);
            }
        }

        // Absorb ability
        if (Input.GetKeyDown(KeyCode.E)) {
            checkNearbyAbilityAvailable("Campfire", "fire");
            checkNearbyAbilityAvailable("BatEnemy", "screech");
            checkNearbyAbilityAvailable("Glue", "glue");
            checkNearbyAbilityAvailable("RockEnemy", "ram");
            checkNearbyAbilityAvailable("Electronic", "electric");
            checkNearbyAbilityAvailable("Magnet", "magnet");
            checkNearbyAbilityAvailable("Tombstone", "stealth");

        }
        checkShouldGlow("Campfire", "fire");
        checkShouldGlow("BatEnemy", "screech");
        checkShouldGlow("Glue", "glue");
        checkShouldGlow("RockEnemy", "ram");
        checkShouldGlow("Electronic", "electric");
        checkShouldGlow("Magnet", "magnet");
        checkShouldGlow("Tombstone", "stealth");
    }

    // for example, check if campfire is nearby enough to absorb fire ability

    public void switchAbility(string selectedAbility)
    {
        ShowDamage[] showDamages = GetComponentsInChildren<ShowDamage>();
        foreach(ShowDamage showDamage in showDamages)
        {
            showDamage.resetColor();
        }
        switch (selectedAbility)
        {
            case "fire":
                setAllFormsFalse();

                // set everything to fire
                selectedAbility = "fire";
                Debug.Log("selected ability changed to " + selectedAbility);
                flare.SetActive(true);
                flame.SetActive(true);
                UIActiveFire.SetActive(true);
                healthBar.setHealthBar("fire", 10f);
                break;
            case "screech":
                setAllFormsFalse();

                // set everything to screech/bat
                selectedAbility = "screech";
                Debug.Log("selected ability changed to " + selectedAbility);
                batForm.SetActive(true);
                playerController.isBat = true;
                healthBar.setHealthBar("screech",2f);
                UIActiveBat.SetActive(true);
                playerMovement.setSpeed(10f); // speed up 
                break;
            case "glue":
                setAllFormsFalse();

                // set everything to glue
                selectedAbility = "glue";
                Debug.Log("selected ability changed to " + selectedAbility);
                glueForm.SetActive(true);
                UIActiveGlue.SetActive(true);
                healthBar.setHealthBar("glue",7f);
                playerMovement.setSpeed(1f); // slow down
                break;
            case "ram":
                setAllFormsFalse();

                // set everything to ram
                selectedAbility = "ram";
                Debug.Log("selected ability changed to " + selectedAbility);
                rockForm.SetActive(true);
                UIActiveRock.SetActive(true);
                healthBar.setHealthBar("ram", 7f);
                break;

            case "electric":
                setAllFormsFalse();

                // set everything to electric
                selectedAbility = "electric";
                Debug.Log("selected ability changed to " + selectedAbility);
                electronicForm.SetActive(true);
                UIActiveElectric.SetActive(true);
                healthBar.setHealthBar("electric", 7f);
                break;

            case "magnet":
                setAllFormsFalse();

                // set everything to magnet
                selectedAbility = "magnet";
                Debug.Log("selected ability changed to " + selectedAbility);
                magnetForm.SetActive(true);
                UIActiveMagnet.SetActive(true);
                healthBar.setHealthBar("magnet", 7f);
                break;
            case "stealth":
                setAllFormsFalse();

                // set everything to magnet
                selectedAbility = "stealth";
                Debug.Log("selected ability changed to " + selectedAbility);
                ghostForm.SetActive(true);
                UIActiveGhost.SetActive(true);
                healthBar.setHealthBar("stealth", 12f);
                break;
        }
    }

    void checkShouldGlow(string tag, string ability)
    {
        Vector3 positionToCheck = transform.position;
        GameObject[] abilityObjects = GameObject.FindGameObjectsWithTag(tag); // Find objects by tag
        foreach (GameObject abilityObject in abilityObjects)
        {
            if (abilityObject == null)
            {
                continue;
            }
            bool isAbsorbable= true;
            //checks if enemies are dead (can be absorbed)
            switch (tag)
            {
                case "BatEnemy":
                    if (!abilityObject.GetComponent<Bat>().getIsCorpse())
                        isAbsorbable = false;
                    break;
                case "RockEnemy":
                    if (!abilityObject.GetComponent<Level2_Rock>().getIsCorpse())
                        isAbsorbable = false;
                    break;
                case "Electronic":
                    if (!abilityObject.GetComponent<Thunder>().isBroken)
                        isAbsorbable = false;
                    break;
                case "Magnet":
                    if (abilityObject.GetComponent<MagnetEnemy>().getIsAlive())
                        isAbsorbable = false;
                    break;
            }
            Vector3 abilityObjectPosition = abilityObject.transform.position;
            float distance = Vector3.Distance(positionToCheck, abilityObjectPosition);

            if (distance <= absorbRadius && !abilityInventory.Contains(ability) && isAbsorbable)
            {
                GlowWhenNear g = abilityObject.GetComponent<GlowWhenNear>();
                if (g != null) {
                    g.glow = true;
                }
            }
            else
            {
                if (abilityObject.GetComponent<GlowWhenNear>() != null)
                {
                    abilityObject.GetComponent<GlowWhenNear>().glow = false;
                    abilityObject.GetComponent<GlowWhenNear>().reset();
                }
            }
        }
    }

    void checkNearbyAbilityAvailable(string tag, string ability) {
        Vector3 positionToCheck = transform.position;
        GameObject[] abilityObjects = GameObject.FindGameObjectsWithTag(tag); // Find objects by tag

        foreach (GameObject abilityObject in abilityObjects)
        {
            Vector3 abilityObjectPosition = abilityObject.transform.position;
            float distance = Vector3.Distance(positionToCheck, abilityObjectPosition);

            if (distance <= absorbRadius)
            {
                if (!abilityInventory.Contains(ability))
                {
                    if (ability.Equals("fire"))
                    {
                        abilityInventory.Add(ability);
                        MessageToPlayer messageToPlayer = MessageToPlayer.GetComponent<MessageToPlayer>();
                        int slotAddedTo = abilityInventory.Count;
                        messageToPlayer.DisplayAbilityUnlocked("fire", slotAddedTo);
                    }
                    else if (ability.Equals("screech") && abilityObject.GetComponent<Bat>().getIsCorpse())
                    {
                        abilityInventory.Add(ability);
                        MessageToPlayer messageToPlayer = MessageToPlayer.GetComponent<MessageToPlayer>();
                        int slotAddedTo = abilityInventory.Count;
                        messageToPlayer.DisplayAbilityUnlocked("screech", slotAddedTo);
                    }
                    else if (ability.Equals("glue"))
                    {
                        abilityInventory.Add(ability);
                        MessageToPlayer messageToPlayer = MessageToPlayer.GetComponent<MessageToPlayer>();
                        int slotAddedTo = abilityInventory.Count;
                        messageToPlayer.DisplayAbilityUnlocked("glue", slotAddedTo);
                    }
                    else if (ability.Equals("ram") && abilityObject.GetComponent<Level2_Rock>().getIsCorpse())
                    {
                        abilityInventory.Add(ability);
                        MessageToPlayer messageToPlayer = MessageToPlayer.GetComponent<MessageToPlayer>();
                        int slotAddedTo = abilityInventory.Count;
                        messageToPlayer.DisplayAbilityUnlocked("ram", slotAddedTo);
                    }
                    else if (ability.Equals("electric") && abilityObject.GetComponent<Thunder>().isBroken)
                    {
                        abilityInventory.Add(ability);
                        MessageToPlayer messageToPlayer = MessageToPlayer.GetComponent<MessageToPlayer>();
                        int slotAddedTo = abilityInventory.Count;
                        messageToPlayer.DisplayAbilityUnlocked("electric", slotAddedTo);
                    }
                        
                    else if (ability.Equals("magnet") && !abilityObject.GetComponent<MagnetEnemy>().getIsAlive())
                    {
                        abilityInventory.Add(ability);
                        MessageToPlayer messageToPlayer = MessageToPlayer.GetComponent<MessageToPlayer>();
                        int slotAddedTo = abilityInventory.Count;
                        messageToPlayer.DisplayAbilityUnlocked("magnet", slotAddedTo);
                    }
                        
                    else if (ability.Equals("stealth"))
                    {
                        abilityInventory.Add(ability);
                        MessageToPlayer messageToPlayer = MessageToPlayer.GetComponent<MessageToPlayer>();
                        int slotAddedTo = abilityInventory.Count;
                        messageToPlayer.DisplayAbilityUnlocked("stealth", slotAddedTo);
                    }
                        
                    //if ghost ability is chosen in the ability selection ui , then display a message 
                }
            }
        }
    }
}

