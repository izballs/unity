using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GigaDeathBMissile : EnemyScript
{
    public GameObject target;
    public float speed;
    public float rotationSpeed;
    private Vector3 direction;
    private float angle;
    private float step;
    private float rotateStep;
    private float timeCount;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        if(target.transform.position.x > transform.position.x)
            direction = transform.right;
        else
            direction = -transform.right;
        isProjectile = true;
    }
    public override void Attack(){
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetDir = target.transform.position - transform.position + offset;
        
        step = speed * Time.deltaTime;
        rotateStep = rotationSpeed * Time.deltaTime;
        
        angle = Vector2.SignedAngle(-transform.right, targetDir);

        Quaternion newRotation = transform.rotation;
        newRotation.eulerAngles += new Vector3(0,0,angle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, rotateStep);
        
        transform.Translate(-step,0,0);
        
    }       
    void FixedUpdate(){
    }

}
