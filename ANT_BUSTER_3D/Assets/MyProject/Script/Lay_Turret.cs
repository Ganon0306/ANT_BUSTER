using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Lay_Turret : MonoBehaviour
{
    public GameObject prefabToInstantiate; // ���콺�� ����ٴ� ������ ������Ʈ
    public float moveSpeedMultiplier = 10f; // ���콺 �����ӿ� ���� ��

    private GameObject instantiatedObject; // ������ ������Ʈ�� ���� ����

    public void OnButtonPressed()
    {
        // ��ư�� ���� �� �������� ���콺 ��ġ�� ����
        if (prefabToInstantiate != null)
        {
            Vector3 screenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f); // ������ z�� ����
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(screenPoint);
            worldPoint.y = 1f;
            worldPoint.x *= 2.3f;
            worldPoint.z *= 2.3f;
            instantiatedObject = Instantiate(prefabToInstantiate, worldPoint, Quaternion.identity);
        }
    }

    private void Update()
    {
        // ������ ������Ʈ�� ���콺 ��ġ�� ����ٴϰ� ��
        if (instantiatedObject != null)
        {
            Vector3 screenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f); // ������ z�� ����
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(screenPoint);
            worldPoint.y = 1f; 
            worldPoint.x *= 2.3f;
            worldPoint.z *= 2.3f;

            Vector3 moveDirection = (worldPoint - instantiatedObject.transform.position).normalized;
            float distance = Vector3.Distance(worldPoint, instantiatedObject.transform.position);
            float step = moveSpeedMultiplier * Time.deltaTime;

            if (distance > step)
            {
                instantiatedObject.transform.position += moveDirection * step;
            }
            else
            {
                instantiatedObject.transform.position = worldPoint;
            }
        }
    }
}

//////////////////////////////////////111111111111111111111111111111