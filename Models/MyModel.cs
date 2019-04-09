using System;

namespace VirtualPetDojoDatchi.Models
{
    public class Pet
    {
       public int Happiness {get;set;} = 20;

       public int Fullness {get;set;} = 20;

       public int Energy{get;set;} = 50; 

       public int Meal{get;set;} = 3;

       public string Message{get;set;} = "Nothing Dawg";
    }
}