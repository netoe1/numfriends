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

        update_collider(this.gameObject,true);
    }

    public static void update_collider(GameObject gameObject_with_collider2D, bool active)
    {
        gameObject_with_collider2D.GetComponent<BoxCollider2D>().enabled = active;
        gameObject_with_collider2D.GetComponent<BoxCollider2D>().size = gameObject_with_collider2D.GetComponent<RectTransform>().sizeDelta;
    }


}
