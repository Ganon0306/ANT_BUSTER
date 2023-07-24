using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Lay_Turret : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public GameObject prefabToInstantiate; // �巡�� �߿� ������ ������

    public Transform followObject;

    private RectTransform rectTransform;
    private Vector2 initialPosition;
    private bool isDragging = false;
    private GameObject instantiatedPrefab; // ������ �������� ���� ����

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        initialPosition = rectTransform.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
        Debug.LogFormat("{0}", isDragging);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isDragging)
        {
            isDragging = false;
            Debug.LogFormat("{0}", isDragging);
            DropLogic(); // ��� ���� ����
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            Vector3 screenPoint = new Vector3(eventData.position.x, eventData.position.y, Camera.main.nearClipPlane);
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(screenPoint);
            instantiatedPrefab.transform.position = worldPoint;
            // �巡�� �߿��� ���콺�� �����ӿ� ���� UI ������Ʈ�� �̵���ŵ�ϴ�.
            //Vector3 screenPoint = new Vector3(eventData.position.x, eventData.position.y, Camera.main.nearClipPlane);
            //Vector3 worldPoint = Camera.main.ScreenToWorldPoint(screenPoint);

            //worldPoint.y = 4;

            //followObject.position = worldPoint;
        }
    }
    private void CreatePrefab()
    {
        // �������� ��ư ��ġ�� ����
        if (prefabToInstantiate != null)
        {
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(rectTransform.position);
            instantiatedPrefab = Instantiate(prefabToInstantiate, worldPoint, Quaternion.identity);
        }
    }
    private void DropLogic()
    {
        // ��� ������ ���⿡ �����մϴ�.
        // ���콺�� ���� ���� ��� ������ ����˴ϴ�.
        // ��� �������� ���ϴ� ������ �����մϴ�.
        // ���� ���, ����� ��ġ�� �˻��ϰ�, �ش� ��ġ�� �´� ó���� ������ �� �ֽ��ϴ�.
    }
}
