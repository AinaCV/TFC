//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System.IO;


//public class PlayerSavePosicion : MonoBehaviour
//{
//    void Start()
//    {
//        StreamReader sr = new StreamReader(Application.persistentDataPath + "/PlayerPosition.txt");
//        float x = float.Parse(sr.ReadLine());
//        float y = float.Parse(sr.ReadLine());
//        float z = float.Parse(sr.ReadLine());
//        transform.position = new Vector3(x, y, z);
//    }


//    void OnDisable()
//    {
//        FileStream fs = File.Create(Application.persistentDataPath + "/PlayerPosition.txt");

//        StreamWriter sw = new StreamWriter(fs);

//        sw.WriteLine(transform.position.x);
//        sw.WriteLine(transform.position.y);
//        sw.WriteLine(transform.position.z);

//        sw.Close();
//        fs.Close();
//    }


   
//}
