using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractingWithFriends : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    [SerializeField] private Transform player;
    [SerializeField] private Transform Parent;
    Transform temPtransForm;
    private bool interactedWithPlayer;

    [SerializeField] private GameObject freindPrefab;
   [SerializeField] private float freindX=-1;
   [SerializeField] private float freindZ=-3.5f;
   

    public static InteractingWithFriends Instance;
    private void Awake()
    {
        Instance=this;
    }
    private void Update()
    {
        if (interactedWithPlayer)
        {
            
           //transform.Translate(Vector3.forward * speed * Time.deltaTime);
            //Vector3 playerPosition=player.position;
            //playerPosition.y = 0;
            //transform.localPosition= player.position;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Friend") && !interactedWithPlayer)
        {
            interactedWithPlayer = true;
           
         
           

            GameObject newFriend= Instantiate(freindPrefab,new Vector3(transform.position.x,-0.10f,transform.position.z),transform.rotation) as GameObject;
           
           newFriend.SetActive(true);
            gameObject.SetActive(false);
            newFriend.gameObject.transform.SetParent(other.transform);
            GameManager.Instance.freinds.Push(freindPrefab.transform);

            newFriend.gameObject.tag = "Friend";

            //// transform.localPosition = player.position;
            //print("collied");
            //freinds.Push(this.transform);
            //if (Parent.childCount == 0)
            //{


            //    transform.position = Parent.position+new Vector3(0,0,-1f);
            //    transform.SetParent(Parent);

            //   // temPtransForm = Parent;
            //}
            //else
            //{


            //    Transform prevFreind = freinds.Pop();
            //    if (prevFreind != null)
            //    {
            //        transform.localPosition = prevFreind.localPosition+new Vector3(freindX,0,freindZ);
            //        transform.SetParent(Parent);
            //    }

            //}
            // transform.position+= other.transform.position+new Vector3(1,0,0);

        }
    }
}
