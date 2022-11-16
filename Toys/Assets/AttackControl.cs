using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackControl : MonoBehaviour
{
    [SerializeField]
    float damage;

    float AliveTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > AliveTime + 0.5)
        {
            gameObject.SetActive(false);
        }
    }

    public void Active()
    {
        AliveTime = Time.time;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Enemy")
        {
            if(other.GetComponent<Health>() != null)
            {
                other.GetComponent<Health>().DealDamage(damage);
            }
        }
    }
}
