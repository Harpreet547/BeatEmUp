using UnityEngine;
using System.Collections;

public class PlayerComboSettings : MonoBehaviour
{
    public string[] lightAttackArr = new string[] { "LightAttack1L1", "LightAttack2L2", "LightAttack3L3" };
    public string idleStateName = "RedIdle";
    public LayerMask whatIsEnemy;

    public Transform lightAttackPosition;
    public float lightAttackRange1X;
    public float lightAttackRange1Y;

    public bool canDamage;
    // Use this for initialization
    void Start()
    {
        //ComboManager.instance.setPlayerComboSettings(lightAttackArr, idleStateName);
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
            Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(lightAttackPosition.position, new Vector2(lightAttackRange1X, lightAttackRange1Y), 0, whatIsEnemy);
            foreach (Collider2D enemy in enemiesToDamage)
            {
                Debug.Log(enemy.gameObject.name);
            }
            canDamage = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(lightAttackPosition.position, new Vector3(lightAttackRange1X, lightAttackRange1Y, 1));
    }
}
