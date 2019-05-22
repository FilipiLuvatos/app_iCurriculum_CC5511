
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public class LDDECanvas : MonoBehaviour

    {
        public Text TextoMostrado;
        public GameObject Painel2;
        public GameObject Painel3;
        public InputField nome;
        public InputField vagadesejada;
        public InputField email;
        public InputField busca;

            
        public void Main(int qual)
        {
            
                       
            LDDE<String> Tudo = new LDDE<String>();
            
            
            // Mostrar no Painel do Canvas Principal
            
            if(qual == 1){
                
                TextoMostrado.text = "Nome: \n" + nome.text + "\n\nE-mail: \n" + email.text + "\n\nVaga Desejada: \n" + vagadesejada.text; 
                Tudo.Inserir(nome.text);
                if(Painel2 != null)
                {
                    bool isActive = Painel2.activeSelf;
                    Painel2.SetActive(!isActive);
                }

            }
            if(qual == 2){

           // string aqui = @"c:\temp\Curriculum.txt";
            string aqui = @"/sdcard/Curriculum.txt";
            string conteudo;
            string auxs = ""; 
            int aux = 0;
            using (StreamReader sr = File.OpenText(aqui))
        
            
            
            while ((conteudo = sr.ReadLine()) != null)
            {   
                nome.text = conteudo;
                email.text = conteudo;

                if(aux == 0){
                auxs = conteudo;
                
                }   
                
                if(aux == 1){
                nome.text = auxs;
                
                }    
                aux++;  
            }

                if ( (Tudo.Busca(busca.text)).Equals(nome.text) ){
                    
                 TextoMostrado.text = busca.text + "\nInscrito na Vaga: " + vagadesejada.text;
                }
                else{
                    TextoMostrado.text = "Inscrição não Efetuada.";
                }


                if(Painel3 != null)
                {
                    bool isActive = Painel3.activeSelf;
                    Painel3.SetActive(!isActive);
                }
            }

            if(qual == 3){
                //Tudo.Remover("May");
                Tudo.Remover(nome.text);
                TextoMostrado.text = "Inscrição Cancelada";
            }

            if(qual == 4){
               
                bool isActive = Painel2.activeSelf;
                    Painel2.SetActive(!isActive);
            }
      }
    

    public class No<T>
    {
            public No<T> Proximo;
            public No<T> Anterior;
            public T Valor;
        
    }

    public class LDDE<T>
    {
        private No<T> Primeiro;
        private No<T> Link;
        private int Quantidade; // Quantidade de cadastros;
        public LDDE() => Primeiro = null;

        public void Inserir(T t)
        {
            No<T> Novo = new No<T>();
                      
            if (Primeiro == null){
            Novo.Proximo = null;
            Novo.Anterior = null;
            Novo.Valor = t;
            Primeiro = Novo;
            Link = Novo;
            Quantidade = 1;
                                     
            }
            else{
            Link.Proximo = Novo;
            Novo.Proximo = null;
            Novo.Anterior = Link;
            Novo.Valor = t;
            Link = Novo;
            Quantidade++;
            }        
        Gravar();
        }


        //Gravar no Arquivo;
        public void Gravar(){

        No<T> Aux = new No<T>();
        Aux = Primeiro;
        
           
            string local = @"/sdcard/LDDE.txt";
            //string local = @"c:\temp\LDDE.txt";
     
            using (StreamWriter sw = File.CreateText(local))
            {
                for(int i = 0; i < Quantidade; i++){
   
                sw.WriteLine(Aux.Valor);
               
                Aux = Aux.Proximo;

                }
            }
        }
        // Busca pelo TxT
        public String Busca(T vaga)
        {
            
        String fail = "Inscrição não Efetuada.";   

        string local = @"/sdcard/LDDE.txt";
        // string local = @"c:\temp\LDDE.txt";
        using (StreamReader sr = File.OpenText(local))
        {
            string conteudo;
            while ((conteudo = sr.ReadLine()) != null)
            {
                    if(conteudo.Equals(vaga))
                {
                    return conteudo;
                    //Console.Write("Nome Encontrado!\n");    
                    break;
                }
            }
        }
        return fail;
        }               


        public void Remover(String nome)
        {

        No<T> Aux = new No<T>();
        Aux = Primeiro;

        string local = @"/sdcard/LDDE.txt";
               
         //string local = @"c:\temp\LDDE.txt";
     
            using (StreamWriter sw = File.CreateText(local))
            {
                for(int i = 0; i < Quantidade; i++){
   
                if(Aux.Valor.Equals(nome)){}
                else{
                    sw.WriteLine(Aux.Valor);
                }
               
                Aux = Aux.Proximo;

                }
            }
        }

        }
    
    }