using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InGameUI : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] private TextMeshProUGUI dimmondCounter;
    private int dimondCount=0;
    Animator animator;
    public int DimondCount { get { return dimondCount; } }
    public static event System.Action IncreaseScore;
    private void Awake()
    {
       
    }
    void Start()
    {
      // dimmondCounter.text=dimondCount.ToString();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //dimmondCounter.text = dimondCount.ToString();
        //print(dimondCount);
    }
    private void OnTriggerEnter(Collider target)
    {
       
        if (target.CompareTag("Player"))
        {
           
            animator.SetTrigger("DimondUp");
            IncreaseScore?.Invoke();
            Destroy(gameObject, 2);
        }
    }
    
}
