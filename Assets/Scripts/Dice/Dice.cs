using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    //Variables
    public int diceNumber;

    

    public string winNumberText = "Die Gewinner Nummern sind: ";

    public string youWinText = ". Das bedeutet du hast gewonnen :D";


    int[] winningNumbers = new int[3];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("d")) {

            

            winningNumbers [0] = Random.Range(1, 7);
            // winningNumbers [1] = Random.Range(1, 7);
            do{
                winningNumbers [1] = Random.Range(1, 7);
            }while (winningNumbers[0] == winningNumbers [1]);

            // winningNumbers [2] = Random.Range(1, 7);
            do{
                winningNumbers [2] = Random.Range(1, 7);
            }while (winningNumbers[0] == winningNumbers [2] || winningNumbers [1] == winningNumbers[2]);

            diceNumber = Random.Range(1, 7);
            Debug.Log("Du hast eine: " + diceNumber + " gewürfelt!");

            
            // if (winningNumbers[0] == diceNumber || winningNumbers[1] == diceNumber || winningNumbers[2] == diceNumber) {
            //     Debug.Log(winNumberText + winningNumbers[0] +", " + winningNumbers[1] + ", " + winningNumbers[2] + youWinText);
            // }else {
            //     Debug.Log(winNumberText + winningNumbers [0] + ", " + winningNumbers[1]+ ", " + winningNumbers[2] + ". Das bedeutet du hast verloren :C");
            // }


            for (int i = 0; i < winningNumbers.Length; i++){
                // Debug.Log(i);
                if (winningNumbers[i] == diceNumber){
                    Debug.Log(winNumberText + winningNumbers[0] +", " + winningNumbers[1] + ", " + winningNumbers[2] + youWinText);
                }else if (i == winningNumbers.Length){
                    Debug.Log(winNumberText + winningNumbers [0] + ", " + winningNumbers[1]+ ", " + winningNumbers[2] + ". Das bedeutet du hast verloren :C");
                }
            }
        }

        
    }
}
