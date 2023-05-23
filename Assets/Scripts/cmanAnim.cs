using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class cmanAnim : MonoBehaviour
{
    int pcount;
    [SerializeField] Slider slider;

    private float sli_val;
    private float x_pos;
    SpriteRenderer spriteRenderer;
    [SerializeField] float speed = 1f;
    [SerializeField] float waveSpeed = 1f;
    [SerializeField] float bounds = 2f;
    bool direction = false;
    Vector3 init_pos;
    private BoxCollider2D bc1;
    private BoxCollider2D bc2;
    [SerializeField]
    GameObject gm2;

    Vector3 hash31(float p)
    {
        Vector3 pp = new Vector3(0.1031f, 0.1030f, 0.0973f);
        Vector3 p3 = new Vector3(p, p, p);
        p3 = Vector3.Scale(p3, pp);
        p3 = new Vector3(p3.x % 1f, p3.y % 1f, p3.z % 1f);
        Vector3 p3a = new Vector3(p3.y, p3.z, p3.x) + new Vector3(33.33f, 33.33f, 33.33f);
        float d = Vector3.Dot(p3, p3a);
        p3 = p3 + new Vector3(d, d, d);
        p3 = Vector3.Scale(new Vector3(p3.x, p3.x, p3.y) + new Vector3(p3.y, p3.z, p3.z), new Vector3(p3.z, p3.y, p3.x));
        p3 = new Vector3(p3.x % 1f, p3.y % 1f, 0);
        return p3;
    }
    void Start()
    {
        slider.onValueChanged.AddListener((v) =>
        {
            sli_val = v;
        });
        spriteRenderer = GetComponent<SpriteRenderer>();
        //anim = gameObject.GetComponent<Animator>();
        init_pos = transform.position;
        bc1 = GetComponent<BoxCollider2D>();
        bc2 = gm2.GetComponent<BoxCollider2D>();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }

    void Update()
    {
        Vector3 pos = transform.position;
        
        if (bc1.bounds.Intersects(bc2.bounds))
        {
            Vector3 offset = bc2.bounds.center + bc2.bounds.extents;
            init_pos = hash31(Time.time) + offset;
            //transform.position = new Vector3(init_pos.x,init_pos.y,0);
            Debug.Log(transform.position);

        }
        
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            bool is_clicked = Vector3.Distance(mousePos, pos) < 0.5f;
            if (is_clicked)
            {
                gameObject.SetActive(false);
                PlayerCount.Count -= 1;

            }
            if (PlayerCount.Count < 1)
            {
                Debug.Log("GAME OVER");
                Invoke("Restart", 2f);
                PlayerCount.Count = 3;
            }
        }
        float wave_motion = Mathf.Sin(Time.time * Mathf.PI * 2f * waveSpeed)*0.1f;// data_in.GetCCbyIndex(cc_index);

        if (Mathf.Abs(x_pos) > bounds)
            direction = !direction;
        if (direction)
        {
            x_pos += Time.deltaTime * speed * sli_val;
        }
        else
        {
            x_pos -= Time.deltaTime * speed * sli_val;
        }
        //x_pos = (x_pos -  * sli_val+ bounds) % bounds;
        spriteRenderer.flipX = direction;
        transform.position = init_pos + new Vector3(x_pos, wave_motion * 1f, 0);
    }
        
        

}
