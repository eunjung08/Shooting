using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;
    public float speed;

    [SerializeField] GameObject playerBulletAPrefab;
    [SerializeField] GameObject playerBulletBPrefab;
    [SerializeField] GameObject playerBulletCPrefab;
    [SerializeField] GameObject guideBulletPrefab;
    bool canShoot = true;
    public int power = 1;
    public float shootDelay;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() //초당횟수=fps
    {
        Shoot();
        Move();
    }

    private void Move()
    {
        float input_x = Input.GetAxisRaw("Horizontal");
        float input_y = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(input_x, input_y, 0).normalized; //normalized: 단위벡터

        transform.position += dir * speed * Time.deltaTime; //Time.deltaTime: 전프레임에서 현프레임까지 걸린시간

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x > 1) { pos.x = 1; }
        if (pos.x < 0) { pos.x = 0; }
        if (pos.y > 1) { pos.y = 1; }
        if (pos.y < 0) { pos.y = 0; }
        transform.position = Camera.main.ViewportToWorldPoint(pos);

        if(Input.GetButtonDown("Horizontal") || Input.GetButtonUp("Horizontal"))
        {
            animator.SetInteger("Move", (int)input_x);
        }
    }
    void Shoot()
    {
        if(!Input.GetKey(KeyCode.Z)) { return; }
        if (!canShoot) { return; }

        canShoot = false;
        StartCoroutine(ShootDelay());

        switch (power)
        {
            case 1:
                {
                    GameObject bulletA = Instantiate(playerBulletAPrefab);
                    GameObject bulletB = Instantiate(playerBulletBPrefab);
                    bulletA.transform.position = transform.position + Vector3.right * 0.1f;
                    bulletB.transform.position = transform.position + Vector3.left * 0.1f;
                    bulletA.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5, ForceMode2D.Impulse);
                    bulletB.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5, ForceMode2D.Impulse);
                    break;
                }
            case 2:
                {
                    GameObject bulletA = Instantiate(playerBulletAPrefab);
                    GameObject bulletB = Instantiate(playerBulletBPrefab);
                    GameObject bulletC = Instantiate(playerBulletCPrefab);
                    bulletA.transform.position = transform.position + Vector3.right * 0.1f;
                    bulletB.transform.position = transform.position + Vector3.left * 0.1f;
                    bulletC.transform.position = transform.position;
                    bulletA.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5, ForceMode2D.Impulse);
                    bulletB.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5, ForceMode2D.Impulse);
                    bulletC.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5, ForceMode2D.Impulse);
                    break;
                }
            case 3:
                {
                    GameObject bulletA = Instantiate(playerBulletAPrefab);
                    GameObject bulletB = Instantiate(playerBulletBPrefab);
                    GameObject bulletC = Instantiate(playerBulletCPrefab);
                    bulletA.transform.position = transform.position + Vector3.right * 0.1f;
                    bulletB.transform.position = transform.position + Vector3.left * 0.1f;
                    bulletC.transform.position = transform.position;
                    bulletA.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5, ForceMode2D.Impulse);
                    bulletB.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5, ForceMode2D.Impulse);
                    bulletC.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5, ForceMode2D.Impulse);

                    GameObject guidedBulletA = Instantiate(guideBulletPrefab);
                    GameObject guidedBulletB = Instantiate(guideBulletPrefab);
                    guidedBulletA.transform.position = transform.position;
                    guidedBulletB.transform.position = transform.position;
                    guidedBulletA.transform.Rotate(Vector3.forward * -70);
                    guidedBulletB.transform.Rotate(Vector3.forward * 70);
                    break;
                }
        }
    }

    IEnumerator ShootDelay()//코루틴
    {
        yield return new WaitForSeconds(shootDelay); //new를 쓰면 옵션
        canShoot = true;
    }
}
