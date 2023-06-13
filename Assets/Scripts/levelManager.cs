using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class levelManager : MonoBehaviour
{
	[SerializeField] GameObject[] kafelek;
	public Dictionary<Punkt, KafelekScript> Kafelki { get; set; }

	public float RozmiarKafelka;
	public int mapX;
	public int mapY;

	private void StworzPoziom()
	{
		Kafelki = new Dictionary<Punkt, KafelekScript>();

		string[] daneMapy = WczytajPoziom();

		mapX = daneMapy[0].ToCharArray().Length;
		mapY = daneMapy.Length;

		print(mapX + " : " + mapY);

		for (int y = 0; y < mapY; y++)
		{
			char[] noweKafelki = daneMapy[y].ToCharArray();
			for (int x = 0; x < mapX; x++)
			{
				UmiescKafelek(noweKafelki[x],x, y);

			}
		}


	}
	private void UmiescKafelek( char rodzajKafelka, int x, int y)
	{
		int numerKafelka = (int)System.Char.GetNumericValue(rodzajKafelka);
		RozmiarKafelka = kafelek[0].GetComponent<SpriteRenderer>().sprite.bounds.size.y; 
		// Start is called before the first frame update
		Vector2 poczatekSwiata = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
		GameObject nowyKafelek = Instantiate(kafelek[numerKafelka], new Vector2(poczatekSwiata.x + RozmiarKafelka * x, poczatekSwiata.y + RozmiarKafelka * y), Quaternion.identity);
		nowyKafelek.GetComponent<KafelekScript>().Setup(new Punkt(x, y), numerKafelka);
		Kafelki.Add(new Punkt(x, y), nowyKafelek.GetComponent<KafelekScript>());
		
		
	}

	// Update is called once per frame
	void Start()
	{
		StworzPoziom();
		// wywo³ujemy fukncjê tworz¹c¹ waypointy
		FindObjectOfType<WaypointsManager>().BuildWaypoints();

	}
	private string[] WczytajPoziom()
	{
		print("Wczytujê");
		TextAsset wczytaneDane = Resources.Load("level") as TextAsset;
		string dane = wczytaneDane.text.Replace(Environment.NewLine, string.Empty);
		print("Wczyta³em");
		return dane.Split('-');
	}

}

