using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GigaDeathBHeadCannon : EnemyScript
{

    public bool broken = false;
    public GameObject projectile;
    private float startLoading = 0;
    private bool shoot = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Attack(){
        if(!broken){
            startLoading = Time.time; 
            shoot = true;
        }
    
    }
}
