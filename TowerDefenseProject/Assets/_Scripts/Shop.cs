using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Shop : MonoBehaviour {

    public int budget = 100;
    public int priceTower1 = 50;
    public int priceTower2 = 75;
    public Text budgetText;
	public Text errorText;

	private AudioSource errorSound;

    void Start()
    {
		errorText.text = "";
		updateBudget ();
		errorSound = GetComponent<AudioSource> ();
    }

	public bool PurchaseTower1()
    { 
		if(budget < priceTower1)
        {
			StartCoroutine ("ShowErrorText");
			errorSound.Play ();
            return false;
            Debug.Log("Not enough money");
        }
    
        Debug.Log("Tower 1 Purchased");
        budget -= priceTower1;
		updateBudget ();
		return true;
    }

	public bool PurchaseTower2()
	{ 
		if(budget < priceTower2)
		{
			errorSound.Play ();
			StartCoroutine ("ShowErrorText");
			return false;
			Debug.Log("Not enough money");
		}

		Debug.Log("Tower 2 Purchased");
		budget -= priceTower2;
		updateBudget ();
		return true;
	}

	public void addMoney(int money)
	{
		budget += money;
		updateBudget ();
	}

	private void updateBudget()
	{
		budgetText.text = "Budget: " + budget;
	}

	IEnumerator ShowErrorText()
	{
		errorText.text = "Not enough money";
		yield return new WaitForSeconds (2f);
		errorText.text = "";
	}
}
