using UnityEngine;

public class PlayerBattle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public EntityHealth health;

    [System.Serializable]
    public struct AttackRange
    {
        public Vector2 offset, size;
        public bool drawGizmos;
    }
    public AttackRange defaultAttack;
    [SerializeField] LayerMask enemyMask;

    void Start()
    {
        health = GetComponent<EntityHealth>();
    }
    public void Attack()
    {
        var col = Physics2D.OverlapBoxAll((Vector2)transform.position + defaultAttack.offset, defaultAttack.size, 0, enemyMask);
        foreach (var target in col)
        {
            EntityHealth hp = target.GetComponent<EntityHealth>();
            if (hp != null)
            {
                hp.GetDamage(3, health);
            }
        }
    }
    void Draw(AttackRange range)
    {
        if (!range.drawGizmos)
            return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube((Vector2)transform.position + range.offset, range.size);
    }
    void OnDrawGizmos()
    {
        Draw(defaultAttack);
    }


}
