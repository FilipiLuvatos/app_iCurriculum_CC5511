
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurriculumPronto : MonoBehaviour
{

        public Text TextoMostrado;

        //Gravar no Arquivo;
        public void Gravar(){

            string local = @"/sdcard/Curriculum.txt";
           // string local = @"c:\temp\Curriculum.txt";
     
            using (StreamWriter sw = File.CreateText(local))
            {
                sw.WriteLine("Lilian Gomes Ferreira");
                sw.WriteLine("LiliGomes11@hotmail.com");
                                 
            }

            string lde = @"/sdcard/LDDE.txt";
           // string lde = @"c:\temp\LDDE.txt";
     
            using (StreamWriter sw = File.CreateText(lde))
            {
                sw.WriteLine("Lilian Gomes Ferreira");
                sw.WriteLine("LiliGomes11@hotmail.com");
                                 
            }
 

        Busca();   
        }
        public void Busca()
        {
        
        string local = @"/sdcard/Curriculum.txt";
        //string local = @"c:\temp\Curriculum.txt";

        using (StreamReader sr = File.OpenText(local))
        {
            TextoMostrado.text = ""; 
            string conteudo;
            while ((conteudo = sr.ReadLine()) != null)
            {   
                TextoMostrado.text += conteudo + "\n\n";
            }
        }
        
        }   

}
