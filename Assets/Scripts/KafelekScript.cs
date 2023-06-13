using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KafelekScript : MonoBehaviour {

    public Punkt PozycjaSiatka { get; set; }
    public int Type { get; set; }
    public Vector3 Srodek
    {
        get
        {
            return this.GetComponent<SpriteRenderer>().bounds.center;
        }
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void OnMouseOver()
    {
        Debug.Log("(" + PozycjaSiatka.X + "," + PozycjaSiatka.Y + ")");
        this.GetComponent<SpriteRenderer>().color = Color.cyan;
    }

    void OnMouseExit()
    {
        this.GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void Setup(Punkt pozycja, int type)
    {
        transform.SetParent(GameObject.FindGameObjectWithTag("Map").transform);
        this.PozycjaSiatka = pozycja;
        this.Type = type;
    }


}
