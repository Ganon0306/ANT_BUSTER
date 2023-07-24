using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Lay_Turret : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public GameObject prefabToInstantiate; // 드래그 중에 생성할 프리팹

    public Transform followObject;

    private RectTransform rectTransform;
    private Vector2 initialPosition;
    private bool isDragging = false;
    private GameObject instantiatedPrefab; // 생성된 프리팹을 담을 변수

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
            DropLogic(); // 드롭 로직 실행
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            Vector3 screenPoint = new Vector3(eventData.position.x, eventData.position.y, Camera.main.nearClipPlane);
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(screenPoint);
            instantiatedPrefab.transform.position = worldPoint;
            // 드래그 중에는 마우스의 움직임에 따라 UI 오브젝트를 이동시킵니다.
            //Vector3 screenPoint = new Vector3(eventData.position.x, eventData.position.y, Camera.main.nearClipPlane);
            //Vector3 worldPoint = Camera.main.ScreenToWorldPoint(screenPoint);

            //worldPoint.y = 4;

            //followObject.position = worldPoint;
        }
    }
    private void CreatePrefab()
    {
        // 프리팹을 버튼 위치에 생성
        if (prefabToInstantiate != null)
        {
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(rectTransform.position);
            instantiatedPrefab = Instantiate(prefabToInstantiate, worldPoint, Quaternion.identity);
        }
    }
    private void DropLogic()
    {
        // 드롭 로직을 여기에 구현합니다.
        // 마우스를 떼는 순간 드랍 로직이 실행됩니다.
        // 드랍 로직에서 원하는 동작을 수행합니다.
        // 예를 들어, 드롭한 위치를 검사하고, 해당 위치에 맞는 처리를 수행할 수 있습니다.
    }
}
