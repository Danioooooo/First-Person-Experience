using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using System.Collections;

//Base script for regular enemies
public class EnemyAI : MonoBehaviour
{
    //References
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    private Animator anim;
    private EnemyDeathHandler enemyHandler;
    private ScoreManager scoreScript;
    private GameManager gameManager;
    public AudioSource alienHit;
    public AudioSource alienDeath;

    //Walk variables
    public Vector3 walkPoint;
    private bool walkPointSet;
    public float walkPointRange;

    //Attack variables
    public float timeBetweenAttacks;
    private bool alreadyAttacked;
    public GameObject projectile;
    public Transform firepoint;
    public int enemyAmmo;
    private int enemyUsableAmmo;
    public float reloadTime;

    //Detection variables
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    //Feedback variables
    private float health;
    public float maxHealth;
    public GameObject healthbarUI;
    public Slider slider;
    public float healthbarDisplayTime = 3f;
    public int scoreForKill;
    
    void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();

        health = maxHealth;
        slider.value = CalculateHealth();

        anim = GetComponent<Animator>();

        enemyHandler = GetComponent<EnemyDeathHandler>();

        scoreScript = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        enemyUsableAmmo = enemyAmmo;

        gameManager.UpdateEnemyCount(1);
    }

    void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) 
        {
            Patrolling();
        }

        if (playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
        }

        if (playerInAttackRange && playerInSightRange)
        {
            AttackPlayer();
        }
        
        slider.value = CalculateHealth();

        //Safety measure if enemy somehow overheals
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    void Patrolling()
    {
        anim.SetBool("AlienWalking", true);
        anim.SetBool("AlienShooting", false);

        if (!walkPointSet) 
        {
            SearchWalkPoint();
        }

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 1f, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    void AttackPlayer()
    {
        anim.SetBool("AlienShooting", true);
        anim.SetBool("AlienWalking", false);

        //Make sure enemy doesnt move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (enemyUsableAmmo <= 0)
        {
            StartCoroutine(Reload());
        }

        if (!alreadyAttacked && enemyUsableAmmo > 0)
        {
            //Attack code
            Rigidbody rb = Instantiate(projectile, firepoint.position, Quaternion.identity).GetComponent<Rigidbody>();
            anim.Play("AlienShootState", 0, 0f);
            enemyUsableAmmo --;

            rb.AddForce(transform.forward * 90f, ForceMode.Impulse);
            rb.AddForce(-transform.up * 2f, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    void ResetAttack()
    {
        alreadyAttacked = false;
    }
    
    public void TakeDamage(float damage)
    {
        health -= damage;
        StartCoroutine(DisplayHealthbar());
        alienHit.Play();

        //Enemy death
        if (health <= 0)
        {
            alienDeath.Play();
            scoreScript.AddScore(scoreForKill);
            gameManager.UpdateEnemyCount(-1);
            enemyHandler.EnemyDeath();
            anim.SetBool("AlienDied", true);
        }
    }

    float CalculateHealth()
    {
        return health / maxHealth;
    }

    IEnumerator DisplayHealthbar()
    {
        //Don't display healthbar if enemy died from attack
        if (health <= 0)
        {
            healthbarUI.SetActive(false);
        }

        //Display as normal
        else
        {
            healthbarUI.SetActive(true);
            yield return new WaitForSeconds(healthbarDisplayTime);
            healthbarUI.SetActive(false);
        }
    }

    IEnumerator Reload()
    {
        anim.SetBool("AlienShooting", false);
        anim.SetBool("AlienReloading", true);
        yield return new WaitForSeconds(reloadTime);
        enemyUsableAmmo = enemyAmmo;
        anim.SetBool("AlienReloading", false);
    }
}
