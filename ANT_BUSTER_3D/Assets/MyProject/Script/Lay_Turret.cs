using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Lay_Turret : MonoBehaviour
{
    public GameObject prefabToInstantiate; // 마우스를 따라다닐 프리팹 오브젝트
    public GameObject addTurretPrefab;
    public List<Transform> targetObjects;
    public float moveSpeedMultiplier = 10f; // 마우스 움직임에 곱할 값

    private GameObject instantiatedObject; // 생성된 오브젝트를 담을 변수
    private List<Vector3> turretPositions = new List<Vector3>(); // 설치된 터렛들의 위치를 저장할 리스트


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
        if (instantiatedObject != null && Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 clickWorldPoint = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10f));
            clickWorldPoint.y = 1f;
            clickWorldPoint.x *= 2.3f;
            clickWorldPoint.z *= 2.3f;

            bool canInstall = false;
            foreach (Transform targetObject in targetObjects)
            {
                if (Vector3.Distance(clickWorldPoint, targetObject.position) < 0.8f)///////
                {
                    canInstall = true;
                    break;
                }
            }

            // 새로 설치할 터렛의 위치와 이미 설치된 터렛들의 위치를 비교하여 겹치는지 확인
            if (canInstall && !IsOverlappingTurret(clickWorldPoint))
            {
                turretPositions.Add(clickWorldPoint); // 설치된 터렛 위치를 리스트에 추가
                Instantiate(addTurretPrefab, clickWorldPoint, Quaternion.identity);
                Destroy(instantiatedObject);
            }
            else
            {
                // 설치할 수 없을 경우 생성된 오브젝트를 제거
                Destroy(instantiatedObject);
            }
        }
    }

    // 새로 설치할 터렛이 기존 터렛과 겹치는지 확인하는 함수
    private bool IsOverlappingTurret(Vector3 newPosition)
    {
        foreach (Vector3 turretPosition in turretPositions)
        {
            if (Vector3.Distance(newPosition, turretPosition) < 0.8f) 
            {
                return true; // 겹치는 경우 true 반환
            }
        }
        return false; // 겹치지 않는 경우 false 반환
    }
}

//////////////////////////////////////111111111111111111111111111111

//////////////////////////2222222222222222222222222