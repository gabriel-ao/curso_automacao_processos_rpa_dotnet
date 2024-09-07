using EasyAutomationFramework;
using System.Security.Cryptography.X509Certificates;

namespace RobotWhatsapp
{
    public class WhatsappDriver : Web
    {
        public void SendMessageText(string message, string to)
        {
            try
            {
                NavegateWhatsSearchUser(to);

                SendMessage(message);

                Thread.Sleep(TimeSpan.FromSeconds(2));

                CloseBrowser();


            }
            catch (Exception ex)
            {
                CloseBrowser();

                Console.WriteLine("Ocorreu um erro: " + ex);
            }

        }

        public void SendMessageWithImage(string message, string pathImagem, string to)
        {
            try
            {
                NavegateWhatsSearchUser(to);

                AttachmentImage(pathImagem);
                
                AssignValue(TypeElement.Xpath, "//*[@id=\"app\"]/div/div[2]/div[2]/div[2]/span/div/div/div/div[2]/div/div[1]/div[3]/div/div/div[2]/div[1]/div[1]/p", message ?? "").element.SendKeys(OpenQA.Selenium.Keys.Enter);

                SendMessage(message);
            }
            catch (Exception ex)
            {
                CloseBrowser();

                Console.WriteLine("Ocorreu um erro no SendMessageWithImage: " + ex);
            }
        }

        private void NavegateWhatsSearchUser(string to)
        {
            try
            {

                var cacheRole = "C:\\Users\\Gabriel de Oliveira\\AppData\\Local\\Google\\Chrome\\User Data";
                StartBrowser(TypeDriver.GoogleChorme, pathCache: cacheRole);

                Navigate("https://web.whatsapp.com/");

                WaitForLoad();

                Thread.Sleep(TimeSpan.FromSeconds(8));

                // consultar usuário
                AssignValue(TypeElement.Xpath, "//*[@id=\"side\"]/div[1]/div/div[2]/div[2]/div/div/p", to).element.SendKeys(OpenQA.Selenium.Keys.Enter);
            }
            catch (Exception ex)
            {
                CloseBrowser();

                Console.WriteLine("Ocorreu um erro no NavegateWhatsSearchUser: " + ex);
            }
        }

        private void SendMessage(string message)
        {
            AssignValue(TypeElement.Xpath, "//*[@id=\"main\"]/footer/div[1]/div/span[2]/div/div[2]/div[1]/div/div[1]/p", message).element.SendKeys(OpenQA.Selenium.Keys.Enter);
        }

        private void AttachmentImage(string pathImagem)
        {
            // clicar no mais
            Click(TypeElement.Xpath, "//*[@id=\"main\"]/footer/div[1]/div/span[2]/div/div[1]/div[2]/div/div/div/span");

            // fotos e video
            AssignValue(TypeElement.Xpath, "//*[@id=\"main\"]/footer/div[1]/div/span[2]/div/div[1]/div[2]/div/span/div/ul/div/div[2]/li/div/input", pathImagem);

        }

        public void SendMessageWithEmoji(string message, List<string> emojis, string to) 
        {
            try
            {
                NavegateWhatsSearchUser(to);

                foreach (var emoji in emojis) {
                    AssignValue(TypeElement.Xpath, "//*[@id=\"main\"]/footer/div[1]/div/span[2]/div/div[2]/div[1]/div/div[1]/p", ":");
                    AssignValue(TypeElement.Xpath, "//*[@id=\"main\"]/footer/div[1]/div/span[2]/div/div[2]/div[1]/div/div[1]/p", emoji).element.SendKeys(OpenQA.Selenium.Keys.Tab); ;
                }

                SendMessage(message);

            }
            catch (Exception ex)
            {
                CloseBrowser();

                Console.WriteLine("Ocorreu um erro no SendMessageWithEmoji: " + ex);
            }
        }
    }
}
