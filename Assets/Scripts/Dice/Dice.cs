using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{

    AudioSource audioData;


    //Variables
    public int diceNumber;
    public int maxDiceNumber = 51;
    public int luckyNumberLength = 8;

    public bool win = false;


    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("d")) {

            //generates a array of Lucky Numbers (length is set on top with the other variables) 
            int[] winningNumbers = new int[luckyNumberLength];

            //fills the array with lucky Numbers and checks for double Numbers
            for (int i = 0; i < luckyNumberLength; i++){
                do{
                    winningNumbers [i] = Random.Range(1, maxDiceNumber);
                }while (checkForDoubleNumbers(i, winningNumbers)); 
            }

            diceNumber = Random.Range(1, maxDiceNumber);
            Debug.Log("Du hast eine: " + diceNumber + " gewürfelt.");

            //checks if the user is a winner or a loser and returns a Debug Message 
            for (int i = 0; i < winningNumbers.Length; i++){
                //Debug.Log(winningNumbers[i]);

                //if a winning Number was rolled you get a sound and a message
                if (winningNumbers[i] == diceNumber){
                    Debug.Log("Du hast gewonnen mit der Nummer: " + winningNumbers[i] );
                    audioData = GetComponent<AudioSource>();
                    audioData.Play(0);
                    Debug.Log("Audio played");
                    win = true;
                
                // if you didnt have won you get a message and the lucky Numbers
                }else if (i == winningNumbers.Length-1 && win == false){
                    Debug.Log("Du hast leider verloren :C");
                    Debug.Log("Die Gewinner Nummern sind: ");
                    returnWinningNumbers(winningNumbers);
                }
            }
            //resets win to false
            win = false;
        }

        
    }

    //checks for Double Numbers 
    public bool checkForDoubleNumbers(int i, int[]array){

        

        for (int l = 0; l < i; l++) {
            
            if (array[l] == array[i]){
                return true;
            }
        }
        return false;

    }
    
    //return a debug message with all lucky Numbers 
    public void returnWinningNumbers (int []array) {


        for (int i = 0; i < array.Length; i++){
            Debug.Log(array[i]);
        }

    }
}
