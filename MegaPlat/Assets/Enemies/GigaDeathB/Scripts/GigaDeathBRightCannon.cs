using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GigaDeathBRightCannon : EnemyScript
{
    public bool broken = false;
    public GameObject projectile;
    private float startLoading = 0;
    private bool shoot = false;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - startLoading > 1 && shoot){
            shoot = false;
            Instantiate(projectile, transform.position, new Quaternion());
        }
    }

    public override void Attack(){
        if(!broken){
            startLoading = Time.time; 
            shoot = true;
        }
    
    }
}
