using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System.Windows.Forms;


namespace pruebas
{
    class Program
    {

        static void Main(string[] args)
        {

            //variables 

            int contador = 0;
            int num_lineas;
            string[] array = null;
            string ruta_actual = Directory.GetCurrentDirectory();

            var ruta = Directory.GetCurrentDirectory() + "/articulo.csv";

            Console.Write("Introduzca el numero de anuncios a publicar : ");
            num_lineas = Convert.ToInt32(Console.ReadLine());

            array = File.ReadAllLines(ruta);

            InternetExplorerOptions options = new InternetExplorerOptions();
            
           

            IWebDriver web = new InternetExplorerDriver(ruta_actual);

            

            while (contador < num_lineas)
            {

                

                while (true)
                {


                    var url = array[contador].Split(',')[0];
                    var titulo = array[contador].Split(',')[1];
                    var provincia = array[contador].Split(',')[2];
                    var descripcion = array[contador].Split(',')[3];
                    var precio = array[contador].Split(',')[4];
                    var nombre = array[contador].Split(',')[5];
                    var email = array[contador].Split(',')[6];
                    var remail = array[contador].Split(',')[6];
                    var telefono = array[contador].Split(',')[7];

                    var imagen = array[contador].Split(',')[8];



                    //navegacion a la pagina

                    web.Navigate().GoToUrl(url);
                    

                    //espera implicita

                    //WebDriverWait wait = new WebDriverWait(web, TimeSpan.FromSeconds(60));
                    //IWebElement element = wait.Until((x) => { return x.FindElement(By.Id("titulo")); });

                    


                    new WebDriverWait(web, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementExists((By.Id("titulo"))));


                    //limpieza de Imput

                    web.FindElement(By.XPath("//*[@id='titulo']")).Clear();

                    web.FindElement(By.XPath("//*[@id='mapPlaceBox']")).Clear();

                    web.FindElement(By.XPath("//*[@id='texto']")).Clear();

                    web.FindElement(By.XPath("//*[@id='precio']")).Clear();

                    web.FindElement(By.XPath("//*[@id='nombre']")).Clear();

                    web.FindElement(By.XPath("//*[@id='email']")).Clear();

                    web.FindElement(By.XPath("//*[@id='repemail']")).Clear();

                    web.FindElement(By.XPath("//*[@id='telefono1']")).Clear();

                    


                    Thread.Sleep(2000);

                    //titulo

                    web.FindElement(By.XPath("//*[@id='titulo']")).SendKeys(titulo);

                    Thread.Sleep(2000);

                    //provincia

                    web.FindElement(By.XPath("//*[@id='mapPlaceBox']")).SendKeys(provincia);

                    Thread.Sleep(2000);

                    //descripcion

                    web.FindElement(By.XPath("//*[@id='texto']")).SendKeys(descripcion);

                    Thread.Sleep(2000);


                    /////vendedor/////

                    SelectElement select = new SelectElement(web.FindElement(By.Id("vendedor")));

                    select.SelectByText("Profesional");

                    Thread.Sleep(2000);

                    //precio

                    web.FindElement(By.XPath("//*[@id='precio']")).SendKeys(precio);


                    Thread.Sleep(2000);

                    //nombre

                    web.FindElement(By.XPath("//*[@id='nombre']")).SendKeys(nombre);

                    Thread.Sleep(2000);


                    //email

                    web.FindElement(By.XPath("//*[@id='email']")).SendKeys(email);

                    Thread.Sleep(2000);

                    //remail 

                    web.FindElement(By.XPath("//*[@id='repemail']")).SendKeys(remail);

                    Thread.Sleep(2000);

                    //Telefono

                    web.FindElement(By.XPath("//*[@id='telefono1']")).SendKeys(telefono);

                    Thread.Sleep(2000);



                    //Aceptar las condiciones


                    web.FindElement(By.XPath("//*[@id='acepto_condiciones_uso_y_politica_de_privacidad']")).Click();

                    Thread.Sleep(2000);

                    //Subir fotos

                    web.FindElement(By.XPath("//*[@id='photoUploader']/div/span/div")).Click();

                    System.Windows.Forms.SendKeys.SendWait(imagen);
                    SendKeys.SendWait(@"{Enter}");


                    Thread.Sleep(6000);

                    
                    //crear

                    web.FindElement(By.XPath("//*[@id='elform']/div[3]/div[2]/input")).Click();


                    Thread.Sleep(2000);

                    SendKeys.SendWait(@"{Enter}");


                    break;


                }



                Thread.Sleep(10000);

                contador++;

            }



            
            web.Quit();


        }
    }
}
