using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] float fullHealth = 100f;
    [SerializeField] AudioSource bulletHitSound;
    [SerializeField] AudioSource rocketHitSound;
    [SerializeField] GameObject criticalDamage;
    private GameObject smoke;
    public void TakeDamage(float amount, int weaponType)
    {
        Debug.Log(weaponType);
       
        if (health < fullHealth / 3)
        {
            if (weaponType == 1)
            {
                Vector3 particlePosition = this.gameObject.transform.position;
                particlePosition.y += 3;
                smoke = Instantiate(criticalDamage, particlePosition, Quaternion.identity);
                smoke.gameObject.tag = "smokeBunker";
            }
        }
        if (weaponType == 0)
        {
            bulletHitSound.Play();
        }
        if (weaponType == 1)
        {
            rocketHitSound.Play();
        }

        health -= amount;
        Debug.Log(health);
        if (health <= 0)
        {
           Die();
        }
    }

    void Die()
    {
        GameObject[] smokes = GameObject.FindGameObjectsWithTag("smokeBunker");
        for(int i=0; i < smokes.Length; i++)
        {
            Destroy(smokes[i], 5f);
        }
        Destroy(this.gameObject);
    }
}
