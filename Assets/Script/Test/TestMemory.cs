using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMemory : MonoBehaviour
{

    void Start()
    {
        List<JobEntity> lst = JobDBModel.Instance.GetList();

        for (int i = 0; i < lst.Count; i++)
        {
            Debug.Log("Desc=" + lst[i].Desc);
        }

        //ProductEntity entity = ProductDBModel.Instance.Get(5);
        //if (entity != null)
        //{
        //    Debug.Log("name=" + entity.Name);
        //}

        #region 数据读取 用法
        /*
        Item item = new Item() { ID = 1, Name = "aa" };

        byte[] arr = null;
        using(MMO_MemoryStream ms = new MMO_MemoryStream())
        {
            ms.WriteInt(item.ID);
            ms.WriteUTF8String(item.Name);

            arr = ms.ToArray();
        }

        //if (arr != null)
        //{
        //    for (int i = 0; i < arr.Length; i++)
        //    {
        //        Debug.Log(string.Format("{0}={1}", i, arr[i]));
        //    }
        //}
        Item item2 = new Item();

        using (MMO_MemoryStream ms = new MMO_MemoryStream(arr))
        {
            item2.ID = ms.ReadInt();
            item2.Name = ms.ReadUTF8String();
        }
        Debug.Log(item2.ID+"+"+item2.Name);
        */
        #endregion
    }

    void Update ()
    {
		
	}
}


//public class Item
//{
//    public int ID;
//    public string Name;
//}