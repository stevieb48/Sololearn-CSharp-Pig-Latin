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
            string sentence = "This is a pig latin converter";

            //comment out before for visual studio
            // get the input from Sololearn
            //string sentence = Console.ReadLine();

            // New pig latin converter object
            PigLatinSentenceConverter sentenceconverter = new PigLatinSentenceConverter(sentence);

            // send cards to be ranked and output tanking
            Console.WriteLine(sentenceconverter.OutputSentence());

            //comment out for Sololearn submission
            // hold prompt for testing
            Console.ReadKey();
        }

        // this class contains all the properties and functions to handle and evaluate the pig lating sentence converter
        class PigLatinSentenceConverter
        {
            // CONSTANTS
            private const string ADD_ON = "ay";
            private const int firstCharacter = 0;
            private const int secondCharacter = 1;

            // array to split the input on a space
            private string[] oldSentence;

            // variable to store word pulled from sentence array
            private string newWord = "";

            // variable to store front character pulled from temp word
            private string tempLetter = "";

            // to build new sentence
            private ArrayList newSentence = new ArrayList();

            // constructor
            public PigLatinSentenceConverter(string sentence)
            {
                // seperate the input sentence
                oldSentence = sentence.Split(' ');

                // change the words
                ChangeWords();

                // make a new sentence
                BuildNewSentence();
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
                    tempLetter = word[firstCharacter].ToString();

                    // loop through letters starting with second character
                    for (int i = secondCharacter; i < word.Length; i++)
                    {
                        // add to current tempword with next letter
                        newWord += word[i].ToString();
                    }

                    // last pass dont add the space
                    newWord += tempLetter + ADD_ON;

                    //build the new sentence
                    BuildNewSentence();
                }
            }

            // method to build the new sentence
            private void BuildNewSentence()
            {
                // add temp word to new sentence
                newSentence.Add(newWord + " ");
            }

            // output the new sentence from array list
            public string OutputSentence()
            {
                // make new string builder object
                StringBuilder s = new StringBuilder();

                // remove extra word
                newSentence.RemoveAt(oldSentence.Length - 1);

                // loop through sentence array list
                foreach (string word in newSentence)
                {
                    // append the word
                    s.Append(word);
                }

                // return the new string
                return s.ToString();
            }
        }
    }
}