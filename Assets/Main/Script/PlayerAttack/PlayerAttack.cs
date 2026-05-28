using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage = 1;

    public int maxAmmo = 3;
    private int currentAmmo;

    public float reloadTime = 2f;
    private bool isReloading = false;

    void Start()
    {
        currentAmmo = maxAmmo;
        Debug.Log("初期弾数: " + currentAmmo);
    }

    void Update()
    {
        if (isReloading)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (currentAmmo <= 0)
        {
            Debug.Log("弾切れ → リロード開始");
            StartCoroutine(Reload());
            return;
        }

        Camera cam = Camera.main;
        if (cam == null) return;

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Enemy enemy = hit.collider.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }

        currentAmmo--;
        Debug.Log("発射！ 残弾: " + currentAmmo);

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
        }
    }

    System.Collections.IEnumerator Reload()
    {
        if (isReloading) yield break;

        isReloading = true;

        Debug.Log("リロード開始");

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;

        Debug.Log("リロード完了: " + currentAmmo);

        isReloading = false;
    }
}