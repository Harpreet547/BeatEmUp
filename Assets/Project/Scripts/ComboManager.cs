using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour
{
    public static ComboManager instance;
    public bool canReceiveInput;
    public bool inputReceived;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        canReceiveInput = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("LightAttack"))
        {
            if (canReceiveInput)
            {
                inputReceived = true;
                canReceiveInput = false;
            }
            else
            {
                return;
            }
        }
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
        if(!canReceiveInput)
        {
            canReceiveInput = true;
        } else
        {
            canReceiveInput = false;
        }
    }
}
