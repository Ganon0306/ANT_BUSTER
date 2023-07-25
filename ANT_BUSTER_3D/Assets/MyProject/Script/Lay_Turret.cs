using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Lay_Turret : MonoBehaviour
{
    public GameObject prefabToInstantiate; // 마우스를 따라다닐 프리팹 오브젝트
    public float moveSpeedMultiplier = 10f; // 마우스 움직임에 곱할 값

    private GameObject instantiatedObject; // 생성된 오브젝트를 담을 변수

    public void OnButtonPressed()
    {
        // 버튼을 누를 때 프리팹을 마우스 위치에 생성
        if (prefabToInstantiate != null)
        {
            Vector3 screenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f); // 적절한 z값 설정
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(screenPoint);
            worldPoint.y = 1f;
            worldPoint.x *= 2.3f;
            worldPoint.z *= 2.3f;
            instantiatedObject = Instantiate(prefabToInstantiate, worldPoint, Quaternion.identity);
        }
    }

    private void Update()
    {
        // 생성된 오브젝트를 마우스 위치로 따라다니게 함
        if (instantiatedObject != null)
        {
            Vector3 screenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f); // 적절한 z값 설정
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