using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float scrollSpeed;
    private float offset;
    private Material mat;
   
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }


    void Update()
    {
        scrollSpeed = GameObject.FindWithTag("grandma").GetComponent<grandma>().XSpeed;
        offset += (Time.deltaTime * scrollSpeed) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
