using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//重置网格中心点
public class ResetModelPivot : MonoBehaviour
{
    #region 字段
    public GameObject Model;

    Button m_resetBtn;

    #endregion

    void Start()
    {
        m_resetBtn = transform.Find("ResetBtn").GetComponent<Button>();
        m_resetBtn.onClick.AddListener(() => { MyResetModelPivot(); });
    }

    //模型pivot与center在一个位置
    void MyResetModelPivot()
    {
        //获得模型的中心
        Vector3 center = Model.GetComponent<MeshCollider>().sharedMesh.bounds.center;

        Mesh mesh = Model.GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;

        //网格顶点是本地坐标
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] -= center;
        }
        
        mesh.vertices = vertices;

        mesh.RecalculateBounds();
        mesh.RecalculateTangents();

        Model.GetComponent<MeshFilter>().mesh = mesh;

        Destroy(Model.GetComponent<MeshCollider>());
        Model.AddComponent<MeshCollider>();
    }
}
