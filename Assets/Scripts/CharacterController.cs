using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    public int totalLife;
    
    public Rigidbody basicAttack;
    public Transform attackPosition;
    public float velShoot;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
      if(Input.GetButtonDown("Fire1")){
          AnimateBasicAttack();
      }  
    }

    public void AnimateBasicAttack(){
        anim.SetBool("isBasicAttacking", true);
        
        Rigidbody powerPrefabInst;

        powerPrefabInst = Instantiate(basicAttack, attackPosition.position, Quaternion.identity) as Rigidbody;
        powerPrefabInst.AddForce(attackPosition.forward * 100 * velShoot);
        StartCoroutine(Restart());
    }

    public IEnumerator Restart(){
        yield return new WaitForSecondsRealtime(0.0f);
        anim.SetBool("isBasicAttacking", false);
    }
}
