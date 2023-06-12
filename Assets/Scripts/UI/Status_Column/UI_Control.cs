using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Control : MonoBehaviour
{
    public bool start_set = false;
    public Vector2 positon_offset;
    public GameObject Information_Show_Gameobject;
    public UI_Show_Text UI_information;
    public GameObject information_box;
    List<GameObject> information_box_array = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        if(start_set == true)
        {
        int index = 0;
            foreach (var information in UI_information.texts)
            {
                GameObject new_box = Instantiate(information_box);
                new_box.GetComponent<Information_Box>().box = information.box;
                new_box.GetComponent<Information_Box>().information.text = information.information;
                new_box.SetActive(false);
                new_box.GetComponent<Transform>().SetParent(Information_Show_Gameobject.transform);
                new_box.transform.position = new_box.transform.position + new Vector3(positon_offset.x,positon_offset.y-index*1.2f,0);
                information_box_array.Add(new_box);
                index++;

            }
        }
        
    }
    public void reset_pos(Transform t,Vector3 pos)
    {
        int index = 0;
        foreach (var information in UI_information.texts)
        {
            GameObject new_box = Instantiate(information_box);
            new_box.GetComponent<Information_Box>().box = information.box;
            new_box.GetComponent<Information_Box>().information.text = information.information;
            new_box.SetActive(false);
            new_box.GetComponent<Transform>().SetParent(t);
            new_box.transform.position = new_box.transform.position + pos + new Vector3(positon_offset.x,positon_offset.y-index*1.2f,0);
            information_box_array.Add(new_box);
            index++;

        }
        // int index = 0;
        // foreach (var information in information_box_array)
        // {
           
        //     information.GetComponent<Transform>().SetParent(t);
        //     index++;

        // }
    }
    public void reset_pos_old(Transform t,Vector3 pos)
    {
        foreach(var i in information_box_array)
        {
            Destroy(i);
        }
        information_box_array.Clear();
        int index = 0;
        foreach (var information in UI_information.texts)
        {
            GameObject new_box = Instantiate(information_box);
            new_box.GetComponent<Information_Box>().box = information.box;
            new_box.GetComponent<Information_Box>().information.text = information.information;
            new_box.SetActive(false);
            new_box.GetComponent<Transform>().SetParent(t);
            new_box.transform.position = new_box.transform.position + pos + new Vector3(positon_offset.x,positon_offset.y-index*1.2f,0);
            information_box_array.Add(new_box);
            index++;

        }
        // int index = 0;
        // foreach (var information in information_box_array)
        // {
           
        //     information.GetComponent<Transform>().SetParent(t);
        //     index++;

        // }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show_Text()
    {
        foreach (var box in information_box_array)
        {
            box.SetActive(true);

        }
    }
    public void Disable_Text()
    {
        foreach (var box in information_box_array)
        {
            box.SetActive(false);

        }
    }
}
