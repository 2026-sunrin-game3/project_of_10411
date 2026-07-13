using UnityEngine;

public class Boss : Enemy
{
    [SerializeField] AttackRange defaultAttack;

    [SerializeField] PlayerController player;
    public float attackDist = 1.5f;


    // Update is called once per frame
    protected override void MobUpdate()
    {
        if (Vector2.Distance(player.transform.position,transform.position) < attackDist)
        {
            Attack(0.5f,defaultAttack,transform.position);
        }
        else
        {
            Chase(player.transform);
        }
    }
    protected override void DrawGizmos()
    {
        Draw(defaultAttack);
    }
}
