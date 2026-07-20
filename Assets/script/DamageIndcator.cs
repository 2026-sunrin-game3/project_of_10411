using UnityEngine;
using UnityEngine.UI;

public class DamageIndcator : MonoBehaviour
{


    [SerializeField] Text text;

    [SerializeField] float time, floatingScale;

    public static DamageIndcator Instance = null;

    void Start()
    {
        Instance = this;

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        
        transform.position += new Vector3(0, 1, 0) * floatingScale * Time.deltaTime;

        if (time > 0.65f)
        {
            Destroy(gameObject);
        }
    }

    public void IndicateDamage(float damage,Vector2 pos,Color color)
    {
        DamageIndcator indicator = GameObject.Instantiate(this, pos, Quaternion.identity);
        indicator.text.text = Mathf.Round(damage).ToString();
        indicator.text.color = color;
    }
}
