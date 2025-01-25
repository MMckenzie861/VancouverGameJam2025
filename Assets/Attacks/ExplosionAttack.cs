using System.Collections;
using UnityEngine;

public class ExplosionAttack : MonoBehaviour
{
    public GameObject warningCircle;
    public float warningDuration = 2f;
    public float aoeSize = 5f;
    public float explosionDuration = 0.2f;

    private Vector3 originalSize;
    private Vector3 warningSize;

    void Start()
    {
        originalSize = transform.localScale;

        warningSize = new Vector3(aoeSize, aoeSize, aoeSize);

        StartCoroutine(WarningPhase());
    }

    private IEnumerator WarningPhase()
    {
        if (warningCircle != null)
        {
            warningCircle.SetActive(true);
            warningCircle.transform.localScale = originalSize;

            float elapsedTime = 0f;
            while (elapsedTime < warningDuration)
            {
                warningCircle.transform.localScale = Vector3.Lerp(originalSize, warningSize, elapsedTime / warningDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            warningCircle.transform.localScale = warningSize;
        }

        StartCoroutine(ExplosionPhase());
    }

    private IEnumerator ExplosionPhase()
    {
        if (warningCircle != null)
            warningCircle.SetActive(false);

        float elapsedTime = 0f;
        while (elapsedTime < explosionDuration)
        {
            transform.localScale = Vector3.Lerp(originalSize, warningSize, elapsedTime / explosionDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.localScale = warningSize;
        Destroy(gameObject);
    }
}
