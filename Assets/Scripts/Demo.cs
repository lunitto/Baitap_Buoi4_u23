
using System.Diagnostics.Contracts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour
{
    public GameObject gameObject;
    public AnimationCurve curve;
    public Vector3 aPoint, bPoint, cPoint;
    Vector3 target;
    float time;
    float targetObjectHight;

    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        // gameObject.transform.position = aPoint;
        // target = bPoint;
        
        target = gameObject.transform.position;
        targetObjectHight = gameObject.GetComponent<MeshRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        //hien thi khi nhan phim
        // if (Input.GetKeyDown(KeyCode.A))
        // {
        //     Debug.Log("A");
        // }
        // if (Input.GetKeyDown(KeyCode.B))
        // {
        //     Debug.Log("B");
        // }
        // if (Input.GetKeyDown(KeyCode.C))
        // {
        //     Debug.Log("C");
        // }

        //di chuyen obj tu diem A den diem B roi sau do quay tro ve vi tri ban dau va tiep tuc di chuyen
        // gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target, 2f * Time.deltaTime);
        // if (Vector3.Distance(gameObject.transform.position, bPoint) < 0.1f)
        // {
        //     target = aPoint;       
        // }
        // else if (Vector3.Distance(gameObject.transform.position, aPoint) < 0.1f)
        // {        
        //     target = bPoint;
        // }
        
        //Di chuyển một object qua 3 diem bat ky sau do tro ve vi tri ban dau tiep tuc di chuyen
        // gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target, 2f * Time.deltaTime);
        // if (Vector3.Distance(gameObject.transform.position, bPoint) < 0.1f)
        // {
        //     target = cPoint;
        // } 
        // else if (Vector3.Distance(gameObject.transform.position, cPoint) < 0.1f)
        // {
        //     target = aPoint;
        // }
        // else if (Vector3.Distance(gameObject.transform.position, aPoint) < 0.1f)
        // {
        //     target = bPoint;
        // }

        // time += Time.deltaTime;
        // Vector3 pos = Vector3.Lerp(aPoint, target, time);
        // pos.y += curve.Evaluate(time);
        // gameObject.transform.position = pos;
        
        //bam vao man hinh bat ky obj se tien toi do
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100f));
            Vector3 direction = mousePosition - Camera.main.transform.position;
            if (Physics.Raycast(Camera.main.transform.position, direction, out hit, 100f))
            {
                target = hit.point + new Vector3(0f, targetObjectHight/2f, 0f);
            }
            
        }
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target, 5f * Time.deltaTime);

    }
}
