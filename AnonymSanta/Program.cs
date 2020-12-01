using System;
using System.IO;

namespace AnonymSanta
{
    class Program
    {
        public static string[] pullSantas;
        public static string[] pullRecipients;
        static void Main(string[] args)
        {
            pullSantas = new string[] { "Артём Павлов", "Владимир Сёмкин", "Даша Дерендяева", "Олеся Чернова", "Александр Великий", "Ольга Одношеина" };
            pullRecipients = new string[pullSantas.Length];

            RandomOrder();
            AssigningRecipients();
            ComposingMessage();





        }

        static void RandomOrder()
        {
            string thirdGlass;
            Random rnd = new Random();
            int index;

            for (int i = 0; i< pullSantas.Length;i++)
            {
                index = rnd.Next(0, pullSantas.Length - 1);

                thirdGlass = pullSantas[i];
                pullSantas[i] = pullSantas[index];
                pullSantas[index] = thirdGlass;

            }
        
        }

        static void AssigningRecipients()
        {
            for (int i = 0; i < pullSantas.Length - 1 ; i++)
            {
                pullRecipients[i] = pullSantas[i + 1];
            }

            pullRecipients[pullSantas.Length - 1] = pullSantas[0];
        }

        static void ComposingMessage()
        {
            string textMessage;
            string path;

            for (int i = 0; i < pullSantas.Length; i++)
            {
                textMessage = "Здраствуй, " + pullSantas[i] + "!\n" + "Ты как и твои друзья решили стать тайными сантами. " +
                    "\n Напомню правила: \n- Подарок должен быть от сердца \n- Начни готовить подарок уже сейчас \n- Придумай обёртку и то как ты его преподнесёшь \n" +
                    "Твой получатель: " + pullRecipients[i] + ". \nУдачи тебе в поисках!";
                path = @"C:\Users\111\source\repos\AnonymSanta\AnonymSanta\bin\Debug\netcoreapp3.1\Letters to santa\" +  pullSantas[i] + ".txt";

                using StreamWriter writer = new StreamWriter(path);
                writer.Write(textMessage);

            }
           
        }


    }
}
