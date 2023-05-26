using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FarmManager : MonoBehaviour
{
    public Plantitem selectPlant;
    public bool isPlanting = false;
    public int money = 100;
    public Text moneyTxt;

    public Color buyColor = new Color(38,138,64);
    public Color cancelColor = new Color(166,0,0);

    public bool isSelecting = false;
    public int selectedTool = 0;
    // 1- Water 2-Fertilize 3- Buy Plot

    public Image[] buttonImg;
    public Sprite normalButton;
    public Sprite selectedButton;

    // Start is called before the first frame update
    void Start()
    {
        moneyTxt.text = money + "р.";
    }

    public void SelectPlant(Plantitem newPlant)
    {
        if(selectPlant == newPlant)
        {

            CheckSelection();
           
        }

        else
        {
            CheckSelection();
            selectPlant = newPlant;
            selectPlant.btnImage.color = cancelColor;
            selectPlant.btnTxt.text = "Отмена";
            Debug.Log("Выбрано " + selectPlant.plant.plantName);
            isPlanting = true;
        }
    }

    public void SelectTool(int toolNumber)
    {
        if(toolNumber == selectedTool)
        {
            //deselect
            CheckSelection();
        }
        else
        {
            //select tool number and check to see if anything was also selected
            CheckSelection();
            isSelecting = true;
            selectedTool = toolNumber;
            buttonImg[toolNumber - 1].sprite = selectedButton;
        }
    }


    void CheckSelection()
    {
        if (isPlanting)
        {
            isPlanting = false;
            if (selectPlant != null)
            {
                selectPlant.btnImage.color = buyColor;
                selectPlant.btnTxt.text = "Купить";
                selectPlant = null;
            }
        }

        if(isSelecting)
        {
            if(selectedTool > 0)
            {
                buttonImg[selectedTool - 1].sprite = normalButton;
            }
            isSelecting = false;
            selectedTool = 0;
        }

    }

    public void Transaction(int value)
    {
        money += value;
        moneyTxt.text = money + "р.";
    }
}
