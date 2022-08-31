using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Remaining : MonoBehaviour
{
    [SerializeField]
    private Text remainingPeople;
    public int PeopleRmaining = 4;
    // Start is called before the first frame update
    void Start()
    {
        PlyerRemaining.Instance.Remaining();
    }

    // Update is called once per frame
    void Update()
    {
        People();
    }

    private void People()
    {
        remainingPeople.text = PlyerRemaining.Instance.RemainingPeople().ToString();
    }
}
