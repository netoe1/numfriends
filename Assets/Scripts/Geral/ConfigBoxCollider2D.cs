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

        update_collider(this.gameObject,1f,true);
    }

    public static void update_collider(GameObject gameObject_with_collider2D,float scaleFactor, bool active)
    {
        gameObject_with_collider2D.GetComponent<BoxCollider2D>().enabled = active;
        gameObject_with_collider2D.GetComponent<BoxCollider2D>().size = new Vector2 (gameObject_with_collider2D.GetComponent<RectTransform>().sizeDelta.x * scaleFactor, gameObject_with_collider2D.GetComponent<RectTransform>().sizeDelta.y * scaleFactor);
    }

    public static void reset_size(GameObject gameObject_with_collider2D)
    {
        gameObject_with_collider2D.GetComponent<BoxCollider2D>().size = gameObject_with_collider2D.GetComponent<RectTransform>().rect.size;
    }

}
