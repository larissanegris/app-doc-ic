using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public static class SaveLoad
{

    [System.Serializable]
    public class TransformInfo
    {
        public Form form;
        public GameObject gm;
        public Vector3 pos;
        public Quaternion rot;
        public Vector3 scale;
        

        public TransformInfo(Form f)
        {
            form = f;
            gm = form.gameObject;
            pos = gm.transform.position;
            rot = gm.transform.rotation;
            scale = gm.transform.lossyScale;
            form = gm.GetComponent<Form>();
        }
    }

    public static void SaveTransform(Form[] FormsToSave)
    {
        TransformInfo[] trnfrm = new TransformInfo[FormsToSave.Length];
        for (int i = 0; i < trnfrm.Length; i++)
        {
            trnfrm[i] = new TransformInfo(FormsToSave[i]);
        }

        string jsonTransform = JsonHelper.ToJson(trnfrm, true);
        PlayerPrefs.SetString("transform", jsonTransform);
        Debug.Log("Salvo JSON");
        Debug.Log(jsonTransform);
    }

    public static Form[] LoadTransform()
    {
        string jsonTransform = PlayerPrefs.GetString("transform");
        if (jsonTransform == null)
        {
            return null;
        }
        //Debug.Log("Loaded: " + jsonTransform);

        TransformInfo[] savedTransforms = JsonHelper.FromJson<TransformInfo>(jsonTransform);
        GameObject[] gameObjects = new GameObject[savedTransforms.Length];
        Form[] loadedForms = new Form[savedTransforms.Length];

        for (int i = 0; i < gameObjects.Length; i++)
        {
            gameObjects[i] = new GameObject("_");
            gameObjects[i].hideFlags = HideFlags.HideAndDontSave;
            loadedForms[i] = gameObjects[i].GetComponent<Form>();

        }
        return loadedForms;
    }

    public static void CopyTransform(this Transform trans, Transform source, Transform target, bool createNewInstance = false)
    {
        if (source == null)
        {
            return;
        }

        if (target == null || createNewInstance)
        {
            GameObject obj = new GameObject("_");
            obj.hideFlags = HideFlags.HideAndDontSave;
            target = obj.transform;
        }

        target.position = source.position;
        target.rotation = source.rotation;
        target.localScale = source.localScale;
    }

    public static void CopyTransform(this Transform trans, Transform[] source, Transform[] target, bool createNewInstance = false)
    {
        if (source == null || source.Length <= 0)
        {
            return;
        }

        for (int i = 0; i < target.Length; i++)
        {
            CopyTransform(null, source[i], target[i], createNewInstance);
            if (i >= target.Length - 1)
            {
                break;
            }
        }
    }

    public static void SaveData(int num)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = "C:,Users,Lucca,Documents,Unity,app-doc-ic,Ic,Builds".Replace(",", "/");
        path += "/Game.weeklyhow";

        FileStream stream = new FileStream(path, FileMode.Create);

        Data data = new Data(num);

        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log("Save");
    }

    public static Data LoadData()
    {
        string path = Application.persistentDataPath + "/Game.weeklyhow";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Data data = formatter.Deserialize(stream) as Data;

            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Error: Save file not found in " + path);
            return null;
        }
    }
}
