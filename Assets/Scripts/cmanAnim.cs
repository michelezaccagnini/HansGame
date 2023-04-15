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

    void Start()
    {
        slider.onValueChanged.AddListener((v) =>
        {
            sli_val = v;
        });
        spriteRenderer = GetComponent<SpriteRenderer>();
        //anim = gameObject.GetComponent<Animator>();
        init_pos = transform.position;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }

    void Update()
    {
        Vector3 pos =  transform.position;
        
        
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
            if(PlayerCount.Count < 1)
            {
                Debug.Log("GAME OVER"); 
                Invoke("Restart", 2f);
                PlayerCount.Count = 3;
            }
        }
        float wave_motion = Mathf.Sin(Time.time * Mathf.PI * 2f * waveSpeed);// data_in.GetCCbyIndex(cc_index);

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
