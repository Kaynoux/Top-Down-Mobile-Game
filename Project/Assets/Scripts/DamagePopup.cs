using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
    private TextMeshPro textMeshPro;
    private float disappearTimer = .5f;
    private static int sortingOrder = 3;
    public static DamagePopup Create(Vector3 _pos, float _damage, bool _isCritical, bool _isPlayerDamage)
    {
        Transform damagePopupTransform = Instantiate(GameAssets.i.pfDamagePopup, _pos + new Vector3(0, 0.7f) + new Vector3(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f)), Quaternion.identity);
        DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
        damagePopup.Setup(Mathf.Floor(_damage), _isCritical, _isPlayerDamage);
        return damagePopup;
    }
    private void Awake()
    {
        textMeshPro = GetComponent<TextMeshPro>();
        transform.localScale = new Vector3(.5f, .5f);
    }

    public void Setup(float _damage, bool _isCritical, bool _isPlayerDamage)
    {
        if (_isPlayerDamage)
        {
            textMeshPro.text = (-_damage).ToString();
            textMeshPro.fontSize *= 1.3f;
            textMeshPro.color = new Color32(231, 76, 60, 255);
        }
        else
        {
            textMeshPro.text = _damage.ToString();
        }
       
        if (_isCritical)
        {
            textMeshPro.fontSize *= 1.3f;
            textMeshPro.color = new Color32(230, 126, 34, 255);
        }
        sortingOrder++;
        textMeshPro.sortingOrder = sortingOrder;
        if (sortingOrder > 30000)
        {
            sortingOrder = 3;
        }
    }

    private void Update()
    {
        if (disappearTimer > 0.3)
        {
            transform.localScale += Vector3.one* 2 * Time.deltaTime;
        }
        
        if (disappearTimer < 0)
        {
            textMeshPro.alpha -= 3 * Time.deltaTime;
            if (textMeshPro.alpha < 0)
            {
                Destroy(gameObject);
            }
        }
        
        else
        {
            disappearTimer -= Time.deltaTime;
        }
        transform.position += new Vector3(0, .2f) * Time.deltaTime;
    }

}
