
using UnityEngine;

public class BackGroundScroller: MonoBehaviour
{
    [Range(-1f, 1f)]
    public float scrollspeed = 0.5f;
    public float offset;
    public Material mat;
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        offset += (Time.deltaTime * scrollspeed) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
