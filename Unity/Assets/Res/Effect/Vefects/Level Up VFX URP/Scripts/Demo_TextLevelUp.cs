using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo_TextLevelUp : MonoBehaviour
{
    Transform cam;
    TextMesh textMesh;
    bool start;

    float speed = 2.5f;
    public Color textColor = Color.white;

    float curentTime = 1f;
    void Awake()
    {
        cam = Camera.main.transform;
        textMesh = this.transform.GetChild(0).transform.GetComponent<TextMesh>();

        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        textMesh.color = new Color(0, 0, 0, 0);
        yield return new WaitForSeconds(0.35f);

        start = true;
    }

    void Update()
    {
        transform.forward = cam.forward;

        if(start)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 165f, 0f), speed * Time.deltaTime);
            //textMesh.color.a

            curentTime -= Time.deltaTime;
            textMesh.color = new Color(textColor.r, textColor.g, textColor.b, curentTime);

            if (curentTime <= 0)
            {
                Destroy(gameObject);
            }
        }

    }


}
