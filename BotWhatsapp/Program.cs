using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V104.CSS;
using OpenQA.Selenium.Edge;
using System;
using System.Data;
using System.Globalization;

namespace BotWhatsapp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            string url = "https://web.whatsapp.com/";
            List<string> contatos = new List<string>()
            {
                "ESCREVA O NOME DO CONTATO EXATAMENTE COMO ESTÁ AQUI"
            };

            ChromeDriver driver = new ChromeDriver();
          
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();

            Thread.Sleep(15000);

            foreach (var contato in contatos)
            {
                // < div data - testid = "chat-list-search"
                // title = "Caixa de texto de pesquisa" role = "textbox"
                // class="_13NKt copyable-text selectable-text" contenteditable="true" data-tab="3" dir="ltr"></div> 

                By locator = By.ClassName("_13NKt"); // entra na classe da barra de pesquisA
                var pesquisaE1 = driver.FindElement(locator); // entra na classe da barra de pesquisA
                pesquisaE1.SendKeys(contato); //pesquisa o nome do contato

                Thread.Sleep(1500); //1,5 segundos


                //<span dir="auto" title="botTest" aria-label="" class="ggj6brxn gfz4du6o r7fjleex g0rxnol2 lhj4utae le5p0ye3 l7jjieqr i0jNr">
                //<span class="matched-text i0jNr">botTest</span></span>



                //ACHA O CONTATO E CLICA NELE
                By path = By.XPath($"//span[@title='{contato}']");
                var contatoE1 = driver.FindElement(path);
                contatoE1.Click();

         
                for (int i = 0; i < 20; i++) 
                {

                    //ACHA O CONTATO E CLICA NELE

                    //Vai clicar no chat para digitar: 
                    // <div tabindex="-1" class="p3_M1">
                    
                    var chatE1 = driver.FindElement(By.ClassName("p3_M1"));
                    chatE1.SendKeys("ESCREVA A MENSAGEM AQUI");

                    //Thread.Sleep(500);

                    //<span data-testid="send" data-icon="send"
                    var buttonSendE1 = driver.FindElement(By.XPath($"//span[@data-icon='send']"));
                    buttonSendE1.Click();
                }    
            }

        }
    }
}
