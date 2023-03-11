using System;
using System.Collections;
using System.Text;

/*

@author Stephen Bailey
@version 1.0
Date 3-8-2023

Sololearn Program

You have two friends who are speaking Pig Latin to each other! Pig Latin is the same words in the same order except that you take the first letter of each word and put it on the end, then you add 'ay' to the end of that. ("road" = "oadray") 

Task
Your task is to take a sentence in English and turn it into the same sentence in Pig Latin! 

Input Format 
A string of the sentence in English that you need to translate into Pig Latin. (no punctuation or capitalization)

Output Format 
A string of the same sentence in Pig Latin.

Sample Input 
"nevermind youve got them"

Sample Output 
"evermindnay ouveyay otgay hemtay"

*/

namespace Sololearn_Pig_Latin
{
    class Program
    {
        static void Main(string[] args)
        {
            //comment out for Sololearn submission
            // test input for visual studio
            string inputSentence = "This is a pig latin converter";

            //comment out before for visual studio
            // get the input from Sololearn
            //string inputSentence = Console.ReadLine();

            // New pig latin converter object
            PigLatinSentenceConverter sentenceConverter = new PigLatinSentenceConverter(inputSentence);

            // send cards to be ranked and output ranking
            Console.WriteLine(sentenceConverter.OutputSentence());

            //comment out for Sololearn submission
            // hold prompt for testing
            Console.ReadKey();
        }

        // this class definition contains all the properties and functions to handle and evaluate the pig latin sentence converter
        class PigLatinSentenceConverter
        {
            // CONSTANTS
            private const int POSITION_FIRST_CHARACTER = 0;
            private const int POSITION_SECOND_CHARACTER = 1;

            // array to split the input on a space
            private readonly string[] oldSentence;

            // variable to store word pulled from sentence array
            private string newWord = "";

            // variable to store front character pulled from temp word
            private string originalFirstCharacter = "";

            // to build new sentence
            private ArrayList newSentence = new ArrayList();

            // constructor
            public PigLatinSentenceConverter(string sentence)
            {
                // seperate the input sentence
                oldSentence = sentence.Split(' ');

                // change the words
                ChangeWords();
            }

            // method to change the words
            private void ChangeWords()
            {
                // every word in sentence
                foreach (string word in oldSentence)
                {
                    // reset temp word
                    newWord = "";

                    // store first character
                    originalFirstCharacter = word[POSITION_FIRST_CHARACTER].ToString();

                    // get string starting from second letter to the end of original word
                    newWord += word.Substring(POSITION_SECOND_CHARACTER);

                    // add onto end of new word original first character along with "ay"
                    newWord += $"{originalFirstCharacter}ay";

                    // build the new sentence
                    BuildNewSentence();
                }
            }

            // method to build the new sentence
            private void BuildNewSentence() => newSentence.Add($"{newWord} ");

            // output the new sentence from array list
            public string OutputSentence()
            {
                // make new string builder object
                StringBuilder newString = new StringBuilder();

                // loop through new sentence array list
                foreach (string word in newSentence)
                {
                    // append each word
                    newString.Append(word);
                }

                // return the new sentence string
                return newString.ToString();
            }
        }
    }
}