using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [Range(-1f,1f)]
    public float scrollSpeed = 0.5f;
    private float _offset;
    private Material _mat;
    
    // Start is called before the first frame update
    void Start()
    {
        _mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        _offset += (Time.deltaTime * scrollSpeed) / 10f;
        _mat.SetTextureOffset("_MainTex", new Vector2(_offset, 0));
    }
}
