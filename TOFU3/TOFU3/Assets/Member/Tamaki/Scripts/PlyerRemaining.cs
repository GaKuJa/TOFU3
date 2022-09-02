using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlyerRemaining : Remaining
{
    [SerializeField]
    private Text CountRemaining;
    [SerializeField]
    private int remaining; // 残機
    [SerializeField]
    private float HP = 100; // HP

    [SerializeField] GameObject Player100;
    [SerializeField] GameObject Player80;
    [SerializeField] GameObject Player50;
    [SerializeField] GameObject Player20;
    [SerializeField] GameObject Player0;
    private float TimeLeft = 0.05f;

    public static PlyerRemaining Instance { get => instance; }
    static PlyerRemaining instance;


    private void Awake()
    {
        instance = this;

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 5; i > 0; --i) // 残機が0より上なら
        {
            if (Input.GetMouseButton(1) && remaining > 0) // 残機が残っていたら左クリックでHP減らす
            {
                TimeLeft -= Time.deltaTime;
                if (TimeLeft <= 0.0)
                {
                    TimeLeft = 0.1f; // 徐々にHP減らす
                    HP--;
                    if (HP > 80)
                    {
                        Player0.SetActive(false);
                        Player100.SetActive(true);
                    }
                    else if (HP > 50)
                    {
                        Player100.SetActive(false);
                        Player80.SetActive(true);
                    }
                    else if (HP > 20)
                    {
                        Player80.SetActive(false);
                        Player50.SetActive(true);
                    }
                    else if (HP > 0)
                    {
                        Player50.SetActive(false);
                        Player20.SetActive(true);
                    }
                    else if (HP <= 0)
                    {
                        Player20.SetActive(false);
                        Player0.SetActive(true);
                    }
                    if (HP <= 0)
                    {
                        remaining--;
                        CountRemaining.text = remaining.ToString("×" + remaining);
                        HP = 100;
                    }
                }
            }
        }
    }



    public void Remaining()
    {
        if (remaining == 0)
        {
            PeopleRmaining -= 1;
        }
    }
    public int RemainingPeople()
    {
        return PeopleRmaining;
    }
}
