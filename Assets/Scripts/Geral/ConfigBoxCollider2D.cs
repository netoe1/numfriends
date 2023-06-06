using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ConfigBoxCollider2D : MonoBehaviour
{
    [SerializeField] BoxCollider2D collider_2d;
    [SerializeField] bool get_enable_collider;
    bool enable_collider = false;

    private void Start()
    {
        if (get_enable_collider){
            enable_collider = true;
        }
        collider_2d.enabled = enable_collider;
        collider_2d.size = this.gameObject.GetComponent<RectTransform>().sizeDelta;
    }


}
