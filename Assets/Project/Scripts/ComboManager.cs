using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour
{
    public static ComboManager instance;
    public bool canReceiveInput;
    public bool inputReceived;

    private PlayerComboSettings playerComboSettings;
    private PlayerRed player;

    private int comboNum;
    private int activeComboNum;
    private int lastAttackType;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerComboSettings = gameObject.GetComponent<PlayerComboSettings>();
        player = gameObject.GetComponent<PlayerRed>();
    }

    // Update is called once per frame
    void Update()
    {
        attack();
    }

    public void attack()
    {
        if(Input.GetButtonDown("LightAttack"))
        {
            if (canReceiveInput)
            {
                inputReceived = true;
                canReceiveInput = false;
                lastAttackType = 1;
            } else
            {
                return;
            }
        }

        if(Input.GetButtonDown("HeavyAttack"))
        {
            if (canReceiveInput)
            {
                inputReceived = true;
                canReceiveInput = false;
                lastAttackType = 2;
            }
            else
            {
                return;
            }
        }
    }

    public void inputManager()
    {
        canReceiveInput = !canReceiveInput;
    }

    public string getAttackName()
    {
        string attackName = null;
        if (ComboManager.instance.inputReceived)
        {
            ComboManager.instance.inputManager();
            ComboManager.instance.inputReceived = false;
            attackName = playerComboSettings.getAttack(comboNum, lastAttackType);
            activeComboNum = comboNum;
            comboNum++;
        }
        if(comboNum == 3)
        {
            comboNum = 0;
        }
        return attackName;
    }

    public void resetCombo()
    {
        comboNum = 0;
    }

    public string getIdleStateName()
    {
        return playerComboSettings.idleStateName;
    }

    public void setCanDamageEnemy(bool canDamage)
    {
        
        playerComboSettings.canDamage = canDamage;
    }

    public void setActiveAttack(bool isActive)
    {
        string attackName = playerComboSettings.getAttack(activeComboNum, lastAttackType);
        playerComboSettings.setActiveAttack(isActive, attackName);
    }

    public void setMovementSpeedPercentDuringAttack(float speedPercent)
    {
        player.setMovementSpeedPercent(speedPercent);
    }

    public void setIfDodgeIsEnabled(bool isDodgeEnabled)
    {
        player.setIsDodgeEnabled(isDodgeEnabled);
    }
}
