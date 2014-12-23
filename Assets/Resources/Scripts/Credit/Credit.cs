using UnityEngine;
using System.Collections;

public class Credit : MonoBehaviour {

    public float MoveSpeed = 1.0f;
    public float FadeOutTime = 3.0f;

    private SpriteRenderer black;

    void Start()
    {
        black = GameObject.Find("Black").GetComponent<SpriteRenderer>();

        StartCoroutine("CreditMove");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            StartCoroutine("FadeOut");
    }

    IEnumerator CreditMove()
    {
        while (true)
        {
            transform.position += new Vector3(0.0f, MoveSpeed, 0.0f) * Time.deltaTime;

            if (transform.position.y >= 13.5f)
            {
                StartCoroutine("FadeOut");
                StopCoroutine("CreditMove");
            }

            yield return null ;
        }
    }

    IEnumerator FadeOut()
    {
        float fTime = 0.0f;

        while (true)
        {
            black.color = new Color(0.0f, 0.0f, 0.0f, (fTime / FadeOutTime));

            if (fTime >= FadeOutTime)
                Application.LoadLevel("Main");

            yield return null;

            fTime += Time.deltaTime;
        }
    }
}
