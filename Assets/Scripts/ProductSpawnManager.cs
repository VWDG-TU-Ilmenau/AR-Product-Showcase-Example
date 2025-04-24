using UnityEngine;

public class ProductSpawnManager : MonoBehaviour
{
    public static ProductSpawnManager Instance;
    public GameObject Product;
    public GameObject CurrentProduct;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void SpawnProduct(Pose hitPose)
    {
        if (CurrentProduct == null)
        {
            CurrentProduct = Instantiate(Product, hitPose.position, hitPose.rotation);
        }
        else
        {
            // Move existing object
            CurrentProduct.transform.SetPositionAndRotation(hitPose.position, hitPose.rotation);
        }
    }
}
