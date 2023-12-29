using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveColorChange : MonoBehaviour
{
    private Renderer renderer;
    private Color originalColor;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        originalColor = renderer.material.color;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            renderer.material.color = Color.red;
            Destroy(other.gameObject);
            StartCoroutine(BackOriginColor());
        }
    }
    IEnumerator BackOriginColor()
    {
        yield return new WaitForSeconds(2f);
        renderer.material.color = originalColor;
    }
}
