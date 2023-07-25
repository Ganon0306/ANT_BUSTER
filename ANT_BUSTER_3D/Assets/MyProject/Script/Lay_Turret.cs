using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Lay_Turret : MonoBehaviour
{
    public GameObject prefabToInstantiate; // ���콺�� ����ٴ� ������ ������Ʈ
    public GameObject addTurretPrefab;
    public List<Transform> targetObjects;
    public float moveSpeedMultiplier = 10f; // ���콺 �����ӿ� ���� ��

    private GameObject instantiatedObject; // ������ ������Ʈ�� ���� ����
    private List<Vector3> turretPositions = new List<Vector3>(); // ��ġ�� �ͷ����� ��ġ�� ������ ����Ʈ


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

            // ���� ��ġ�� �ͷ��� ��ġ�� �̹� ��ġ�� �ͷ����� ��ġ�� ���Ͽ� ��ġ���� Ȯ��
            if (canInstall && !IsOverlappingTurret(clickWorldPoint))
            {
                turretPositions.Add(clickWorldPoint); // ��ġ�� �ͷ� ��ġ�� ����Ʈ�� �߰�
                Instantiate(addTurretPrefab, clickWorldPoint, Quaternion.identity);
                Destroy(instantiatedObject);
            }
            else
            {
                // ��ġ�� �� ���� ��� ������ ������Ʈ�� ����
                Destroy(instantiatedObject);
            }
        }
    }

    // ���� ��ġ�� �ͷ��� ���� �ͷ��� ��ġ���� Ȯ���ϴ� �Լ�
    private bool IsOverlappingTurret(Vector3 newPosition)
    {
        foreach (Vector3 turretPosition in turretPositions)
        {
            if (Vector3.Distance(newPosition, turretPosition) < 0.8f) 
            {
                return true; // ��ġ�� ��� true ��ȯ
            }
        }
        return false; // ��ġ�� �ʴ� ��� false ��ȯ
    }
}

//////////////////////////////////////111111111111111111111111111111

//////////////////////////2222222222222222222222222