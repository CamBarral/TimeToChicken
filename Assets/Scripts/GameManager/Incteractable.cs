using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Incteractable : MonoBehaviour
{
    public float radius;

    public int add = 1;

    private GameObject _scriptLootUI;
    private LootUI _lootUI;
    private GameObject _pickableText;
    private Text _text;

    private Transform _playerTransform;

    void Start()
    {
        _scriptLootUI = GameObject.FindWithTag("UI");
        _lootUI = _scriptLootUI.GetComponent<LootUI>();

        _pickableText = GameObject.FindWithTag("pickableText");
        _text = _pickableText.GetComponent<Text>();

        _playerTransform = PlayerManager.instance.player.GetComponent<Transform>();
    }

    void Update()
    {
        float distance = Vector3.Distance(_playerTransform.position, transform.position);

        if (distance <= radius)
        {
            //Display can pick with E.
            _text.enabled = true;

            //PickME
            if (Input.GetKeyDown(KeyCode.E))
            {
                //+1 Loot in LootUI._lootCount;
                _lootUI.UpdateLoot(add);

                //Hide pick me
                _text.enabled = false;

                //Destroy chickenLoot.
                Destroy(gameObject);
            }
        }
        else
        {
            _text.enabled = false;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
