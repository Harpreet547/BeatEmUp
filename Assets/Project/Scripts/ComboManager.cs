using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour
{
    public static ComboManager instance;
    public bool canReceiveInput;
    public bool inputReceived;

    private string[] lightAttackArr = new string[] { "LightAttack1L1", "LightAttack2L2", "LightAttack3L3" };
    private int comboNum;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
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
            if(canReceiveInput)
            {
                inputReceived = true;
                canReceiveInput = false;
            } else
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
            attackName = lightAttackArr[comboNum];
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
        return "RedIdle";
    }
}
