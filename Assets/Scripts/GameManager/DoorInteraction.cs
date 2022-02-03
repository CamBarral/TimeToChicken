using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorInteraction : MonoBehaviour
{
    public GameObject redButton;
    public GameObject heavyDoor;

    public Animator redButton_Animator;
    public Animator heavyDoor_Animator;

    private GameObject _buttonText;
    private Text _text;
    private bool pushIsAble;
    private bool openIsAble;
    private float _count;
    private float _maxCount = 0.8f;


    void Start()
    {
        _buttonText = GameObject.FindWithTag("buttonText");
        _text = _buttonText.GetComponent<Text>();
        _text.enabled = false;

        pushIsAble = true;
        openIsAble = true;
        _count = 0;
    }

    void Update()
    {
        if (pushIsAble == false)
        {
            OpenDoor();
        }
    }

    private void OnTriggerStay(Collider col)
    {
        _text.enabled = true;

        if ((col.tag == "buttonZone") && (Input.GetKey(KeyCode.E)) && pushIsAble == true)
        {
            //Launch Button anim.
            redButton_Animator.SetTrigger("Pushed");
            pushIsAble = false;
            _text.enabled = false;
            _buttonText.SetActive(false);
        }

    }

    private void OnTriggerExit(Collider col)
    {
        if ((col.tag == "buttonZone"))
        {
            _text.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if ((col.tag == "eventBox") && openIsAble == false)
        {
            //Launch Button anim.
            heavyDoor_Animator.SetTrigger("Close");
            //Launch "HeavyDoorClosed" sound.
            FindObjectOfType<AudioManager>().Play("HeavyDoorClosed");
        }

    }

    private void OpenDoor()
    {
        _count += Time.deltaTime;

        if ((_count >= _maxCount) && openIsAble == true)
        {
            //Launch DoorAnim.
            heavyDoor_Animator.SetTrigger("Open");
            openIsAble = false;
        }
    }
}
