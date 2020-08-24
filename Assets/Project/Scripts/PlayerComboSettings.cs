using UnityEngine;
using System.Collections;

public class PlayerComboSettings : MonoBehaviour
{
    public string[] lightAttackArr = new string[] { "LightAttack1L1", "LightAttack2L2", "LightAttack3L3" };
    public string[] heavyAttackArr = new string[] { "HeavyAttack1L1", "HeavyAttack2L2", "HeavyAttack3L3" };
    public string idleStateName = "RedIdle";
    public LayerMask whatIsEnemy;
    public bool canDamage;

    [Header("LightAttack1L1 Properties")]
    public Transform lightAttack1L1AttackPosition;
    public float lightAttack1L1AttackRangeX;
    public float lightAttack1L1AttackRangeY;

    [Header("LightAttack2L2 Properties")]
    public Transform lightAttack2L2AttackPosition;
    public float lightAttack2L2AttackRangeX;
    public float lightAttack2L2AttackRangeY;

    [Header("LightAttack3L3 Properties")]
    public Transform lightAttack3L3AttackPosition;
    public float lightAttack3L3AttackRangeX;
    public float lightAttack3L3AttackRangeY;

    [Header("HeavyAttack1L1 Properties")]
    public Transform heavyAttack1L1AttackPosition;
    public float heavyAttack1L1AttackRangeX;
    public float heavyAttack1L1AttackRangeY;

    [Header("HeavyAttack2L2 Properties")]
    public Transform heavyAttack2L2AttackPosition;
    public float heavyAttack2L2AttackRangeX;
    public float heavyAttack2L2AttackRangeY;

    private string selectecAttack;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        damage();
    }

    void damage()
    {
        if(canDamage)
        {
            Collider2D[] frontEnemiesToDamage = new Collider2D[] { };

            switch(selectecAttack)
            {
                case "LightAttack1L1":
                    frontEnemiesToDamage = Physics2D.OverlapBoxAll(lightAttack1L1AttackPosition.position, new Vector2(lightAttack1L1AttackRangeX, lightAttack1L1AttackRangeY), 0, whatIsEnemy);
                    break;
                case "LightAttack2L2":
                    frontEnemiesToDamage = Physics2D.OverlapBoxAll(lightAttack2L2AttackPosition.position, new Vector2(lightAttack2L2AttackRangeX, lightAttack2L2AttackRangeY), 0, whatIsEnemy);
                    break;
                case "LightAttack3L3":
                    frontEnemiesToDamage = Physics2D.OverlapBoxAll(lightAttack3L3AttackPosition.position, new Vector2(lightAttack3L3AttackRangeX, lightAttack3L3AttackRangeY), 0, whatIsEnemy);
                    break;

                case "HeavyAttack1L1":
                    frontEnemiesToDamage = Physics2D.OverlapBoxAll(heavyAttack1L1AttackPosition.position, new Vector2(heavyAttack1L1AttackRangeX, heavyAttack1L1AttackRangeY), 0, whatIsEnemy);
                    break;
                case "HeavyAttack2L2":
                    frontEnemiesToDamage = Physics2D.OverlapBoxAll(heavyAttack2L2AttackPosition.position, new Vector2(heavyAttack2L2AttackRangeX, heavyAttack2L2AttackRangeY), 0, whatIsEnemy);
                    break;
                case "HeavyAttack3L3":
                    //As this is a projectile attack.
                    break;
            }

            foreach (Collider2D enemy in frontEnemiesToDamage)
            {
                Debug.Log(enemy.gameObject.name);
            }

            canDamage = false;
        }
    }

    public void setActiveAttack(bool isActive, string attackName)
    {
        selectecAttack = attackName;
        canDamage = true;
    }

    public string getAttack(int comboNum, int lastAttackType)
    {
        if(lastAttackType == 1)
        {
            return lightAttackArr[comboNum];
        } else
        {
            return heavyAttackArr[comboNum];
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(lightAttack1L1AttackPosition.position, new Vector3(lightAttack1L1AttackRangeX, lightAttack1L1AttackRangeY, 1));
        Gizmos.DrawWireCube(lightAttack2L2AttackPosition.position, new Vector3(lightAttack2L2AttackRangeX, lightAttack2L2AttackRangeY, 1));
        Gizmos.DrawWireCube(lightAttack3L3AttackPosition.position, new Vector3(lightAttack3L3AttackRangeX, lightAttack3L3AttackRangeY, 1));

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(heavyAttack1L1AttackPosition.position, new Vector3(heavyAttack1L1AttackRangeX, heavyAttack1L1AttackRangeY, 1));
        Gizmos.DrawWireCube(heavyAttack2L2AttackPosition.position, new Vector3(heavyAttack2L2AttackRangeX, heavyAttack2L2AttackRangeY, 1));
    }
}
