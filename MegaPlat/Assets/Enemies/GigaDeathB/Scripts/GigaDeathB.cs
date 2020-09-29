using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GigaDeathB : EnemyScript
{

    private GigaDeathBLeftCannon leftCannon;
    private GigaDeathBHeadCannon headCannon;
    private GigaDeathBRightCannon rightCannon;
    private GigaDeathBMissileHolder missileHolder;
    public GameObject missile;
    public PlayerDetector pd;

    public float missileSpeed;
    public float maxShootDistance = 10f;
    public float maxMissileDistance = 15f;
    private Transform playerTransform;
    private float currentDistance = 0f;
    private bool stopMoving = true;
    private bool moving = false;
    private bool attackInProgress = false;
    private float attackStarted = 0;
    private int attackType = 0;
    private bool randomGenerated = false;
    private int randomInt = 0;
    private int timesShot = 0;
    private float leftCannonShootTime;
    private float rightCannonShootTime;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        leftCannon = GetComponentInChildren<GigaDeathBLeftCannon>();
        rightCannon = GetComponentInChildren<GigaDeathBRightCannon>();
        missileHolder = GetComponentInChildren<GigaDeathBMissileHolder>();
        headCannon = GetComponentInChildren<GigaDeathBHeadCannon>();

    }

    public override void Attack()
    {
        if (currentDistance <= maxMissileDistance)
        {
            //     if(leftCannon.canShoot)
            //       leftCannon.Shoot();
            //  if(RightCannon.canShoot)
            //     rightCannon.Shoot();
            if (missileHolder.canLaunch)
                missileHolder.LaunchMissile(pd.target);
        }
        if (currentDistance <= maxShootDistance && !attackInProgress && !moving)
        {
            if ((!leftCannon.broken || !rightCannon.broken) && !headCannon.broken)
            {
                attackStarted = Time.time;
                attackType = 1;
                attackInProgress = true;

            }
        }

    }

    protected void Move()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (pd.playerDetected)
        {
            playerTransform = pd.target.transform;
        }
        if (playerTransform != null)
        {
            currentDistance = Vector3.Distance(transform.position, playerTransform.position);
            if (currentDistance < maxShootDistance || currentDistance < maxMissileDistance)
                Attack();
            else if (currentDistance > maxShootDistance && !stopMoving)
                Move();
        }
        if (attackInProgress)
        {
            if (attackType == 1)
            {
                if (!randomGenerated)
                {
                    randomInt = Random.Range(1, 3);
                    randomGenerated = true;
                    leftCannonShootTime = attackStarted + 1;
                    rightCannonShootTime = attackStarted + 2;
                }
                if (timesShot < randomInt)
                {
                    if (Time.time - leftCannonShootTime > 1)
                    {
                        leftCannon.Attack();
                        leftCannonShootTime = Time.time + 4;
                    }
                    if (Time.time - rightCannonShootTime > 1)
                    {
                        rightCannon.Attack();
                        rightCannonShootTime = Time.time + 4;
                        timesShot += 1;
                    }
                }
                else
                {
                    headCannon.Attack();
                    randomGenerated= false;
                    timesShot = 0;
                    attackInProgress = false;
                }


            }
        }

    }
}
